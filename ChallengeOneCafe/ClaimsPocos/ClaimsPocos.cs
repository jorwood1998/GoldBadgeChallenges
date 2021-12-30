using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsPocos
{
    public class Claims
    {
        static void Main(string[] args)
        {
            programUI program = new programUI();
            program.Run();
        }
        public Claims() { }
        public Claims(int id, string claimType, string desc, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            Id = id;
            TypeOfClaim = claimType;
            Description = desc;
            ClaimsAmount = claimAmount;
            IncidentDate = dateOfIncident;
            ClaimsDate = dateOfClaim;
            IsValid = isValid;
        }
        public int Id { get; set; }
        public string TypeOfClaim { get; set;}
        public string Description { get; set; }
        public double ClaimsAmount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimsDate { get; set; }
        public bool IsValid { get; set; }



    }
}
