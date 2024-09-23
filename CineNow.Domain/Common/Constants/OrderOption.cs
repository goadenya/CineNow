using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Domain.Common.Constants
{
    public static class OrderOption
    {
        public static class Movie 
        {
            private static Dictionary<string, string> SortOptions = new Dictionary<string, string>() 
            {
                { "title", "Title" },
                { "imdbrating", "RatingAsNumber" },
                { "imdbrank", "Rank" },
                { "latest", "CreatedDate" },
            };

            public static string GetOrderOption(string sortOptionKey)
            {
                if(SortOptions.TryGetValue(sortOptionKey.ToLower(), out string value))
                {
                    return value;
                }

                return string.Empty;
            }
        }
    }
}
