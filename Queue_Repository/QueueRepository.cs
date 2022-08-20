namespace Queue_Repository;

public class QueueRepository
{
    protected readonly List<ClaimInfo> _claim = new List<ClaimInfo>();

    public bool AddNewClaim(ClaimInfo claim)
    {
        int prevCount = _claim.Count;

        _claim.Add(claim);

        return prevCount < _claim.Count ? true : false;
    }

    public List<ClaimInfo> ViewNextClaim()
    {
        return _claim;
    }
    public List<ClaimInfo> GetAllClaims()
    {
        return _claim;
    }
    // public bool DeleteClaim() {
    //     ClaimInfo itemToDelete = _claim;

    //     bool deleteResult = _claim.Remove(itemToDelete);

    //     return deleteResult;
    // }
}