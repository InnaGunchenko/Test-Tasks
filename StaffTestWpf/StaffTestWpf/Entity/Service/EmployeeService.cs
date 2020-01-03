using StaffTestWpf.Entity.Domain;
using StaffTestWpf.Entity.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
namespace StaffTestWpf.Entity.Service
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; }
        void SaveOrUpdate(Employee employee);
        void Save(Employee employee);
        void Delete(Employee employee);
        void Reset();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        
        public List<Employee> Employees
        {
            get
            {
                return (List<Employee>)employeeRepository.GetAll();
            }
        }

        public void Reset()
        {
            Employees.ForEach(x => Delete(x));
        }

        public void Save(Employee employee)
        {
            employeeRepository.Save(employee);
        }

        public void SaveOrUpdate(Employee employee)
        {
            employeeRepository.SaveOrUpdate(employee);
        }

        public void Delete(Employee employee)
        {
            employeeRepository.Delete(employee);
        }
    }
}