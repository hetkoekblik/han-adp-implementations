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
    private readonly Person _joseph = new("Joseph", "Doe");
    private readonly Person _jose = new("Jose", "Doe");
    private readonly Person _josef = new("Josef", "Doe");
    private readonly Person _josephine = new("Josephine", "Doe");
    
    [Fact]
    public void IsInsertAndGetWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        newTable.Insert(_joseph.ToString(), _joseph);
        newTable.Insert(_jose.ToString(), _jose);
        newTable.Insert(_josef.ToString(), _josef);
        newTable.Insert(_josephine.ToString(), _josephine);
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Equal(_jane, newTable.Get(_jane.ToString()));
        Assert.Equal(_joe, newTable.Get(_joe.ToString()));
        Assert.Equal(_joseph, newTable.Get(_joseph.ToString()));
        Assert.Equal(_jose, newTable.Get(_jose.ToString()));
        Assert.Equal(_josef, newTable.Get(_josef.ToString()));
        Assert.Equal(_josephine, newTable.Get(_josephine.ToString()));
    }

    [Fact]
    public void IsDeleteWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        newTable.Insert(_joseph.ToString(), _joseph);
        newTable.Insert(_jose.ToString(), _jose);
        newTable.Insert(_josef.ToString(), _josef);
        newTable.Insert(_josephine.ToString(), _josephine);
        
        newTable.Delete(_jane.ToString());
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Null(newTable.Get(_jane.ToString()));
        Assert.Equal(_joe, newTable.Get(_joe.ToString()));
        Assert.Equal(_joseph, newTable.Get(_joseph.ToString()));
        Assert.Equal(_jose, newTable.Get(_jose.ToString()));
        Assert.Equal(_josef, newTable.Get(_josef.ToString()));
        Assert.Equal(_josephine, newTable.Get(_josephine.ToString()));
        
        newTable.Delete(_jose.ToString());
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Null(newTable.Get(_jane.ToString()));
        Assert.Equal(_joe, newTable.Get(_joe.ToString()));
        Assert.Equal(_joseph, newTable.Get(_joseph.ToString()));
        Assert.Null(newTable.Get(_jose.ToString()));
        Assert.Equal(_josef, newTable.Get(_josef.ToString()));
        Assert.Equal(_josephine, newTable.Get(_josephine.ToString()));
    }

    [Fact]
    public void IsUpdateWorking()
    {
        var newTable = new DataStructures.Others.HashTable<string, Person>();
        
        newTable.Insert(_john.ToString(), _john);
        newTable.Insert(_jane.ToString(), _jane);
        newTable.Insert(_joe.ToString(), _joe);
        newTable.Insert(_joseph.ToString(), _joseph);
        newTable.Insert(_jose.ToString(), _jose);
        newTable.Insert(_josef.ToString(), _josef);
        newTable.Insert(_josephine.ToString(), _josephine);
        
        var newJoe = new Person("Joseph", "Doe");
        
        newTable.Update(_joe.ToString(), newJoe);
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Equal(_jane, newTable.Get(_jane.ToString()));
        Assert.Equal(newJoe, newTable.Get(_joe.ToString()));
        Assert.Equal(_joseph, newTable.Get(_joseph.ToString()));
        Assert.Equal(_jose, newTable.Get(_jose.ToString()));
        Assert.Equal(_josef, newTable.Get(_josef.ToString()));
        Assert.Equal(_josephine, newTable.Get(_josephine.ToString()));
        
        var newJose = new Person("Jose", "Doe");
        
        newTable.Update(_jose.ToString(), newJose);
        
        Assert.Equal(_john, newTable.Get(_john.ToString()));
        Assert.Equal(_jane, newTable.Get(_jane.ToString()));
        Assert.Equal(newJoe, newTable.Get(_joe.ToString()));
        Assert.Equal(_joseph, newTable.Get(_joseph.ToString()));
        Assert.Equal(newJose, newTable.Get(_jose.ToString()));
        Assert.Equal(_josef, newTable.Get(_josef.ToString()));
        Assert.Equal(_josephine, newTable.Get(_josephine.ToString()));
    }
}