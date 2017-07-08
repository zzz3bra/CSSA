using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public partial class MainForm : Form
    {
        string pathtoproject1 = "";
        string pathtoproject2 = "";
        List<SourceFile> files1;
        List<SourceFile> files2;
        List<SyntaxToken> tokens1;
        List<SyntaxToken> tokens2;
        Thread t1;
        Thread t2;

        private void LoadProject1()
        {
            files1 = ProjectFile.GetSourceFiles(pathtoproject1);
            tokens1 = files1.First().Classes.First().Tokens;
        }

        private void LoadProject2()
        {
            files2 = ProjectFile.GetSourceFiles(pathtoproject2);
            tokens2 = files2.First().Classes.First().Tokens;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenProject1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pathtoproject1 = openFileDialog1.FileName;
            Project1Label.Text = pathtoproject1;
            t1 = new Thread(new ThreadStart(LoadProject1));
            t1.Start();

            if (!string.IsNullOrEmpty(pathtoproject2))
            {
                Analyze.Enabled = true;
            }
        }

        private void OpenProject2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            pathtoproject2 = openFileDialog2.FileName;
            Project2Label.Text = pathtoproject2;
            t2 = new Thread(new ThreadStart(LoadProject2));
            t2.Start();
            if (!string.IsNullOrEmpty(pathtoproject1))
            {
                Analyze.Enabled = true;
            }
        }

        private void Analyze_Click(object sender, EventArgs e)
        {
            if (t1.IsAlive) t1.Join();
            if (t2.IsAlive) t2.Join();
            var a = new int[tokens1.Count + 1, tokens2.Count + 1];
            int u = 0, v = 0;

            for (var i = 0; i < tokens1.Count; i++)
                for (var j = 0; j < tokens2.Count; j++)
                    if (tokens1[i].ValueText == tokens2[j].ValueText)
                    {
                        a[i + 1, j + 1] = a[i, j] + 1;
                        if (a[i + 1, j + 1] > a[u, v])
                        {
                            u = i + 1;
                            v = j + 1;
                        }
                    }
            int maxlen = a[u, v];

            maxOccuranceLabel.Text = String.Format("Максимально длинное совпадение последовательности операторов составило {0} операторов из {1} операторов меньшего класса, т.е. {2:p}\n", maxlen, Math.Min(tokens1.Count, tokens2.Count), maxlen / (double)Math.Min(tokens1.Count, tokens2.Count));
            richTextBox1.Text = files1.First().Text;
            richTextBox1.Select(tokens1[u - maxlen].SpanStart, tokens1[u - 1].Span.End - tokens1[u - maxlen].SpanStart);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox2.Text = files2.First().Text;
            richTextBox2.Select(tokens2[v - maxlen].SpanStart, tokens2[v - 1].Span.End - tokens2[v - maxlen].SpanStart);
            richTextBox2.SelectionColor = Color.Red;
        }

    }
}
