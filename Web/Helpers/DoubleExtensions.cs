using System.Globalization;

namespace Web.Helpers
{
    public static class DoubleExtensions
    {
        public static string ToCurrency(this double number)
        {
            return number.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

    }
}