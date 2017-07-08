namespace CSSA
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OpenProject1 = new System.Windows.Forms.Button();
            this.OpenProject2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Project1Label = new System.Windows.Forms.Label();
            this.Project2Label = new System.Windows.Forms.Label();
            this.Analyze = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.maxOccuranceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenProject1
            // 
            this.OpenProject1.Location = new System.Drawing.Point(18, 8);
            this.OpenProject1.Name = "OpenProject1";
            this.OpenProject1.Size = new System.Drawing.Size(150, 40);
            this.OpenProject1.TabIndex = 0;
            this.OpenProject1.Text = "Открыть 1-й проект";
            this.OpenProject1.UseVisualStyleBackColor = true;
            this.OpenProject1.Click += new System.EventHandler(this.OpenProject1_Click);
            // 
            // OpenProject2
            // 
            this.OpenProject2.Location = new System.Drawing.Point(463, 8);
            this.OpenProject2.Name = "OpenProject2";
            this.OpenProject2.Size = new System.Drawing.Size(150, 40);
            this.OpenProject2.TabIndex = 1;
            this.OpenProject2.Text = "Открыть 2-й проект";
            this.OpenProject2.UseVisualStyleBackColor = true;
            this.OpenProject2.Click += new System.EventHandler(this.OpenProject2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "C# Project Files|*.csproj";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Project1Label
            // 
            this.Project1Label.AutoSize = true;
            this.Project1Label.Location = new System.Drawing.Point(15, 55);
            this.Project1Label.Name = "Project1Label";
            this.Project1Label.Size = new System.Drawing.Size(0, 13);
            this.Project1Label.TabIndex = 2;
            // 
            // Project2Label
            // 
            this.Project2Label.AutoSize = true;
            this.Project2Label.Location = new System.Drawing.Point(460, 55);
            this.Project2Label.Name = "Project2Label";
            this.Project2Label.Size = new System.Drawing.Size(0, 13);
            this.Project2Label.TabIndex = 3;
            // 
            // Analyze
            // 
            this.Analyze.Enabled = false;
            this.Analyze.Location = new System.Drawing.Point(750, 8);
            this.Analyze.Name = "Analyze";
            this.Analyze.Size = new System.Drawing.Size(182, 40);
            this.Analyze.TabIndex = 4;
            this.Analyze.Text = "Анализировать";
            this.Analyze.UseVisualStyleBackColor = true;
            this.Analyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "C# Project Files|*.csproj";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(420, 370);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(512, 75);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(420, 370);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // maxOccuranceLabel
            // 
            this.maxOccuranceLabel.AutoSize = true;
            this.maxOccuranceLabel.Location = new System.Drawing.Point(132, 457);
            this.maxOccuranceLabel.Name = "maxOccuranceLabel";
            this.maxOccuranceLabel.Size = new System.Drawing.Size(0, 13);
            this.maxOccuranceLabel.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 482);
            this.Controls.Add(this.maxOccuranceLabel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Analyze);
            this.Controls.Add(this.Project2Label);
            this.Controls.Add(this.Project1Label);
            this.Controls.Add(this.OpenProject2);
            this.Controls.Add(this.OpenProject1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenProject1;
        private System.Windows.Forms.Button OpenProject2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Project1Label;
        private System.Windows.Forms.Label Project2Label;
        private System.Windows.Forms.Button Analyze;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label maxOccuranceLabel;
    }
}

