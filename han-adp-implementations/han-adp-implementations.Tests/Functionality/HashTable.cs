using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class HashTable
{
    private class Person(string firstName, string lastName)
    {
        private string FirstName { get; } = firstName;
        private string LastName { get; } = lastName;

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
    
    private readonly Person _john = new("John", "Doe");
    private readonly Person _jane = new("Jane", "Doe");
    private readonly Person _joe = new("Joe", "Doe");
    
    [Fact]
    public void IsInsertAndGetWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Equal(_jane, newTable.Get(_jane.ToString()));
        Assert.Equal(_joe, newTable.Get(_joe.ToString()));
    }

    [Fact]
    public void IsDeleteWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        
        newTable.Delete(_jane.ToString());
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Null(newTable.Get(_jane.ToString()));
        Assert.Equal(_joe, newTable.Get(_joe.ToString()));
    }

    [Fact]
    public void IsUpdateWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        
        var newJoe = new Person("Joseph", "Doe");
        
        newTable.Update(_joe.ToString(), newJoe);
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Equal(_jane, newTable.Get(_jane.ToString()));
        Assert.Equal(newJoe, newTable.Get(_joe.ToString()));
    }
}