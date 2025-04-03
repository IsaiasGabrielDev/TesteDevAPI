using Microsoft.Reporting.WinForms;
using System.Diagnostics;
using TesteTecWF.Models;

namespace TesteTecWF.Strategy;

internal class RenderReport : IRenderReports
{
    public void Render(RenderReportModel renderReport)
    {
        string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", renderReport.FolderName, renderReport.ReportName + ".rdlc");

        if (!File.Exists(reportPath))
        {
            MessageBox.Show("Arquivo de relatório não encontrado.");
            return;
        }

        using FileStream reportDefinition = new FileStream(reportPath, FileMode.Open, FileAccess.Read);

        LocalReport report = new LocalReport();
        report.LoadReportDefinition(reportDefinition);
        report.DataSources.Add(new ReportDataSource(renderReport.DataSetName, renderReport.Data));
        byte[] pdf = report.Render("PDF");

        string tempFilePath = Path.Combine(Path.GetTempPath(), renderReport.ReportName + ".pdf");
        File.WriteAllBytes(tempFilePath, pdf);

        Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
    }
}
