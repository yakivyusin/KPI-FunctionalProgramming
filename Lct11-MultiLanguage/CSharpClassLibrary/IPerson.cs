namespace CSharpClassLibrary;

public interface IPerson
{
    string Name { get; }

    void MakeFriend(IPerson other);
}
