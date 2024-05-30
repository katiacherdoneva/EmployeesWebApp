namespace Web.Api.Utils
{
    public static class CalculateDatetime
    {
        public static int Overlap(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
        {
            DateTime start = startDate1 < startDate2 ? startDate2 : startDate1;
            DateTime end = endDate1 < endDate2 ? endDate1 : endDate2;

            if (end >= start)
            {
                TimeSpan diffTime = end - start;
                int diffDays = (int)Math.Ceiling(diffTime.TotalDays);
                return diffDays;
            }

            return 0;
        }
    }
}
