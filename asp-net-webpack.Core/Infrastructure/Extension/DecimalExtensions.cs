using System.Globalization;

namespace asp_net_webpack.Core
{
    public static class DecimalExtensions
    {
        public static string ToFormattedString(this decimal value)
        {
            return value.ToString("#,##0.00", CultureInfo.InvariantCulture).Replace(",", " ");
        }
    }
}
