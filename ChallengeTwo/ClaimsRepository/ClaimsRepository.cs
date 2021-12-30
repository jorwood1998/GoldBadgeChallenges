using ClaimsPoco;
using System.Collections.Generic;

namespace ClaimsRepo
{
    public class Claims_Repository
    {
        public readonly Queue<Claim> _claimsDirectory = new Queue<Claim>();
        public Queue<Claim> GetAllClaims()  //get all the claims
        {
            return _claimsDirectory;
        }
        public Claim GetNextClaim()
        {
            Claim claim = _claimsDirectory.Peek();
            return claim;
        }
        public void ClearClaimList()
        {
            _claimsDirectory.Clear();

        }
        public void EnterNewClaim(Claim claim)
        {
            _claimsDirectory.Enqueue(claim);
        }
        public bool RemoveClaim()
        {
            if (_claimsDirectory.Count > 0)
            {
                _claimsDirectory.Dequeue();
                return true;
            }
            return false;
        }
    }
}
