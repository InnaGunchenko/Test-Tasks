using ClosedXML.Excel;
using StaffTestWpf.Entity.Collection;
using StaffTestWpf.Entity.Domain;
using StaffTestWpf.Entity.Forms;
using StaffTestWpf.Entity.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StaffTestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        EmployeeForm employeeForm;
        bool isSearchPanelVisibility = false;
        StatisticsForm statisticsForm;

        string[] titles = new string[] { "ID", "Имя", "Адрес", "Дата рождения", "Телефон", "Должность", "Статус", "Зарплата", "Дата принятия", "Дата увольнения" };
        string connectionString;
        static EntityObservable<EmployeeView> employeeObservable;
        public static EntityObservable<EmployeeView> EmployeeObservable
        {
            get { return employeeObservable; }
            set { employeeObservable = value; }
        }

        public MainWindow()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            }
            catch
            {
                MessageBox.Show("Неверная строка подключения к бд в App.config");
                return;
            }

            InitializeComponent();
            searchPanel.Visibility = Visibility.Collapsed;
            employeeObservable = new ObservableLoader(connectionString).Collection;
            dgEmployee.ItemsSource = EmployeeObservable;
            titles.Select((t, i) => new { title = t, index = i }).ForEach(x => dgEmployee.Columns[x.index].Header = x.title);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            if (!isSearchPanelVisibility)
            {
                searchPanel.Visibility = Visibility.Visible;
                isSearchPanelVisibility = true;
            }
            else
            {
                searchPanel.Visibility = Visibility.Collapsed;
                isSearchPanelVisibility = false;
                dgEmployee.ItemsSource = EmployeeObservable;
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            EmployeeView list;
            try
            {
                id = Int32.Parse(tbSearch.Text);
                list = EmployeeObservable.Where(x => x.Id == id).First();
            }
            catch
            {
                return;
            }

            dgEmployee.ItemsSource = new List<EmployeeView> { list };
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            statisticsForm = new StatisticsForm();
            statisticsForm.ShowDialog();
        }

        private void btnDismiss_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployee.SelectedIndex != -1)
            {
                MainWindow.EmployeeObservable[dgEmployee.SelectedIndex].Status = 0;
                MainWindow.EmployeeObservable[dgEmployee.SelectedIndex].DateDismiss = DateTime.Now;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            row_DoubleClick(null, null);
        }

        private void row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgEmployee.SelectedIndex != -1)
            {
                employeeForm = new EmployeeForm(dgEmployee.SelectedItems[0].CastTo<EmployeeView>().Id);
                employeeForm.ShowDialog();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            EmployeeObservable.Clear();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            ExcelFile.Write(titles);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            ExcelFile.Read();
        }

    }
}
