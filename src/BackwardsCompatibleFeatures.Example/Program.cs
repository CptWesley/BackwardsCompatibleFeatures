using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace BackwardsCompatibleRecords.Example;

public abstract record Person(string Name);
public record Student(string Name, string Major) : Person(Name);
public record Professor(string Name, string Department) : Person(Name);

public static class Program
{
    private static readonly Person?[]? people = new Person[]
    {
        new Student("Frodo", "Questing"),
        new Student("Sam", "Questing"),
        new Professor("Gandalf", "Department of Wizardry"),
        new Professor("Elrond", "Department of Elves"),
    };

    public static void Main(string[] args)
    {
        HiFromWindows();
        HiFromLinux();
        CheckNotNull(people);

        for (int i = 1; i <= people.Length; i++)
        {
            Person? person = people[^i];
            CheckNotNull(person);
            Console.WriteLine($"{person.Name} - {GetMajorOrDepartment(person)}");
        }

        HighlightRegex(@"0|-?[1-9][0-9]*");
    }

    [Pure]
    private static string GetMajorOrDepartment(Person person)
        => person switch
        {
            Student(_, string m) => m,
            Professor(_, string d) => d,
            _ => "UNKNOWN",
        };

    private static void CheckNotNull([NotNull]object? obj, [CallerArgumentExpression("obj")]string? expr = null)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(expr);
        }
    }

    [SupportedOSPlatform("windows")]
    private static void HiFromWindows()
    {
    }

    [SupportedOSPlatform("linux")]
    private static void HiFromLinux()
    {
    }

    private static void HighlightRegex([StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    {
    }
}
