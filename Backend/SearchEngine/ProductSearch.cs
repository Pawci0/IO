using SearchEngine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SearchEngine
{

    public abstract class ProductSearch : SearchBase<ProductDTO>
    {
        /// <summary>
        /// Applies filters to given list of items
        /// <para>Possible filter keys are the same as names of properties of ProductDTO</para>
        /// <para>Possible values are: "is empty or null" and "is not null" for strings, 
        /// "higher than x" and "lower than x" for numeric values</para>
        /// </summary>
        /// <param name="input"> List of items to which apply the filter</param>
        /// <param name="filters"> Dictionary of filters and their values </param>
        /// <returns> Filtered out list </returns>
        protected IEnumerable<ProductDTO> ApplyFilters(IEnumerable<ProductDTO> input, Dictionary<string, string> filters)
        {
            foreach(PropertyInfo property in typeof(ProductDTO).GetProperties())
            {
                if(filters.ContainsKey(property.Name))
                {
                    string stringToParse = filters[property.Name].ToLower();
                    if(stringToParse.Contains("is empty or null"))
                    {
                        return input.Where(n => string.IsNullOrEmpty(property.GetValue(n) as string));
                    }
                    else if(stringToParse.Contains("is not null"))
                    {
                        return input.Where(n => !(property.GetValue(n) is null));
                    }
                    else if(stringToParse.Contains("higher than"))
                    {
                        int substringStartIndex = stringToParse.IndexOf("higher than");
                        string numericSubstring = stringToParse.Substring(substringStartIndex);
                        double value;
                        bool parsed = double.TryParse(numericSubstring, out value);
                        if(parsed)
                        {
                            return input.Where(n => (double)property.GetValue(n) > value);
                        }
                    }
                    else if (stringToParse.Contains("lower than"))
                    {
                        int substringStartIndex = stringToParse.IndexOf("higher than");
                        string numericSubstring = stringToParse.Substring(substringStartIndex);
                        double value;
                        bool parsed = double.TryParse(numericSubstring, out value);
                        if (parsed)
                        {
                            return input.Where(n => (double)property.GetValue(n) < value);
                        }
                    }
                }
            }

            return input;
        }

        protected double AverageRatings(ICollection<Database.Rating> ratings)
        {
            double avg = 0;
            foreach (var value in ratings)
            {
                avg += value.Value;
            }

            return Math.Round(avg / ratings.Count, 2);
        }
    }
}
