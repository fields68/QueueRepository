using Queue_Repository;

namespace Queue_Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void SetCorrectDescription()
    {
        // Arrange
        ClaimInfo claim = new ClaimInfo();
        claim.Description = "Stolen computer.";

        // Act
        string expected = "Stolen computer.";
        string actual = claim.Description;

        // Assert
        Assert.AreEqual(expected, actual);
    }
}