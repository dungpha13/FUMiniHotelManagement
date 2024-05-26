using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _repo.GetCustomerById(id);
        }
    }
}
