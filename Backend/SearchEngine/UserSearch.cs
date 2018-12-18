using SearchEngine.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine
{
    public abstract class UserSearch : SearchBase<UserDTO>
    {
        /// <summary>
        /// Applies filters to given list of items
        /// <para>Possible filters are: "StrictSearch"</para>
        /// </summary>
        /// <param name="input"> List of items to which apply the filter</param>
        /// <param name="filters"> Dictionary of filters and their values </param>
        /// <returns> Filtered out list </returns>
        protected IEnumerable<UserDTO> ApplyFilters(IEnumerable<UserDTO> input, Dictionary<string, string> filters)
        {
            foreach(KeyValuePair<string, string> pair in filters)
            {
                if(pair.Key.Equals("StrictSearch"))
                {
                    double parsedValue;
                    bool parsed = double.TryParse(pair.Value, out parsedValue);
                    return input.Where(n => n.Score < parsedValue);
                }
            }
            return input;
        }
    }
}
