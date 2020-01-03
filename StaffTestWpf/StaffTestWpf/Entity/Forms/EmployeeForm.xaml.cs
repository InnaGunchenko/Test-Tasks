using StaffTestWpf.Entity.Collection;
using StaffTestWpf.Entity.Domain;
using System;
using System.Windows;
using System.Windows.Data;

namespace StaffTestWpf.Entity.Forms
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        private int? id = null;
        public EmployeeForm()
        {
            InitializeComponent();
            
        }

        public EmployeeForm(int id)
            : this()
        {
            this.id = id;
            foreach (EmployeeView item in MainWindow.EmployeeObservable)
            {
                if (item.Id == id)
                {
                    mainGrid.DataContext = item;
                    break;
                }
            }

        }

        public EmployeeView StoreEmployee()
        {
            EmployeeView employee = new EmployeeView();
            employee.FullName = tbFullName.Text;
            employee.Addres = tbAddres.Text;
            employee.Phone = tbPhone.Text;
            employee.BirthDate = dBirthDate.SelectedDate.HasValue ? dBirthDate.SelectedDate.Value : DateTime.Now;
            employee.VacantPosition = tbVacantPosition.Text;
            employee.Status = 1;
            decimal salary = 0;
            employee.Salary = decimal.TryParse(tbSalary.Text, out salary) ? salary : 0;
            employee.DateStart = dDateStart.SelectedDate.HasValue ? dDateStart.SelectedDate.Value : DateTime.Now;
            return employee;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!id.HasValue)
            {
                MainWindow.EmployeeObservable.Add(StoreEmployee());
            }
            
            employeeForm.Close();
        }

    }
}
