using System;

namespace Users.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; }
        public User(string name, DateTime dateOfBirth)
        {
            Random random = new Random();
            
            ID = random.Next(10, 99);
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = this.GetAge(DateOfBirth);
        }
        public User(int id, string name, DateTime dateOfBirth)
        {
            ID = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = this.GetAge(DateOfBirth);
        }
        public int GetAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > now.AddYears(-age)) age--;

            return age;
        }

    }
}
