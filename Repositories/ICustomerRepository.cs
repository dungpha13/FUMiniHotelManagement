using BusinessObjects;

namespace Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerById(int id);
    }
}
