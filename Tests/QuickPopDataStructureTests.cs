using NUnit.Framework;
using QuickDataStructures.QuickDataStructure;

namespace QuickDataStructures.Tests;

[TestFixture]
public class QuickPopDataStructureTests
{
    private IQuickDataStructure<int> _dt1;
    private IQuickDataStructure<TestUser> _dt2;

    public QuickPopDataStructureTests()
    {
        _dt1 = new QuickPopDataStructure<int>();
        _dt2 = new QuickPopDataStructure<TestUser>();
    }

    #region Push

    #region Int

    [Test]
    public void Push_Int_SingleElement()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);

        // Assert
        Assert.That(Equals("5", _dt1.GetValues()));
    }

    [Test]
    public void Push_Int_MultipleElements()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);
        _dt1.Push(1);
        _dt1.Push(-3);
        _dt1.Push(9);
        _dt1.Push(0);

        // Assert
        Assert.That(Equals("9 5 1 0 -3", _dt1.GetValues()));
    }

    [Test]
    public void Push_Int_Length()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);
        _dt1.Push(1);
        _dt1.Push(-3);
        _dt1.Push(9);
        _dt1.Push(0);

        // Assert
        Assert.That(Equals(_dt1.Count(), 5));
    }

    [Test]
    public void Push_Int_MultiThread()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(1);
        _dt1.Push(2);
        _dt1.Push(-4);
        _dt1.Push(2);
        _dt1.Push(1);

        Task task1 = Task.Factory.StartNew(() =>
        {
            _dt1.Push(1);
            _dt1.Push(2);
            _dt1.Push(3);
            _dt1.Push(4);
            _dt1.Push(5);
        });
        Task task2 = Task.Factory.StartNew(() =>
        {
            _dt1.Push(1);
            _dt1.Push(2);
            _dt1.Push(3);
            _dt1.Push(4);
            _dt1.Push(5);
        });
        Task task3 = Task.Factory.StartNew(() =>
        {
            _dt1.Push(1);
            _dt1.Push(2);
            _dt1.Push(3);
            _dt1.Push(4);
            _dt1.Push(5);
        });
        Task.WaitAll(task1, task2, task3);

        // Assert
        Assert.That(Equals(_dt1.Count(), 20));
    }

    #endregion

    #region User

    [Test]
    public void Push_User_SingleElement()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));

        // Assert
        Assert.That(Equals("John", _dt2.GetValues()));
    }

    [Test]
    public void Push_User_MultipleElements()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        // Assert
        Assert.That(Equals("John Merry Jamie An CJ", _dt2.GetValues()));
    }

    [Test]
    public void Push_User_Length()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        // Assert
        Assert.That(Equals(_dt2.Count(), 5));
    }

    [Test]
    public void Push_User_MultiThread()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        Task task1 = Task.Factory.StartNew(() =>
        {
            _dt2.Push(new TestUser(6, "John"));
            _dt2.Push(new TestUser(7, "Merry"));
            _dt2.Push(new TestUser(8, "Jamie"));
            _dt2.Push(new TestUser(9, "An"));
            _dt2.Push(new TestUser(10, "CJ"));
        });
        Task task2 = Task.Factory.StartNew(() =>
        {
            _dt2.Push(new TestUser(11, "John"));
            _dt2.Push(new TestUser(12, "Merry"));
            _dt2.Push(new TestUser(13, "Jamie"));
            _dt2.Push(new TestUser(14, "An"));
            _dt2.Push(new TestUser(15, "CJ"));
        });
        Task task3 = Task.Factory.StartNew(() =>
        {
            _dt2.Push(new TestUser(16, "John"));
            _dt2.Push(new TestUser(17, "Merry"));
            _dt2.Push(new TestUser(18, "Jamie"));
            _dt2.Push(new TestUser(19, "An"));
            _dt2.Push(new TestUser(20, "CJ"));
        });
        Task.WaitAll(task1, task2, task3);

        // Assert
        Assert.That(Equals(_dt2.Count(), 20));
    }

    #endregion

    #endregion

    #region Pop

    #region Int

    [Test]
    public void Pop_Int_ThrowsInvalidOperationException()
    {
        // Arrange
        _dt1.Clear();

        // Assert
        Assert.Throws<InvalidOperationException>(() => _dt1.Pop());
    }

    [Test]
    public void Pop_Int_SingleElement()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);

        // Assert
        Assert.That(Equals(5, _dt1.Pop()));
    }

    [Test]
    public void Pop_Int_MultipleElements()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);
        _dt1.Push(1);
        _dt1.Push(-3);
        _dt1.Push(9);
        _dt1.Push(0);

        // Assert
        Assert.That(Equals(9, _dt1.Pop()));
        Assert.That(Equals(5, _dt1.Pop()));
        Assert.That(Equals(1, _dt1.Pop()));
        Assert.That(Equals(0, _dt1.Pop()));
        Assert.That(Equals(-3, _dt1.Pop()));
    }

    [Test]
    public void Pop_Int_Length()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(5);
        _dt1.Push(1);
        _dt1.Push(-3);
        _dt1.Push(9);
        _dt1.Push(0);

        _dt1.Pop();
        _dt1.Pop();
        _dt1.Pop();

        // Assert
        Assert.That(Equals(_dt1.Count(), 2));
    }

    [Test]
    public void Pop_Int_MultiThread()
    {
        // Arrange
        _dt1.Clear();

        // Act
        _dt1.Push(1);
        _dt1.Push(2);
        _dt1.Push(-4);
        _dt1.Push(2);
        _dt1.Push(1);

        Task task1 = Task.Factory.StartNew(() =>
        {
            _dt1.Push(1);
            _dt1.Push(2);
            _dt1.Push(3);
            _dt1.Push(4);
            _dt1.Push(5);
        });
        Task task2 = Task.Factory.StartNew(() =>
        {
            _dt1.Pop();
            _dt1.Pop();
            _dt1.Pop();
            _dt1.Pop();
            _dt1.Pop();
        });
        Task task3 = Task.Factory.StartNew(() =>
        {
            _dt1.Push(1);
            _dt1.Push(2);
            _dt1.Push(3);
            _dt1.Push(4);
            _dt1.Push(5);
        });
        Task.WaitAll(task1, task2, task3);

        // Assert
        Assert.That(Equals(_dt1.Count(), 10));
    }

    #endregion

    #region User

    [Test]
    public void Pop_User_ThrowsInvalidOperationException()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Assert
        Assert.Throws<InvalidOperationException>(() => _dt1.Pop());
    }

    [Test]
    public void Pop_User_SingleElement()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));

        // Assert
        Assert.That(Equals(1, _dt2.Pop().Id));
    }

    [Test]
    public void Pop_User_MultipleElements()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        // Assert
        Assert.That(Equals(5, _dt2.Pop().Id));
        Assert.That(Equals(4, _dt2.Pop().Id));
        Assert.That(Equals(3, _dt2.Pop().Id));
        Assert.That(Equals(2, _dt2.Pop().Id));
        Assert.That(Equals(1, _dt2.Pop().Id));
    }

    [Test]
    public void Pop_User_Length()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        _dt2.Pop();
        _dt2.Pop();
        _dt2.Pop();

        // Assert
        Assert.That(Equals(_dt2.Count(), 2));
    }

    [Test]
    public void Pop_User_MultiThread()
    {
        // Arrange
        _dt2 = new QuickPushDataStructure<TestUser>();

        // Act
        _dt2.Push(new TestUser(1, "John"));
        _dt2.Push(new TestUser(2, "Merry"));
        _dt2.Push(new TestUser(3, "Jamie"));
        _dt2.Push(new TestUser(4, "An"));
        _dt2.Push(new TestUser(5, "CJ"));

        Task task1 = Task.Factory.StartNew(() =>
        {
            _dt2.Push(new TestUser(6, "John"));
            _dt2.Push(new TestUser(7, "Merry"));
            _dt2.Push(new TestUser(8, "Jamie"));
            _dt2.Push(new TestUser(9, "An"));
            _dt2.Push(new TestUser(10, "CJ"));
        });
        Task task2 = Task.Factory.StartNew(() =>
        {
            _dt2.Pop();
            _dt2.Pop();
            _dt2.Pop();
            _dt2.Pop();
            _dt2.Pop();
        });
        Task task3 = Task.Factory.StartNew(() =>
        {
            _dt2.Push(new TestUser(11, "John"));
            _dt2.Push(new TestUser(12, "Merry"));
            _dt2.Push(new TestUser(13, "Jamie"));
            _dt2.Push(new TestUser(14, "An"));
            _dt2.Push(new TestUser(15, "CJ"));
        });
        Task.WaitAll(task1, task2, task3);

        // Assert
        Assert.That(Equals(_dt2.Count(), 10));
    }

    #endregion

    #endregion
}