using CrystalDecisions.CrystalReports.Engine;
using OracleManagedDataAccess.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OracleManagedDataAccess.Reports.ParaUI
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderReport(GetReportData());
            }
        }
        private DataTable GetReportData()
        {
            //CustomerReportDto customerInfo = new CustomerReportDto()
            //{
            //    CusName = Request.QueryString["cusName"] ?? string.Empty,
            //    CusFatherName = Request.QueryString["cusFatherName"] ?? string.Empty//,
            //    //PrintUserName = Request.QueryString["userName"] ?? string.Empty
            //};
            ICustomService _customService = new CustomServiceImpl();
            //string fullAccountNumber = accountService.GetFullAccountNumber(fundTransferReport.AccNo);
            //    if (fullAccountNumber != null) fundTransferReport.AccNo = fullAccountNumber;

            //DateTime fromdate;
            //if (DateTime.TryParseExact(Request.QueryString["fromDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromdate))
            //    fundTransferReport.FromDate = fromdate;
            //DateTime todate;
            //if (DateTime.TryParseExact(Request.QueryString["toDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out todate))
            //    fundTransferReport.ToDate = todate;

            //IReportService reportService = DependencyInjector.GetReportService();
            DataTable dtReportData = _customService.GetAllCustomersInDataTable();


            return dtReportData;
        }

        private void RenderReport(DataTable dtReportData)
        {
            //ReportViewer.Reset();
            //ReportViewer.LocalReport.EnableExternalImages = true;
            //ReportViewer.LocalReport.ReportPath = Server.MapPath("~Reports/Report/CustomerInfoDataTable.rpt");

            //ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CustomerInfoDS", dtReportData));

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath("CustomerInfoDataTable.rpt"));
            CrystalReportViewer1.ReportSource = cryRpt;
        }
    }
}