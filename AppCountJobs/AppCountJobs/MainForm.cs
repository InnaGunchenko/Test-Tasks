using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AppCountJobs
{
    public partial class MainForm : Form
    {
        Browser browser;
        public MainForm()
        {
            browser = new Browser("https://careers.veeam.com/", NameConstants.Romania, NameConstants.English);
            browser.Load();
            browser.Maximize();
            if (!browser.CheckBrowser("Career at Veeam Software"))
                return;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void LoadControls()
        {
            string[] countrys = browser.FirstLoad(browser.DropDownCountrys, browser.Countrys);
            browser.Wait();
            string[] languages = browser.FirstLoad(browser.DropDownLanguages, browser.Languages);
            LoadComboBox(cbCountrys, countrys, browser.DropDownCountrys.name);
            LoadComboBox(cbLanguages, languages, browser.DropDownLanguages.name);
        }

        private void btCalculateJobs_Click(object sender, EventArgs e)
        {
            int jobsInput = string.IsNullOrWhiteSpace(tbJobsInput.Text) ? 0 : Convert.ToInt32(tbJobsInput.Text);
            string language = cbLanguages.SelectedItem.ToString();
            string country = cbCountrys.SelectedItem.ToString();
            try
            {
                int jobsFound = browser.CalcJobs(language, country);
                MessageBox.Show(CompareCountJobs(jobsInput, jobsFound));
            }
            catch
            {
                return;
            }
        }

        private void tbJobsInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        public string CompareCountJobs(int jobsInput, int jobsFound)
        {
            string result = string.Empty;
            if (jobsFound.Equals(jobsInput))
                result = string.Format("jobs found = jobs input = {0}", jobsFound);
            else if (jobsFound > jobsInput)
                result = string.Format("jobs found ({0}) > jobs input ({1})", jobsFound, jobsInput);
            else
                result = string.Format("jobs found ({0}) < jobs input ({1})", jobsFound, jobsInput);
            return result;
        }

        public void LoadComboBox(ComboBox cb, string[] values, string nameElement)
        {
            if (values == null)
                return;
            cb.Items.AddRange(values);
            cb.SelectedIndex = cb.Items.IndexOf(nameElement);
        }
    }
}