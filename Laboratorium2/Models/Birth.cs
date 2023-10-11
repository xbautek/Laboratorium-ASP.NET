namespace Laboratorium2.Models
{
    public class Birth
    {
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }



        public int CountAge()
        {
            int wiek;
            if (((DateTime)BirthDate).Month == DateTime.Now.Month) //funkcja która oblicza wiek
            {
                wiek = (((DateTime.Now.Year - 1) * 12 + DateTime.Now.Month) - ((((DateTime)BirthDate).Year - 1) * 12 + ((DateTime)BirthDate).Month)) / 12 - 1;
                if (DateTime.Now.Day >= ((DateTime)BirthDate).Day)
                {
                    wiek++;
                }
            }
            else
            {
                wiek = (((DateTime.Now.Year - 1) * 12 + DateTime.Now.Month) - ((((DateTime)BirthDate).Year - 1) * 12 + ((DateTime)BirthDate).Month)) / 12;
            }

            return wiek;
        }

        public bool IsValid()
        {
            return Name != null && BirthDate != null && BirthDate < DateTime.Today;
        }
    }
}
