using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Excel
{
    public class ExcelLauncherReporter : IEnvironmentAwareReporter
    {
        public void Report(string approved, string received)
        {
            var args = $"/r \"{approved}\" \"{received}\"";
            Process.Start("excel.exe", args);
        }

        public bool IsWorkingInThisEnvironment(string forFile)
        {
            var excelFile = Path.GetExtension(forFile)?.ToLowerInvariant() is ".xlsx" or ".xls";
            var excelPath = "C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE";
            return excelFile && File.Exists(excelPath);
        }
    }
}