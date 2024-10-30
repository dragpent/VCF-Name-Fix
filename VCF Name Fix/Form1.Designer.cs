namespace VCF_Name_Fix
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProcess = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnOpenFile = new Button();
            lblMessages = new Label();
            SuspendLayout();
            // 
            // btnProcess
            // 
            btnProcess.Enabled = false;
            btnProcess.Location = new Point(199, 12);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(147, 49);
            btnProcess.TabIndex = 0;
            btnProcess.Text = "Process and Save";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(12, 12);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(147, 49);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Open VCF File";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // lblMessages
            // 
            lblMessages.Location = new Point(12, 80);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(334, 53);
            lblMessages.TabIndex = 2;
            lblMessages.Text = "MAKE SURE TO HAVE BACKUP OF ORGINAL VCF\r\n\r\nClick on Open VCF File and select your VCF file";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 142);
            Controls.Add(lblMessages);
            Controls.Add(btnOpenFile);
            Controls.Add(btnProcess);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "VCF Name Fix";
            ResumeLayout(false);
        }

        #endregion

        private Button btnProcess;
        private OpenFileDialog openFileDialog1;
        private Button btnOpenFile;
        private Label lblMessages;
    }
}
