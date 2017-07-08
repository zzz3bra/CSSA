using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using CSSA;

namespace CSSAUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProjectFileOpeningNull()
        {
            try
            {
                List<SourceFile> lal = ProjectFile.GetSourceFiles(null);
            }
            catch (ArgumentNullException)
            {

            }
        }
        [TestMethod]
        public void TestProjectFileOpeningNonEistingFile()
        {
            try
            {
                List<SourceFile> lal = ProjectFile.GetSourceFiles("i'm not exist");
            }
            catch (FileNotFoundException)
            {

            }
        }
        [TestMethod]
        public void TestProjectSourceFileParsingNulls()
        {
            try
            {
                SourceFile src = new SourceFile(null, null);
            }
            catch (ArgumentNullException)
            {

            }
        }
        [TestMethod]
        public void TestProjectSourceFileParsingIncorrectText()
        {
            SourceFile src = new SourceFile("me", "incorrect c# syntax");
            Assert.IsNotNull(src.Classes);
        }
    }
}
