
namespace Gr2.D1
{
    partial class Form6
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
            this.XScrollBar = new System.Windows.Forms.HScrollBar();
            this.YScrollBar = new System.Windows.Forms.HScrollBar();
            this.ZScrollBar = new System.Windows.Forms.HScrollBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // XScrollBar
            // 
            this.XScrollBar.Location = new System.Drawing.Point(13, 13);
            this.XScrollBar.Name = "XScrollBar";
            this.XScrollBar.Size = new System.Drawing.Size(250, 17);
            this.XScrollBar.TabIndex = 0;
            this.XScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.XScrollBar_Scroll);
            // 
            // YScrollBar
            // 
            this.YScrollBar.Location = new System.Drawing.Point(13, 34);
            this.YScrollBar.Name = "YScrollBar";
            this.YScrollBar.Size = new System.Drawing.Size(250, 17);
            this.YScrollBar.TabIndex = 1;
            this.YScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.YScrollBar_Scroll);
            // 
            // ZScrollBar
            // 
            this.ZScrollBar.Location = new System.Drawing.Point(13, 55);
            this.ZScrollBar.Name = "ZScrollBar";
            this.ZScrollBar.Size = new System.Drawing.Size(250, 17);
            this.ZScrollBar.TabIndex = 2;
            this.ZScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ZScrollBar_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 362);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ZScrollBar);
            this.Controls.Add(this.YScrollBar);
            this.Controls.Add(this.XScrollBar);
            this.Name = "Form6";
            this.Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar XScrollBar;
        private System.Windows.Forms.HScrollBar YScrollBar;
        private System.Windows.Forms.HScrollBar ZScrollBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}