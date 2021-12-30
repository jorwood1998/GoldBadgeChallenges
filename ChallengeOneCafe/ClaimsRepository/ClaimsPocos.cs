using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsPoco
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft,
            Other
        }
        public Claim() { }
        public Claim(int id, ClaimType claimType, string desc, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = id;
            TypeOfClaim = claimType;
            Description = desc;
            ClaimsAmount = claimAmount;
            IncidentDate = dateOfIncident;
            ClaimsDate = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimsAmount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimsDate { get; set; }
        public bool IsValid 
        {
           get
           {
            var span = ClaimsDate - IncidentDate;
            if (span.TotalDays > 30)
            {
            return false;
            }
            return true;
           }
        }
        public override string ToString()
        {
            return $"{ClaimID}\n" +
                $"{TypeOfClaim}\n" +
                $"{Description}\n" +
                $"{IncidentDate}\n" +
                $"{ClaimsDate}\n" +
                $"{ClaimsAmount}\n" +
                $"{IsValid}\n";

        }
    }

}
