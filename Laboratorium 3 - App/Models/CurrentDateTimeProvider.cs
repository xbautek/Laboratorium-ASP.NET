namespace Laboratorium_3___App.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentData()
        {
            DateTime x = DateTime.Now;
            return x;
        }
    }
}
