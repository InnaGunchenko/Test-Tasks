using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace StaffTestWpf.DbAccess
{
    public interface IDbFactory
    {
        ISession Open();
    }

    public class DbFactory : IDbFactory
    {
        private ISessionFactory sessionFactory;
        private Configuration configuration;
        private string connectionString;
        public DbFactory(string connectionString)
        {
            this.connectionString = connectionString;
            configuration = new Configuration().DataBaseIntegration(db =>
               {
                   try
                   {
                       db.ConnectionString = connectionString;
                       db.Dialect<MsSql2005Dialect>();
                   }
                   catch
                   {
                       return;
                   }
               });
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    ModelMapper mapper = new ModelMapper();
                    mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                    HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                    configuration.AddMapping(mapping);
                    new SchemaUpdate(configuration).Execute(true, true);
                    sessionFactory = configuration.BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        public ISession Open()
        {
            return SessionFactory.OpenSession();
        }
    }
}