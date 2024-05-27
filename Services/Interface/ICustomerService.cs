﻿using BusinessObjects;
using DataAccessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerById(int id);
        Task<Customer?> GetCustomerByEmail(string email);
        Task<Customer?> CheckLogin(string email, string password);
        Task<bool> UpdateProfile(Customer customer);
        Task AddCustomer(CustomerDTO customer);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(CustomerDTO customer);
        List<CustomerDTO> GetCustomers(Func<Customer, bool> predicate);
    }
}
