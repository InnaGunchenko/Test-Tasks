using ClosedXML.Excel;
using Microsoft.Win32;
using StaffTestWpf.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffTestWpf.Entity.Service
{
    public static class ExcelFile
    {
        public static void Write(string[] titles)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                worksheet.Row(1).Style.Font.Bold = true;
                titles.Select((t, i) => new { title = t, index = i + 1 }).ForEach(x => worksheet.Cell(1, x.index).Value = x.title);

                for (int i = 0; i < MainWindow.EmployeeObservable.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = MainWindow.EmployeeObservable[i].Id;
                    worksheet.Cell(i + 2, 2).SetValue<string>(Convert.ToString(MainWindow.EmployeeObservable[i].FullName));
                    worksheet.Cell(i + 2, 3).SetValue<string>(Convert.ToString(MainWindow.EmployeeObservable[i].Addres));
                    worksheet.Cell(i + 2, 4).SetValue<string>(MainWindow.EmployeeObservable[i].BirthDate.ToShortDateString());
                    worksheet.Cell(i + 2, 5).SetValue<string>(Convert.ToString(MainWindow.EmployeeObservable[i].Phone));
                    worksheet.Cell(i + 2, 6).SetValue<string>(Convert.ToString(MainWindow.EmployeeObservable[i].VacantPosition));
                    worksheet.Cell(i + 2, 7).Value = MainWindow.EmployeeObservable[i].Status;
                    worksheet.Cell(i + 2, 8).Value = MainWindow.EmployeeObservable[i].Salary;
                    worksheet.Cell(i + 2, 9).SetValue<string>(MainWindow.EmployeeObservable[i].DateStart.ToShortDateString());
                    worksheet.Cell(i + 2, 10).SetValue<string>(MainWindow.EmployeeObservable[i].DateDismiss.HasValue ?
                        Convert.ToString(MainWindow.EmployeeObservable[i].DateDismiss.Value.ToShortDateString()) : string.Empty);
                }

                workbook.SaveAs(GenerateOutFilePath());
            }
        }

        public static void Read()
        {
            bool isFirstRow = true;
            string filePath;

            filePath = GenerateInFilePath();
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            MainWindow.EmployeeObservable.Clear();
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    using (IXLWorksheet worksheet = workbook.Worksheets.Worksheet(1))
                    {
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (isFirstRow)
                            {
                                isFirstRow = false;
                                continue;
                            }

                            EmployeeView item = new EmployeeView();
                            item.FullName = row.Cell(2).GetValue<string>();
                            item.Addres = row.Cell(3).GetValue<string>();
                            item.BirthDate = Convert.ToDateTime(row.Cell(4).GetValue<string>());
                            item.Phone = row.Cell(5).GetValue<string>();
                            item.VacantPosition = row.Cell(6).GetValue<string>();
                            item.Status = row.Cell(7).GetValue<byte>();
                            item.Salary = string.IsNullOrWhiteSpace(row.Cell(8).GetValue<string>()) ? 0 : row.Cell(8).GetValue<decimal>();
                            item.DateStart = Convert.ToDateTime(row.Cell(9).GetValue<string>());
                            item.DateDismiss = string.IsNullOrWhiteSpace(row.Cell(10).GetValue<string>()) ? (DateTime?)null :
                                Convert.ToDateTime(row.Cell(10).GetValue<string>());
                            MainWindow.EmployeeObservable.Add(item);
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        static string GenerateOutFilePath()
        {
            string filePath = ".";
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Сохранить как...",
                FileName = "Employees",
                OverwritePrompt = false
            };

            if (saveFileDialog.ShowDialog() == true)
                filePath = saveFileDialog.FileName;

            return filePath;
        }

        static string GenerateInFilePath()
        {
            string filePath = ".";
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Excel files|*.xlsx"
            };
            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;
            return filePath;
        }
    }
}
