using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;

namespace Web.Api.Helpers
{
    public class CustomDateTimeConverter : DefaultTypeConverter
    {
        private readonly string[] dateFormats = new[]
        {
            "MM/dd/yyyy", "yyyy-MM-dd", "dd/MM/yyyy", "MM-dd-yyyy", "dd-MM-yyyy",
            "yyyy/MM/dd", "M/d/yyyy", "d/M/yyyy", "M-d-yyyy", "d-M-yyyy",
            "yyyyMMdd", "ddMMyyyy", "MMddyyyy", "yyyyMMddTHHmmss"
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            {
                return DateTime.Today;
            }

            foreach (var format in dateFormats)
            {
                if (DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}