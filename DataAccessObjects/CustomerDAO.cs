using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDAO
    {
        public static async Task<Customer?> GetCustomerById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return await db.Customers.FirstOrDefaultAsync(c=>c.CustomerId.Equals(id));
        }
    }
}
