namespace Queue_Repository;

public class QueueRepository
{
    protected readonly Queue<ClaimInfo> _claim = new Queue<ClaimInfo>();

    public bool AddNewClaim(ClaimInfo claim)
    {
        int prevCount = _claim.Count;

        _claim.Enqueue(claim);

        return prevCount < _claim.Count ? true : false;
    }

    public ClaimInfo NextClaim()
    {

        return _claim.Peek();
    }
    public Queue<ClaimInfo> GetAllClaims()
    {
        return _claim;
    }
    public ClaimInfo DeleteClaim()
    {
        return _claim.Dequeue();

    }
}