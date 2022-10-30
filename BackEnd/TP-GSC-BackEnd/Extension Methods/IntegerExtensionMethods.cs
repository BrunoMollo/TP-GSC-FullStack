using Microsoft.AspNetCore.Mvc.Localization;
using System.Runtime.CompilerServices;

namespace TP_GSC_BackEnd.Extension_Methods
{
    public static class IntegerExtensionMethods
    {
        public static bool isBetweenExcluding(this int value, int low, int up) => low<value && value<up;
        
    }
}
