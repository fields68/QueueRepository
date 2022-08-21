namespace Queue_Repository;
public class ClaimInfo
{
    /*
        Each Claim will need (POCO): 
            — ClaimType (Car, Home, or Theft)
            — Description
            — ClaimAmount
            — DateOfIncident
            — DateOfClaim
            — IsValid (based on the date of the claim and the date of the incident (30 days after incident))

        The app will need to (repo methods): 
            — Add a new claim (C)
            — View the next claim (R)
            — See a list of all claims (R)
            — Process (remove) the next claim (D)
    */

    public ClaimInfo() { }

    public ClaimInfo(Claim claimType, string description, decimal claimAmount, DateOnly dateOfIncident, DateOnly dateOfClaim)
    {
        ClaimType = claimType;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }
    public Claim ClaimType { get; set; }
    public string Description { get; set; }

    public decimal ClaimAmount { get; set; }

    public DateOnly DateOfIncident { get; set; }

    public DateOnly DateOfClaim { get; set; }

    public bool IsValid
    {
        get
        {
            int daysBetween = DateOfClaim.DayNumber - DateOfIncident.DayNumber;

            if (daysBetween <= 30)
            {
                return true;
            }
            else { return false; }
        }
    }

    public enum Claim
    {
        Car = 1, Home, Theft
    }
}
