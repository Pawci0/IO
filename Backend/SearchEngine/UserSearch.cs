using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Model;
using static SearchEngine.SearchUtils;

namespace SearchEngine
{
    class UserSearch : ISearch
    {
        public List<User> Users { get; set; }

        public IEnumerable<string> Search(string phrase, ESortType sortType, int pageSize)
        {

            var searchResults = from user in Users
                where ContainsFuzzy(user.Username, phrase)
                select user.Username;

            return searchResults.Take(pageSize);


        }
    }
}
