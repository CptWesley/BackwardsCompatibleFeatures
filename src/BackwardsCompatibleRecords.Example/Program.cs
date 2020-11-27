using System;

namespace BackwardsCompatibleRecords.Example
{
    public abstract record Person(string Name);
    public record Student(string Name, string Major) : Person(Name);
    public record Professor(string Name, string Department) : Person(Name);

    public static class Program
    {
        private static readonly Person[] people = new Person[]
        {
            new Student("Frodo", "Questing"),
            new Student("Sam", "Questing"),
            new Professor("Gandalf", "Department of Wizardry"),
            new Professor("Elrond", "Department of Elves"),
        };

        public static void Main(string[] args)
        {
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} - {GetMajorOrDepartment(person)}");
            }
        }

        private static string GetMajorOrDepartment(Person person)
            => person switch
            {
                Student(_, string m) => m,
                Professor(_, string d) => d,
            };
    }
}
