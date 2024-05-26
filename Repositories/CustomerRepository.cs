using DataAccessObjects;
using BusinessObjects;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Customer?> GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);
    }
}
