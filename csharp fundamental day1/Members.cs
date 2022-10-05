namespace C__fundamental__1
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public int Age
        {
            get
            {
                int Age = DateTime.Now.Year - DateOfBirth.Year;

                if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                {
                    Age--;
                }

                return Age;
            }
        }
        public bool IsGraduated { get; set; }
    }
}