using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StaffTestWpf.Entity.Domain
{
    public class Employee 
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Addres { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Phone { get; set; }
        public virtual string VacantPosition { get; set; }
        public virtual byte Status { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime? DateDismiss { get; set; }
    }

    public class EmployeeView : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        private Employee employee;
        public Employee InnerEmployee { get { return employee; } }

        public EmployeeView()
        {
            employee = new Employee();
        }

        public EmployeeView(Employee employee)
        {
            this.employee = employee;
        }

        public virtual int Id
        {
            get { return employee.Id; }
            set
            {
                employee.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public virtual string FullName
        {
            get { return employee.FullName; }
            set
            {
                employee.FullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public virtual string Addres
        {
            get { return employee.Addres; }
            set
            {
                employee.Addres = value;
                OnPropertyChanged("Addres");
            }
        }

        public virtual DateTime BirthDate
        {
            get { return employee.BirthDate; }
            set
            {
                employee.BirthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public virtual string Phone
        {
            get { return employee.Phone; }
            set
            {
                employee.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public virtual string VacantPosition
        {
            get { return employee.VacantPosition; }
            set
            {
                employee.VacantPosition = value;
                OnPropertyChanged("VacantPosition");
            }
        }

        public virtual byte Status
        {
            get { return employee.Status; }
            set
            {
                employee.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public virtual decimal Salary
        {
            get { return employee.Salary; }
            set
            {
                employee.Salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public virtual DateTime DateStart
        {
            get { return employee.DateStart; }
            set
            {
                employee.DateStart = value;
                OnPropertyChanged("DateStart");
            }
        }

        public virtual DateTime? DateDismiss
        {
            get { return employee.DateDismiss; }
            set
            {
                employee.DateDismiss = value;
                OnPropertyChanged("DateDismiss");
            }
        }

        protected void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

    }
}