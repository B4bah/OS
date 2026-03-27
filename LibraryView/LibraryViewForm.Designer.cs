namespace LibraryView
{
    partial class LibraryViewForm
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
            this.listBoxNames = new System.Windows.Forms.ListBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnTitles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxNames
            // 
            this.listBoxNames.FormattingEnabled = true;
            this.listBoxNames.Location = new System.Drawing.Point(21, 51);
            this.listBoxNames.Name = "listBoxNames";
            this.listBoxNames.Size = new System.Drawing.Size(286, 368);
            this.listBoxNames.TabIndex = 0;
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.Location = new System.Drawing.Point(356, 51);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(406, 368);
            this.listBoxInfo.TabIndex = 1;
            // 
            // btnAuthors
            // 
            this.btnAuthors.Location = new System.Drawing.Point(47, 13);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(75, 23);
            this.btnAuthors.TabIndex = 2;
            this.btnAuthors.Text = "Authors";
            this.btnAuthors.UseVisualStyleBackColor = true;
            // 
            // btnTitles
            // 
            this.btnTitles.Location = new System.Drawing.Point(208, 13);
            this.btnTitles.Name = "btnTitles";
            this.btnTitles.Size = new System.Drawing.Size(75, 23);
            this.btnTitles.TabIndex = 3;
            this.btnTitles.Text = "Titles";
            this.btnTitles.UseVisualStyleBackColor = true;
            // 
            // LibraryViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTitles);
            this.Controls.Add(this.btnAuthors);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.listBoxNames);
            this.Name = "LibraryViewForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNames;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnTitles;
    }
}

