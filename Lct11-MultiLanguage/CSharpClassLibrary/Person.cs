namespace CSharpClassLibrary;

public class Person : IPerson
{
    public string Name { get; set; }

    public Person(string name) => Name = name;

    public static Person GetDefault() => new(null);

    public void PrintName() => Console.WriteLine($"My name is {Name}");
    public void MakeFriend(IPerson person) => Console.WriteLine($"{Name} and {person.Name} are friends now!");
}
