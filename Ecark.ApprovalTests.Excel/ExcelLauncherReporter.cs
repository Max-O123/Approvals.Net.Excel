using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.Win32;
namespace Ecark.ApprovalTests.Excel
{
    public class ExcelLauncherReporter : IEnvironmentAwareReporter
    {
        public void Report(string approved, string received)
        {
            var args = $"/r \"{approved}\" \"{received}\"";
            Process.Start(GetExcelPath(), args);
        }

        public bool IsWorkingInThisEnvironment(string forFile)
        {
            var excelFile = Path.GetExtension(forFile)?.ToLowerInvariant() is ".xlsx" or ".xls";
            var excelPath = GetExcelPath();
            return excelFile && File.Exists(excelPath);
        }

        public string GetExcelPath()
        {
            string excelPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\excel.exe", "", null)?.ToString();
            return excelPath;
        }
    }
}