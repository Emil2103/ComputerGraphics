
namespace Gr2.D1
{
    partial class Form22
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HScrollBarRoll = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.HScrollBarPitch = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 362);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // HScrollBarRoll
            // 
            this.HScrollBarRoll.Location = new System.Drawing.Point(13, 55);
            this.HScrollBarRoll.Name = "HScrollBarRoll";
            this.HScrollBarRoll.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarRoll.TabIndex = 6;
            this.HScrollBarRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarRoll_Scroll);
            // 
            // HScrollBarYaw
            // 
            this.HScrollBarYaw.Location = new System.Drawing.Point(13, 34);
            this.HScrollBarYaw.Name = "HScrollBarYaw";
            this.HScrollBarYaw.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarYaw.TabIndex = 5;
            this.HScrollBarYaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYaw_Scroll);
            // 
            // HScrollBarPitch
            // 
            this.HScrollBarPitch.Location = new System.Drawing.Point(13, 13);
            this.HScrollBarPitch.Name = "HScrollBarPitch";
            this.HScrollBarPitch.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarPitch.TabIndex = 4;
            this.HScrollBarPitch.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarPitch_Scroll);
            // 
            // Form22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HScrollBarRoll);
            this.Controls.Add(this.HScrollBarYaw);
            this.Controls.Add(this.HScrollBarPitch);
            this.Name = "Form22";
            this.Text = "Form22";
            this.Load += new System.EventHandler(this.Form22_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HScrollBar HScrollBarRoll;
        private System.Windows.Forms.HScrollBar HScrollBarYaw;
        private System.Windows.Forms.HScrollBar HScrollBarPitch;
    }
}