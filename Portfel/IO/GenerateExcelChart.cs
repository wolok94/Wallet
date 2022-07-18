
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Portfel.Model;
using Portfel.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Portfel.IO
{
    public class GenerateExcelChart
    {
        private ConnectWithSql sql = new ConnectWithSql();
        private readonly string path = @"E:\Programowanie\Ćwiczenia\Portfel\Raport.xlsx";
        public async Task Generate()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);
            var expenses = GetData();

            await SaveExcelFile(expenses, file);
            
            

        }
        // this method creates an excel file, enters data in it and creates a chart based on it
        private async Task SaveExcelFile(List<ExpenseDto> expenses, FileInfo file)
        {
            DeleteIfExists(file);

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A2"].LoadFromCollection(expenses, true);
            range.AutoFitColumns();

            var headerFeesExpense = ws.Cells[$"A{expenses.Count + 4}"].LoadFromText("Opłaty");
            var countedFeesExpense = ws.Cells[$"A{expenses.Count + 5}"]
                .LoadFromText(sql.getExpenseByProductName(Wallet.actuallyUser, "Opłaty").ToString());

            var headerFoodExpense = ws.Cells[$"B{expenses.Count + 4}"].LoadFromText("Produkty spożywcze");
            var countedFoodExpense = ws.Cells[$"B{expenses.Count + 5}"]
            .LoadFromText(sql.getExpenseByProductName(Wallet.actuallyUser, "Produkty Spożywcze").ToString());

            var headerCleaningExpense = ws.Cells[$"C{expenses.Count + 4}"].LoadFromText("Środki czyszczące");
            var countedCleaningExpense = ws.Cells[$"C{expenses.Count + 5}"]
            .LoadFromText(sql.getExpenseByProductName(Wallet.actuallyUser, "Środki czyszczące").ToString());

            var headerFExpense = ws.Cells[$"D{expenses.Count + 4}"].LoadFromText("Paliwo");
            var countedFuelExpense = ws.Cells[$"D{expenses.Count + 5}"]
            .LoadFromText(sql.getExpenseByProductName(Wallet.actuallyUser, "Paliwo").ToString());

            ws.Cells["A1"].Value = "Raport wydatków";
            ws.Cells["A1:C1"].Merge = true;
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Color.SetColor(Color.Blue);

            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Bold = true;

            var chart = ws.Drawings.AddChart("Wykres", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
            chart.XAxis.Title.Text = "Produkt";
            chart.YAxis.Title.Text = "Kwota";
            chart.SetSize(1200, 300);
            chart.SetPosition(1, 0, 5, 0);

            
            var value = chart.Series.Add($"A{expenses.Count + 5}:D{expenses.Count + 5}", $"A{expenses.Count + 4}:D{expenses.Count + 4}");
            await package.SaveAsync();
            
             OpenFile();
               }
        // this method opens the excel file
        private void OpenFile()
        {
            var proc = new Process();
            proc.StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true
            };
            proc.Start();
        }
        // this mettodh removes the excel file if it exists
        private void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
        // this method retrieves data from database and maps expenses from database on expensedto
        private List<ExpenseDto> GetData()
        {
            List<ExpenseDto> expenses = new List<ExpenseDto>();
            DataTable table = new DataTable();
            table = sql.getExpenses(Wallet.actuallyUser);
            var results = table.Rows.Cast<DataRow>().Where(x=> x.Field<int>("UserId") == Wallet.actuallyUser.Id).ToList();
            
            foreach (DataRow row in results)
            {

                    double value = double.Parse(row.ItemArray[1].ToString());
                    string productName = row.ItemArray[4].ToString();
                    DateTime date = Convert.ToDateTime(row.ItemArray[3].ToString());
                    string formatedDate = string.Format("{0:dd-MM-yyyy}",date);
                    ExpenseDto expense = new ExpenseDto(value, productName, formatedDate);
                    expenses.Add(expense);
            }
            return expenses;

            
        }
    }
}
