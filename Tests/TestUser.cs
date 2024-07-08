namespace QuickDataStructures.Tests;

public class TestUser : IComparable<TestUser>
{
    public int Id { get; private set; }
    public string Name { get; set; }

    public TestUser(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public int CompareTo(TestUser other)
    {
        if (other == null)
        {
            return 1;
        }

        return Id.CompareTo(other.Id);
    }
}