using System;
using System.IO;
using System.Net.Http;
using ApprovalTests.Reporters;
using ApprovalUtilities.SimpleLogger;
using ApprovalUtilities.SimpleLogger.Writers;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ApprovalTests.Excel.Tests

{
    [TestClass]
    [UseReporter(typeof (ExcelLauncherReporter))]
    public class ExcelTest
    {
        
        [TestMethod]
        public void TestFilesMatch()
        {
            Logger.Writer = new ConsoleWriter();
            ExcelApprovals.VerifyXlsxFile(PathUtilities.GetAdjacentFile("sample.xlsx"), deleteOnSuccess: false);
        }

        [TestMethod]
        public void TestBytes()
        {
            Logger.Writer = new ConsoleWriter();
            var namer = Approvals.GetDefaultNamer();
            byte[] bytes = File.ReadAllBytes(PathUtilities.GetAdjacentFile("sample.xlsx"));
            
            ExcelApprovals.VerifyXlsx(bytes);
        }
    }
}