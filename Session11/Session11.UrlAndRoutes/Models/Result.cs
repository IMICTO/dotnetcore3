using System.Collections.Generic;

namespace Session11.UrlAndRoutes.Models
{
    public class Result
    {
        public Result()
        {
            Data = new Dictionary<string, object>();
        }

        public string Controller { get; set; }

        public string Action { get; set; }

        public IDictionary<string, object> Data { get; private set; }
    }
}
