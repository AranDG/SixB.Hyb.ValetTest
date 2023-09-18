using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace SixB.Hyb.ValetTest
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            if (!tempData.TryGetValue(key, out var target))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(target.ToString());
        }
    }
}
