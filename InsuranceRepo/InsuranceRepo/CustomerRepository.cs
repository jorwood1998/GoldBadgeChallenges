using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo
{
    public class CustomerRepository
    {
        private int _count;
        private readonly List<Customer> _listOfCusotmers = new List<Customer>();

        //Create
        public bool AddCustomerToRepo(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            else
            {
                _count++;
                customer.ID = _count;
                _listOfCusotmers.Add(customer);
                return true;
            }
        }
        //Read
        public List<Customer> GetFullCustomerList()
        {
            return _listOfCusotmers;
        }
        public string CreateMessage()
        {
            string message;
            foreach (Customer customer in _listOfCusotmers)
            {
                if (customer.YearsEnrolled == 1)
                {
                    message = ("Thank you for a year!");
                    SendMessage(message);
                }
                if (customer.YearsEnrolled >= 2 && customer.YearsEnrolled < 5)
                {
                    message = ("Thank you for your time with us, I love you");
                    SendMessage(message);
                }
                if (customer.YearsEnrolled >= 5)
                {
                    message = ("Thank you for being a gold member");
                    SendMessage(message);
                }
                else message = "none";
            }
        }
        public bool SendMessage(string messageSent)
        {
            Console.WriteLine(messageSent);
            return true;
        }
        //Update
        public bool UpdateCustomer (int id, Customer updatedCustomer)
        {
            Customer customer = _listOfCusotmers[id];
            if (customer != null)
            {
                customer.ID = updatedCustomer.ID;
                customer.LastName = updatedCustomer.LastName;
                customer.DoB = updatedCustomer.DoB;
                customer.JoinDate = updatedCustomer.JoinDate;
                return true;
            }
            else { return false; }
        }
        //Delete
        public bool DeleteCustomer(Customer customer)
        {
            bool deleteResult = _listOfCusotmers.Remove(customer);
            return deleteResult;
        }

    }
}
