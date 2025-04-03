namespace TesteTecWF.Models;

public sealed record class RenderReportModel
{
    public required string FolderName { get; set; }
    public required string ReportName { get; set; }
    public required string DataSetName { get; set; }
    public required object Data { get; set; }
}