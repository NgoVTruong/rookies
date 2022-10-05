namespace C__fundamental__1
{
    class Program
    {
        private static void LogMemberToConsole(Member member)
        {
            Console.WriteLine
            (" {0} | {1} | {2} | {3} | {4} | {5} | {6}",
                member.FirstName,
                member.LastName,
                member.Gender,
                member.DateOfBirth,
                member.PhoneNumber,
                member.BirthPlace,
                (member.IsGraduated) ? "Yes Graduated" : "No Graduated"
            );
        }
        private static void LogMemberToConsole(string description, Member member)
        {
            Console.WriteLine(description + ": " + " {0} | {1} | {2} | {3} | {4} | {5} | {6}",
                member.FirstName,
                member.LastName,
                member.Gender,
                member.DateOfBirth,
                member.PhoneNumber,
                member.BirthPlace,
                (member.IsGraduated) ? "Yes Graduated" : "No Graduated");
        }
        private static List<Member> InitiateMembers()
        {
            List<Member> members = new List<Member>
            {
                new Member { FirstName = "Mahesh", LastName = "Chand", Gender = "male", DateOfBirth = new DateTime(2000, 12, 21), PhoneNumber = "0943764955", BirthPlace = "Ha Noi",  IsGraduated = true  },
                new Member { FirstName = "Neel", LastName = "Beniwal", Gender = "male", DateOfBirth = new DateTime(2001, 11, 11), PhoneNumber = "0943764955", BirthPlace = "Nam Dinh",  IsGraduated = true },
                new Member { FirstName = "Chris", LastName = "Love", Gender = "male", DateOfBirth = new DateTime(2002, 10, 01), PhoneNumber = "0943764955", BirthPlace = "Thai Binh", IsGraduated = true}
            };

            members.Add(new Member { FirstName = "Titania", LastName = "Hammer", Gender = "female", DateOfBirth = new DateTime(2000, 1, 1), PhoneNumber = "0943764955", BirthPlace = "Nghe An", IsGraduated = true });
            members.Add(new Member { FirstName = "Ronaldo", LastName = "Leon", Gender = "male", DateOfBirth = new DateTime(1999, 6, 16), PhoneNumber = "0943764955", BirthPlace = "Ha Tinh", IsGraduated = false });
            members.Add(new Member { FirstName = "Evan", LastName = "Downey", Gender = "male", DateOfBirth = new DateTime(1998, 5, 15), PhoneNumber = "0943764955", BirthPlace = "Lao Cai", IsGraduated = true });

            return members;
        }

        private static List<Member> WhoIsMale(List<Member> members)
        {
            List<Member> males = new List<Member>();

            foreach (var member in members)
            {
                if (member.Gender.ToLower() == "male")
                {
                    males.Add(member);
                }
            }
            return males;
        }

        private static List<string> GetFullNames(List<Member> members)
        {
            List<string> fullnames = new List<string>();

            foreach (var member in members)
            {
                fullnames.Add(member.FullName);
            }

            return fullnames;
        }

        private static List<List<Member>> GetThreeLists(List<Member> members)
        {
            List<List<Member>> threeLists = new List<List<Member>>();

            List<Member> equal2000 = new List<Member>();
            List<Member> greaterThan2000 = new List<Member>();
            List<Member> lessThan2000 = new List<Member>();

            foreach (var member in members)
            {
                switch (member.DateOfBirth.Year)
                {
                    case 2000:
                        equal2000.Add(member);
                        break;
                    case < 2000:
                        greaterThan2000.Add(member);
                        break;
                    case > 2000:
                        lessThan2000.Add(member);
                        break;
                    default:
                }
            }

            threeLists.Add(equal2000);
            threeLists.Add(greaterThan2000);
            threeLists.Add(lessThan2000);

            return threeLists;
        }

        private static Member GetFirstMemberBornIn(List<Member> members, string place = "Ha Noi")
        {
            Member FirstMemberInPlace = new Member();

            int i = 0;

            while (!(members[i].BirthPlace.ToLower().Trim() == place.ToLower().Trim()))
            {
                i++;
            }

            return FirstMemberInPlace = members[i];
        }

        private static Member GetOldestMember(List<Member> members)
        {
            Member oldestMember = new Member { DateOfBirth = DateTime.Now }; // assign value for oldestMember

            foreach (var member in members)
            {
                if (member.Age > oldestMember.Age)
                {
                    oldestMember = member;
                }
            }

            return oldestMember;
        }

        static void Main(string[] args)
        {
            List<Member> members = InitiateMembers();

            List<Member> males = WhoIsMale(members);
            List<string> fullnames = GetFullNames(members);
            List<List<Member>> threeLists = GetThreeLists(members);
            Member oldestMember = GetOldestMember(members);
            Member MemberBornIn = GetFirstMemberBornIn(members);


            while (true)
            {
                Console.WriteLine("Press 1 to get list males");
                Console.WriteLine("Press 2 to get list fullnames");
                Console.WriteLine("Press 3 to get list equal 2000");
                Console.WriteLine("Press 4 to get list greated than 2000");
                Console.WriteLine("Press 5 to get list less than 2000");
                Console.WriteLine("Press 6 to get Olderst Member");
                Console.WriteLine("Press 7 to get First Member Born In Ha Noi");
                Console.WriteLine("Enter your choice: ");

                int key;
                key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        Console.WriteLine("1");
                        Console.WriteLine("----------> MALES <----------");
                        Console.WriteLine("MALES:");

                        foreach (var male in males)
                        {
                            LogMemberToConsole(male);
                        }

                        Console.WriteLine("----------> ----- <----------");
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("2");
                        Console.WriteLine("----------> FULL NAMES <----------");
                        Console.WriteLine("FULL NAMES:");

                        foreach (var fullname in fullnames)
                        {
                            Console.WriteLine(fullname);
                        }

                        Console.WriteLine("----------> ---------- <----------");
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        Console.WriteLine("3");
                        Console.WriteLine("EQUAl 2000:");

                        foreach (var member in threeLists[0])
                        {
                            LogMemberToConsole(member);
                        }

                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.WriteLine("4");
                        Console.WriteLine("GREATED THAN 2000");

                        foreach (var member in threeLists[1])
                        {
                            LogMemberToConsole(member);
                        }

                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("5");
                        Console.WriteLine("LESS THAN 2000");

                        foreach (var member in threeLists[2])
                        {
                            LogMemberToConsole(member);
                        }

                        Console.WriteLine("\n");
                        break;
                    case 6:
                        Console.WriteLine("6");
                        Console.WriteLine("----------> Olderst Member <----------");
                        LogMemberToConsole("Olderst Member", oldestMember);
                        Console.WriteLine("----------> -------------- <----------");
                        Console.WriteLine("\n");
                        break;
                    case 7:
                        Console.WriteLine("7");
                        Console.WriteLine("----------> First Member Born In Ha Noi <----------");
                        LogMemberToConsole("First Member Born In Ha Noi", MemberBornIn);
                        Console.WriteLine("----------> --------------------------- <----------");
                        Console.WriteLine("\n");
                        break;
                    default: break;
                }
            }
        }
    }
}