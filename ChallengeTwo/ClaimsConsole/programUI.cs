using ClaimsRepo;
using ClaimsPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClaimsPoco.Claim;

namespace ClaimsConsole
{
    public class ProgramUI
    {
        public void Run()
        {
            Seed();
            RunApplication();
        }

        public readonly Claims_Repository _repo = new Claims_Repository();

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Claims Adjustment \n" +
                    "1. See All Claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter A New Claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select from the following...");
                        WaitForKey();
                        break;
                }
                Console.Clear();
            }
        }


        private void GetAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _repo.GetAllClaims();
            foreach (Claim claim in claims)
            {
                Console.WriteLine(claim.ToString());
            }
        }
        public void NextClaim()
        {
            Console.Clear();
            var nextClaim = _repo.GetNextClaim();
            Console.WriteLine(nextClaim.ToString());

            Console.WriteLine("Do you want to deal with this claim now y/n?");
            string response = Console.ReadLine();


            if (response == "Y".ToLower())
            {
                var success = _repo.RemoveClaim();
                if (success)
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            WaitForKey();
        }

        private void WaitForKey()
        {
            Console.ReadKey();
        }
        public void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

            Console.WriteLine("Enter claim ID");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter claim Type:\n" +
                "1.Car\n " +
                "2.Home\n" +
                "3.Theft\n " +
                "4.Other\n");
            int userInput = int.Parse(Console.ReadLine());
            var convert = (ClaimType)userInput;
            claim.TypeOfClaim = convert;

            Console.WriteLine("Enter Description");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Enter amount for claim");
            claim.ClaimsAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("When was this?");
            claim.IncidentDate = Convert.ToDateTime(Console.ReadLine());
            claim.ClaimsDate = DateTime.Now;

            _repo.EnterNewClaim(claim);
        }

        private void Seed()
        {
            DateTime dateOfIncident = new DateTime(2021, 01, 18);
            DateTime dateOfClaim = new DateTime(2021, 02, 4);
            Claim claimOne = new Claim(1, ClaimType.Car, "Car Accident.", 1600m, dateOfIncident, dateOfClaim, true);
            _repo.EnterNewClaim(claimOne);

            DateTime dateOfIncidentTwo = new DateTime(2018, 04, 11);
            DateTime dateOfClaimTwo = new DateTime(2020, 12, 12);
            Claim claimTwo = new Claim(2, ClaimType.Theft, "Did someone steal your sweetroll?", 5m, dateOfIncidentTwo, dateOfClaimTwo, false);
            _repo.EnterNewClaim(claimTwo);

            DateTime dateOfIncidentThree = new DateTime(2019, 04, 4);
            DateTime dateOfClaimThree = new DateTime(2019, 05, 06);
            Claim claimThree = new Claim(3, ClaimType.Home, "Tornado", 30000m, dateOfIncidentThree, dateOfClaimThree, true);
            _repo.EnterNewClaim(claimThree);
        }
    }
}