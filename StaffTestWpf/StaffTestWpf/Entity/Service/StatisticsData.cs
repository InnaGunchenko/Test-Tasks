using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffTestWpf.Entity.Service
{
    public static class StatisticsData
    {
        static decimal salary = 0;
        public static int CountEmployees 
        {
            get { return MainWindow.EmployeeObservable.Count; }
        }

        public static decimal AverageSalary
        {
            get
            {
                try
                {
                    foreach (var employee in MainWindow.EmployeeObservable)
                    {
                        salary += employee.Salary;
                    }

                    salary = salary / MainWindow.EmployeeObservable.Count;
                }
                catch
                {
                    return 0;
                }

                return Math.Round(salary, 3);
            }
        }
    }
}
