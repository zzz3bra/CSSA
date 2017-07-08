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
    public class SourceFile
    {
        public string Name { get; private set; }
        public string Text { get; private set; }
        public List<ClassFromSourceFile> Classes { get; private set; }

        public SourceFile(string name, string text)
        {
            const string EMPTYCLASSNAME = "[EmptyClassName]";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException();
            }
            Name = name;
            Text = text;
            List<ClassFromSourceFile> classes = new List<ClassFromSourceFile>();
            string classname = EMPTYCLASSNAME;
            SyntaxNode root = CSharpSyntaxTree.ParseText(Text).GetRoot();
            IEnumerable<ClassifiedSpan> classification = Classifier.GetClassifiedSpansAsync(new AdhocWorkspace().CurrentSolution.AddProject(name, name, LanguageNames.CSharp).AddDocument(name, root), root.FullSpan).Result;
            List<SyntaxToken> tokens = new List<SyntaxToken>();
            bool enteringClass = false;
            bool inClass = false;
            int braces = 0;
            int begin = 0;

            foreach (var item in classification)
            {
                if (inClass)
                {
                    if ((item.ClassificationType == ClassificationTypeNames.Keyword) || (item.ClassificationType == ClassificationTypeNames.Operator))
                    {
                        tokens.Add(root.FindToken(item.TextSpan.Start));
                    }
                    if (item.ClassificationType == ClassificationTypeNames.Punctuation)
                    {
                        switch (root.FindToken(item.TextSpan.Start).Kind())
                        {
                            case SyntaxKind.OpenBraceToken:
                                braces++;
                                break;
                            case SyntaxKind.CloseBraceToken:
                                if (braces == 0)
                                {
                                    classes.Add(new ClassFromSourceFile(classname, begin, root.GetText().GetSubText(new TextSpan(begin, item.TextSpan.End - begin)), tokens));
                                    classname = EMPTYCLASSNAME;
                                    begin = 0;
                                    inClass = false;
                                }
                                else
                                {
                                    braces--;
                                }
                                break;
                        }
                    }
                }
                else
                    if (enteringClass)
                    {
                        if (item.ClassificationType == ClassificationTypeNames.ClassName)
                        {
                            classname = root.FindToken(item.TextSpan.Start).ValueText;
                        }
                        else
                        {
                            if (item.ClassificationType == ClassificationTypeNames.Punctuation && root.FindToken(item.TextSpan.Start).Kind() == SyntaxKind.OpenBraceToken)
                            {
                                enteringClass = false;
                                inClass = true;
                                begin = item.TextSpan.Start;
                            }
                        }
                    }
                    else
                        if ((item.ClassificationType == ClassificationTypeNames.Keyword) && (root.FindToken(item.TextSpan.Start).Kind() == SyntaxKind.ClassKeyword))
                        {
                            enteringClass = true;
                        }
            }
            Classes = classes;
        }
    }
}
