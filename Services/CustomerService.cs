using BusinessObjects;
using DataAccessObjects.DTO;
using Repositories;
using Repositories.Interface;
using Services.Interface;
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

        public async Task AddCustomer(CustomerDTO customer) => await _repo.AddCustomer(customer);

        public async Task<Customer?> CheckLogin(string email, string password)
        {
            Customer? customer = await GetCustomerByEmail(email);

            if (customer == null || !customer.Password.Equals(password))
            {
                return null;
            }

            return customer;
        }

        public async Task DeleteCustomer(int id) => await _repo.DeleteCustomer(id);

        public async Task<Customer?> GetCustomerByEmail(string email) => await _repo.GetCustomerByEmail(email);

        public async Task<Customer?> GetCustomerById(int id) => await _repo.GetCustomerById(id);

        public List<CustomerDTO> GetCustomers(Func<Customer, bool> predicate) => _repo.GetCustomers(predicate);

        public async Task UpdateCustomer(CustomerDTO customer) => await _repo.UpdateCustomer(customer);

        public async Task<bool> UpdateProfile(Customer customer) => await _repo.UpdateCustomer(customer);
    }
}
