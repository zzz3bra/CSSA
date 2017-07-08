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
    public class ClassFromSourceFile
    {
        public string Name { get; private set; }
        public int Position { get; private set; }
        public List<SyntaxToken> Tokens { get; private set; }
        public IEnumerable<ClassifiedSpan> Classification { get; private set; }
        public SourceText SourceText { get; private set; }

        public ClassFromSourceFile(string name, int position, SourceText sourceText, List<SyntaxToken> tokens)
        {
            Name = name;
            Position = position;
            SourceText = sourceText;
            Tokens = tokens;
        }
    }
}
