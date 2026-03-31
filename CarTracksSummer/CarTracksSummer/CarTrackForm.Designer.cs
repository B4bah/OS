namespace CarTracksSummer
{
    partial class CarTrackForm
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
            this.CarTrackList = new System.Windows.Forms.ListBox();
            this.CarTrackInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CarTrackList
            // 
            this.CarTrackList.FormattingEnabled = true;
            this.CarTrackList.Location = new System.Drawing.Point(12, 12);
            this.CarTrackList.Name = "CarTrackList";
            this.CarTrackList.Size = new System.Drawing.Size(227, 420);
            this.CarTrackList.TabIndex = 0;
            // 
            // CarTrackInfo
            // 
            this.CarTrackInfo.FormattingEnabled = true;
            this.CarTrackInfo.Location = new System.Drawing.Point(504, 12);
            this.CarTrackInfo.Name = "CarTrackInfo";
            this.CarTrackInfo.Size = new System.Drawing.Size(284, 420);
            this.CarTrackInfo.TabIndex = 1;
            // 
            // CarTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CarTrackInfo);
            this.Controls.Add(this.CarTrackList);
            this.Name = "CarTrackForm";
            this.Text = "Car Track Summer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CarTrackList;
        private System.Windows.Forms.ListBox CarTrackInfo;
    }
}

