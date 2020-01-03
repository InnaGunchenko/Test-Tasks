using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using StaffTestWpf.Entity.Domain;

namespace StaffTestWpf.Entity.Mapping
{
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.FullName);
            Property(x => x.Addres);
            Property(x => x.BirthDate);
            Property(x => x.Phone);
            Property(x => x.VacantPosition);
            Property(x => x.Status);
            Property(x => x.Salary);
            Property(x => x.DateStart);
            Property(x => x.DateDismiss);
        }
    }
}
