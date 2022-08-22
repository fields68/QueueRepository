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

    [TestMethod]
    public void RemoveClaim()
    {
        // Arrange
        ClaimInfo claim = new ClaimInfo(ClaimInfo.Claim.Theft, "Jewerly missing from apartment. TV and laptop also stolen.", 6000.00m, new DateOnly(2022, 06, 25), new DateOnly(2022, 07, 01));
        bool actual = false;

        QueueRepository _repo = new QueueRepository();

        // Act
        _repo.AddNewClaim(claim);
        ClaimInfo delNext = _repo.DeleteClaim();
        bool expected = true;

        if (delNext != null)
        {
            actual = true;
        }
        else { actual = false; }

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TimeframeValid()
    {
        // Arrange
        ClaimInfo claim = new ClaimInfo();
        claim.DateOfIncident = new DateOnly(2022, 07, 01);
        claim.DateOfClaim = new DateOnly(2022, 08, 17);
        bool actual = false;

        int daysBetween = claim.DateOfClaim.DayNumber - claim.DateOfIncident.DayNumber;

        // Act
        bool expected = false;
        if (daysBetween <= 30)
        {
            actual = true;
        }
        else
        {
            actual = false;
        }

        // Assert
        Assert.AreEqual(expected, actual);
    }
}