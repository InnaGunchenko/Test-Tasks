using StaffTestWpf.Entity.Service;
using System.Collections.Generic;
using System.Windows;

namespace StaffTestWpf.Entity.Forms
{
    /// <summary>
    /// Interaction logic for StatisticsForm.xaml
    /// </summary>
    
    public partial class StatisticsForm : Window
    {
        public StatisticsForm()
        {
            InitializeComponent();
            txtStatistics.Text = string.Join("\n" , AddStatistics().ToArray());
        }

        List<string> AddStatistics()
        {
            List<string> statistics = new List<string>();
            statistics.Add(string.Format("Количество сотрудников : {0}", StatisticsData.CountEmployees));
            statistics.Add(string.Format("Средняя зп : {0}", StatisticsData.AverageSalary));
            return statistics;
        }
    }
}
