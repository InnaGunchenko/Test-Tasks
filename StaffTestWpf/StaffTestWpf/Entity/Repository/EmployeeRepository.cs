using StaffTestWpf.DbAccess;
using StaffTestWpf.Entity.Domain;
namespace StaffTestWpf.Entity.Repository
{
    public class EmployeeRepository : DbRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    { }
}
