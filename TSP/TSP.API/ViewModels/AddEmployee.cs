namespace TSP.API.ViewModels
{
    public class AddEmployee
    {
        public AddEmployee(string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            Name = name;
            SecondName = secondName;
            Patronomic = patronomic;
            Age = age;
            Position = position;
            OfficeId = officeId;
        }

        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int OfficeId { get; set; }
    }
}
