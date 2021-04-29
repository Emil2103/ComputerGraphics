
namespace Gr2.D1
{
    partial class Form5
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
            this.button1 = new System.Windows.Forms.Button();
            this.hScrollBarPitch = new System.Windows.Forms.HScrollBar();
            this.hScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.hScrollBarRoll = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 362);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hScrollBarPitch
            // 
            this.hScrollBarPitch.Location = new System.Drawing.Point(13, 12);
            this.hScrollBarPitch.Name = "hScrollBarPitch";
            this.hScrollBarPitch.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarPitch.TabIndex = 5;
            // 
            // hScrollBarYaw
            // 
            this.hScrollBarYaw.Location = new System.Drawing.Point(13, 33);
            this.hScrollBarYaw.Name = "hScrollBarYaw";
            this.hScrollBarYaw.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarYaw.TabIndex = 6;
            // 
            // hScrollBarRoll
            // 
            this.hScrollBarRoll.Location = new System.Drawing.Point(13, 53);
            this.hScrollBarRoll.Name = "hScrollBarRoll";
            this.hScrollBarRoll.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarRoll.TabIndex = 7;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hScrollBarRoll);
            this.Controls.Add(this.hScrollBarYaw);
            this.Controls.Add(this.hScrollBarPitch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar hScrollBarPitch;
        private System.Windows.Forms.HScrollBar hScrollBarYaw;
        private System.Windows.Forms.HScrollBar hScrollBarRoll;
    }
}