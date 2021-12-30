using ClaimsPocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public class ClaimsRepo
    {
        private readonly List<Claims> _claimsMainList = new List<Claims>();
        private int _count;

        public bool AddClaim(Claims claim)
        {
            if (claim == null)
            {
                return false;
            }
            else
            {
                _count++;
                claim.Id = _count;
                _claimsMainList.Add(claim);
                return true;
            }
        }
        public List<Claims> ClaimsMainList()
        {
            return _claimsMainList;
        }
    }   
}
