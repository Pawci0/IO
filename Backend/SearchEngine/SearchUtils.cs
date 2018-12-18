using SearchEngine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public static class SearchUtils
    {    
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int LevenshteinDistance(string first, string other)
        {
            string a = first.ToLower();
            string b = other.ToLower();
            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            int cost;
            int[,] d = new int[a.Length + 1, b.Length + 1];
            int min1;
            int min2;
            int min3;

            for (int i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (int i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (int i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (int j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = (a[i - 1] != b[j - 1]) ? 1 : 0;

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];

        }

        public static bool ContainsFuzzy(this string target, string searched, out float score)
        {
            score = 0;
            // cheap stuff first
            if (target == searched) return true;
            if (target.Contains(searched)) return true;
            score = (float)LevenshteinDistance(target, searched) / (float)target.Length;
            if (score < 0.3f) return true;
            return false;
        }

        public static IEnumerable<ISearch<ISearchItemDTO>> GetAllSearchEngines()
        {
            return new ISearch<ISearchItemDTO>[] 
            { new ProductNameSearch() as ISearch<ISearchItemDTO>,
                new TagSearch() as ISearch<ISearchItemDTO>,
                new RatingSearch() as ISearch<ISearchItemDTO>,
                new UserFullnameSearch() as ISearch<ISearchItemDTO>,
                new UserUsernameSearch() as ISearch<ISearchItemDTO> };
        }
    }
}
