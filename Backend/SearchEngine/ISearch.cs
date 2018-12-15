using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using SearchEngine.Model;
using static SearchEngine.SearchUtils;

namespace SearchEngine
{
    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        IEnumerable<string> SearchSomething(string phrase, ESortType sortType, int pageSize);
    }

    public class Search : ISearch
    {
        public List<User> Users { get; set; } 
        public IEnumerable<string> SearchSomething(string phrase, ESortType sortType, int pageSize)
        {
            var searchResults = from user in Users
                where ContainsFuzzy(user.Username, phrase)
                select user.Username;

            return searchResults.Take(pageSize);
        }
    }
}