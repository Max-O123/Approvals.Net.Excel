using System;
using System.IO;
using System.Net.Http;
using ApprovalTests;
using ApprovalTests.Excel;
using ApprovalTests.Reporters;
using ApprovalUtilities.SimpleLogger;
using ApprovalUtilities.SimpleLogger.Writers;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests

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
            byte[] bytes = File.ReadAllBytes(PathUtilities.GetAdjacentFile("sample.xlsx"));
            
            ExcelApprovals.VerifyXlsx(bytes);
        }
        [TestMethod]
        public void TestBytesFromPath()
        {
            Logger.Writer = new ConsoleWriter();
            byte[] bytes = File.ReadAllBytes("C:\\Users\\wolvey\\Downloads\\fileTest.xlsx");
            ExcelApprovals.VerifyXlsx(bytes, pathToUse: "C:\\Users\\wolvey\\Downloads\\");
        }
    }
}