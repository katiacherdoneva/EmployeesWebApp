namespace Web.Api.Utils
{
    public static class CalculateDatetime
    {
        public static int Overlap(DateTime e1d1, DateTime e1d2, DateTime e2d1, DateTime e2d2)
        {
            DateTime startDate1 = e1d1;
            DateTime endDate1 = e1d2 == null ? DateTime.Now : e1d2;
            DateTime startDate2 = e2d1;
            DateTime endDate2 = e2d2 == null ? DateTime.Now : e2d2;

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
