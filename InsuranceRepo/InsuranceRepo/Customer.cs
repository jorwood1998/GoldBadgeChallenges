using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo
{
    public class Customer
    {
        public Customer(int id, string lastName, DateTime dateOfBirth, DateTime joinDate)
        {
            ID = id;
            LastName = lastName;
            JoinDate = joinDate;
            DoB = dateOfBirth;
        }
        public int ID { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public int Age { 
            get
            {
                int age = DateTime.Now.Year - DoB.Year;
                return age;
            }
            
        }
        public DateTime JoinDate { get; set; }
        public int YearsEnrolled 
        {
            get 
            {
                int yearsEnrolled = DateTime.Now.Year - JoinDate.Year;
                return yearsEnrolled;
            }

        }
    }
}
