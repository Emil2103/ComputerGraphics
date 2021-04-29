
namespace Gr2.D1
{
    partial class Form10
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
            this.HScrollBarPitch = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.HScrollBarRoll = new System.Windows.Forms.HScrollBar();
            this.HScrollBarXOffset = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYOffset = new System.Windows.Forms.HScrollBar();
            this.HScrollBarZOffset = new System.Windows.Forms.HScrollBar();
            this.HScrollBarTheta = new System.Windows.Forms.HScrollBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HScrollBarPitch
            // 
            this.HScrollBarPitch.Location = new System.Drawing.Point(13, 13);
            this.HScrollBarPitch.Name = "HScrollBarPitch";
            this.HScrollBarPitch.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarPitch.TabIndex = 0;
            this.HScrollBarPitch.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarPitch_Scroll);
            // 
            // HScrollBarYaw
            // 
            this.HScrollBarYaw.Location = new System.Drawing.Point(13, 34);
            this.HScrollBarYaw.Name = "HScrollBarYaw";
            this.HScrollBarYaw.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarYaw.TabIndex = 1;
            this.HScrollBarYaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYaw_Scroll);
            // 
            // HScrollBarRoll
            // 
            this.HScrollBarRoll.Location = new System.Drawing.Point(13, 55);
            this.HScrollBarRoll.Name = "HScrollBarRoll";
            this.HScrollBarRoll.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarRoll.TabIndex = 2;
            this.HScrollBarRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarRoll_Scroll);
            // 
            // HScrollBarXOffset
            // 
            this.HScrollBarXOffset.Location = new System.Drawing.Point(287, 13);
            this.HScrollBarXOffset.Name = "HScrollBarXOffset";
            this.HScrollBarXOffset.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarXOffset.TabIndex = 3;
            this.HScrollBarXOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarXOffset_Scroll);
            // 
            // HScrollBarYOffset
            // 
            this.HScrollBarYOffset.Location = new System.Drawing.Point(287, 34);
            this.HScrollBarYOffset.Name = "HScrollBarYOffset";
            this.HScrollBarYOffset.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarYOffset.TabIndex = 4;
            this.HScrollBarYOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYOffset_Scroll);
            // 
            // HScrollBarZOffset
            // 
            this.HScrollBarZOffset.Location = new System.Drawing.Point(287, 55);
            this.HScrollBarZOffset.Name = "HScrollBarZOffset";
            this.HScrollBarZOffset.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarZOffset.TabIndex = 5;
            this.HScrollBarZOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarZOffset_Scroll);
            // 
            // HScrollBarTheta
            // 
            this.HScrollBarTheta.Location = new System.Drawing.Point(156, 72);
            this.HScrollBarTheta.Name = "HScrollBarTheta";
            this.HScrollBarTheta.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarTheta.TabIndex = 6;
            this.HScrollBarTheta.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarTheta_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 345);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HScrollBarTheta);
            this.Controls.Add(this.HScrollBarZOffset);
            this.Controls.Add(this.HScrollBarYOffset);
            this.Controls.Add(this.HScrollBarXOffset);
            this.Controls.Add(this.HScrollBarRoll);
            this.Controls.Add(this.HScrollBarYaw);
            this.Controls.Add(this.HScrollBarPitch);
            this.Name = "Form10";
            this.Text = "Form10";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar HScrollBarPitch;
        private System.Windows.Forms.HScrollBar HScrollBarYaw;
        private System.Windows.Forms.HScrollBar HScrollBarRoll;
        private System.Windows.Forms.HScrollBar HScrollBarXOffset;
        private System.Windows.Forms.HScrollBar HScrollBarYOffset;
        private System.Windows.Forms.HScrollBar HScrollBarZOffset;
        private System.Windows.Forms.HScrollBar HScrollBarTheta;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}