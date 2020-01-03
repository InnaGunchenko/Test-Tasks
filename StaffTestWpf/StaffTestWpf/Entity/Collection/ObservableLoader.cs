using StaffTestWpf.DbAccess;
using StaffTestWpf.Entity.Domain;
using StaffTestWpf.Entity.Repository;
using StaffTestWpf.Entity.Service;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StaffTestWpf.Entity.Collection
{
    public class ObservableLoader 
    {
        IDbFactory db;
        IEmployeeRepository repository;
        IEmployeeService service;
        EntityObservable<EmployeeView> entityObservable;

        public ObservableLoader(string connectionString)
        {
            this.db = new DbFactory(connectionString);
            this.repository = new EmployeeRepository(db);
            this.service = new EmployeeService(repository);
            entityObservable = new EntityObservable<EmployeeView>();
            service.Employees.ForEach(x => entityObservable.Add(new EmployeeView(x)));
            entityObservable.CollectionChanged += new NotifyCollectionChangedEventHandler(employees_CollectionChanged);
            entityObservable.ItemChanged += new EntityObservable<EmployeeView>.EntityChangedEventHandler(employees_ItemChanged);
        }

        public EntityObservable<EmployeeView> Collection { get { return entityObservable; } }

        void employees_ItemChanged(object sender, EntityChangedEventArgs<EmployeeView> args)
        {
            service.SaveOrUpdate(args.Item.InnerEmployee);
        }

        void employees_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (EmployeeView item in e.NewItems)
                    {
                        service.Save(item.InnerEmployee);
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    service.Reset();
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (EmployeeView item in e.OldItems)
                    {
                        service.Delete(item.InnerEmployee);
                    }
                    break;

                default:
                    foreach (EmployeeView item in e.NewItems)
                    {
                        service.SaveOrUpdate(item.InnerEmployee);
                    }
                    break;
            }
        }
    }
}