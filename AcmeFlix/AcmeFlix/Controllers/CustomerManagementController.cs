using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManagementController : Controller
    {
        private static List<CustomerManagement> customers = new List<CustomerManagement>
        {
            new CustomerManagement
            {
                Name = "Troy",
                Email = "Troy@gmail.com",
                PaymentMethods = new List<CreditCard>
                {
                    new CreditCard
                    {
                        Default = false,
                        CardHolderName = "Troy Nelson",
                        CardNumber = 1111222233334444,
                        ExpirationDate = new DateTime(2024, 12, 01)
                    },

                    new CreditCard
                    {
                        Default = true,
                        CardHolderName = "Troy Nelson",
                        CardNumber = 4444333322221111,
                        ExpirationDate = new DateTime(2027, 10, 01)
                    }
                }
            },

            new CustomerManagement
            {
                Name = "Justin",
                Email = "Justin@gmail.com",
                PaymentMethods = new List<CreditCard>
                {
                    new CreditCard
                    {
                        Default = false,
                        CardHolderName = "Justin Leiner",
                        CardNumber = 5555666677778888,
                        ExpirationDate = new DateTime(2023, 05, 01)
                    },

                    new CreditCard
                    {
                        Default = true,
                        CardHolderName = "Justin Leiner",
                        CardNumber = 8888777766665555,
                        ExpirationDate = new DateTime(2026, 07, 01)
                    }
                }

            }
        };

        /*
         * Get all the customers
         */
        [HttpGet]
        public async Task<ActionResult<List<CustomerManagement>>> Get()
        {
            return Ok(customers);
        }

        /*
         * Gets a customer based on email
         */
        [HttpGet("Email")]
        public async Task<ActionResult<List<CustomerManagement>>> Get(string email)
        {
            var customer = customers.Find(customer => customer.Email.ToLower().Trim() == email.ToLower().Trim());
            if (customer == null)
                return BadRequest("--Customer not found--");
            return Ok(customer);
        }

        /*
         * Adds a customer to the CustomerManagement list
         */
        [HttpPost]
        public async Task<ActionResult<List<CustomerManagement>>> AddCustomer(CustomerManagement customer)
        {
            var customerInList = customers.FirstOrDefault(c => c.Email.ToLower().Trim() == customer.Email.ToLower().Trim());
            if (customerInList == null)
            {
                customers.Add(customer);
                return Ok(customers);
            }
            else
            {
                return BadRequest("--Customer already exists");
            }
        }

        /*
         * Locates an existing customer and updates it
         */
        [HttpPut]
        public async Task<ActionResult<List<CustomerManagement>>> UpdateCustomer(CustomerManagement customerChanges)
        {
            var customer = customers.Find(c => c.Email.ToLower().Trim() == customerChanges.Email.ToLower().Trim());
            if (customer == null)
                return BadRequest("Customer not found.");

            customer.Name = customerChanges.Name;
            customer.Email = customerChanges.Email;


            //customer.VerifyCreditCardExpirations();

            

            return Ok(customers);
        }

        /*
         * Locates an existing customer using Email and deletes it
         */
        [HttpDelete("Email")]
        public async Task<ActionResult<CustomerManagement>> Delete (string Email)
        {
            var customer = customers.Find(c => c.Email.ToLower().Trim() == Email.ToLower().Trim());
            if (customer == null)
                return BadRequest("Customer not found.");
            customers.Remove(customer);
            return Ok(customers);
        }
    
    }
}

