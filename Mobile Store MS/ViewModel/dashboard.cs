using Mobile_Store_MS.Data;
using Mobile_Store_MS.ViewModel.Administrator;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class dashboard
    {
        public dashboard()
        {
            Purchasing = new List<PurchasingViewModel.PurchasingViewModel>();
            Orders = new List<OrderViewModel>();
            Stores = new List<StoreStats>();
            User = new List<ApplicationUser>();
            Employees = new List<RegisterEmployeeViewModel>();
            Sales = new List<Graph>();
            Purchasings = new List<Graph>();
            CompaniesData = new List<GroupByCompany>();
        }
        public List<ApplicationUser> User { get; set; }
        public int TotalUsers { get; set; }

        public List<RegisterEmployeeViewModel> Employees { get; set; }
        public int TotalEmployees { get; set; }

        public List<StoreStats> Stores { get; set; }

        public List<OrderViewModel> Orders { get; set; }
        public double LastMonthSales { get; set; }
        public double TotalSales { get; set; }
        public int TotalSalesCount { get; set; }
        public double MonthlyProfit { get; set; }
        public double TotalProfit { get; set; }

        public List<PurchasingViewModel.PurchasingViewModel> Purchasing { get; set; }
        public double LastMonthPurchasing { get; set; }
        public double TotalPurchasing { get; set; }
        public int TotalPurchasingCount { get; set; }

       
        public List<Graph> Sales { get; set; }
        public List<Graph> Purchasings { get; set; }
        //public string Sales { get; set; }
        //public string Purchasings { get; set; }

        public List<GroupByCompany> CompaniesData { get; set; }
    }
    public class GroupByCompany
    {
        public int PhoneID { get; set; }
        public string ComapanyName { get; set; }
        public int BrandsTotal { get; set; }
    }
    public class StoreStats
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public int RefNo { get; set; }

        public double MonthPurchasing { get; set; }
        public int MonthPurchasingCount { get; set; }
        public double AverageMonthlyPurchasing { get; set; }
        public double AnnualPurchasing { get; set; }

        public double MonthSales { get; set; }
        public int MonthSalesCount { get; set; }
        public double AverageMonthlySale { get; set; }
        public double AnnualSales { get; set; }
        public int PendingOrders { get; set; }
        public int ProcessOrders { get; set; }
        public int CompletedOrders { get; set; }
        public double MonthlyProfit { get; set; }
        public double AnnualProfit { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalBrands { get; set; }
    }
    public class Graph
    {
        public string Day { get; set; }
        public double Amount { get; set; }
    }
}
