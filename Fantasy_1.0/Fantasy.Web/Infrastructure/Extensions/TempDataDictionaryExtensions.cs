using Fantasy.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Fantasy.Web.Infrastructure.Extensions
{
    using static GlobalConstants;

    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataErrorMessageKey] = message;
        }
    }
}
