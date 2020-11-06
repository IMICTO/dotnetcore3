using System.Collections.Generic;

namespace StoreCore3.Extentions.Extentions
{
    public static class StringExtention
    {
        public static string SetPersianYeKe(this string input)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                ["ك"] = "ک",
                ["ي"] = "ی"
            };

            foreach (KeyValuePair<string, string> item in keyValues)
            {
                input = input.Replace(item.Key, item.Value);
            }

            return input;
        }
    }
}
