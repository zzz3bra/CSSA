using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Xml;

namespace CSSA
{
    public class ProjectFile
    {
        public static List<SourceFile> GetSourceFiles(string projectPath)
        {
            if (string.IsNullOrEmpty(projectPath))
            {
                throw new ArgumentNullException();
            }
            List<SourceFile> files = new List<SourceFile>();
            try
            {
                using (XmlTextReader reader = new XmlTextReader(projectPath))
                {
                    while (reader.ReadToFollowing("Compile"))
                    {
                        reader.MoveToFirstAttribute();
                        if (!reader.Value.StartsWith("Properties\\"))
                        {
                            files.Add(new SourceFile(reader.Value, File.ReadAllText(new FileInfo(projectPath).DirectoryName + "\\" + reader.Value, Encoding.Default)));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            return files;
        }
    }
}
