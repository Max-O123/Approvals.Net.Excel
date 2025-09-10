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
            byte[] bytes = File.ReadAllBytes("path you want to read the file from"); //if you instead want to generate a new file and test that new file, replace this call with the generation call and pass in the bytes of the file
            ExcelApprovals.VerifyXlsx(bytes, pathToUse: "path to the approved file");
        }
    }
}