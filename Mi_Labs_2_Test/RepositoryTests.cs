using Mi_Labs_2;

public sealed class RepositoryTests
{
    [Test]
    public void Add_Item_AddsItemToCollection()
    {
        // Arrange
        var repository = new Mi_Labs_2.Repository<string>();
        var item = "test";

        // Act
        repository.Add(item);

        // Assert
        var contains = repository.Contains(item);
        Assert.That(contains, Is.True);
    }

    [Test]
    public void Clear_RemovesAllItemsFromCollection()
    {
        // Arrange
        var repository = new Repository<string>
            {
                "test1",
                "test2"
            };

        // Act
        repository.Clear();

        // Assert
        Assert.That(repository, Is.Empty);
    }

    [Test]
    public void Contains_ItemInCollection_ReturnsTrue()
    {
        // Arrange
        var repository = new Repository<string>();
        var item = "test";
        repository.Add(item);

        // Act
        var result = repository.Contains(item);

        // Assert
        Assert.True(result);
    }

    [Test]
    public void Contains_ItemNotInCollection_ReturnsFalse()
    {
        // Arrange
        var repository = new Repository<string>();
        var item = "test";

        // Act
        var result = repository.Contains(item);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CopyTo_CopiesItemsToArray()
    {
        // Arrange
        var repository = new Repository<string>
            {
                "test1",
                "test2"
            };
        var array = new string[2];

        // Act
        repository.CopyTo(array, 0);

        // Assert
        Assert.That(array, Is.EqualTo(new[] { "test1", "test2" }));
    }

    [Test]
    public void Remove_ItemInCollection_RemovesItemFromCollection()
    {
        // Arrange
        var repository = new Repository<string>();
        var item = "test";
        repository.Add(item);

        // Act
        var result = repository.Remove(item);

        // Assert
        Assert.True(result);
        var contains = repository.Contains(item);
        Assert.That(contains, Is.False);
    }

    [Test]
    public void Remove_ItemNotInCollection_ReturnsFalse()
    {
        // Arrange
        var repository = new Repository<string>();
        var item = "test";

        // Act
        var result = repository.Remove(item);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Find_ReturnsItemsMatchingCriteria()
    {
        // Arrange
        var repository = new Repository<string>
            {
                "test1",
                "test2",
                "test3"
            };

        // Act
        var result = repository.Find(item => item.StartsWith("test"));

        // Assert
        Assert.That(result.ToArray(), Is.EqualTo(new[] { "test1", "test2", "test3" }));
    }
}
