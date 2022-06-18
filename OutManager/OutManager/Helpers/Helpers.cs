using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OutManager.Helpers
{
    public static class Helpers
    {
        public static string ToTitleCase(this string texto)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }
    }
}
