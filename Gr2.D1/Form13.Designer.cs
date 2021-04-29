
namespace Gr2.D1
{
    partial class Form13
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
            this.HScrollBarTheta = new System.Windows.Forms.HScrollBar();
            this.HScrollBarC = new System.Windows.Forms.HScrollBar();
            this.HScrollBarB = new System.Windows.Forms.HScrollBar();
            this.HScrollBarA = new System.Windows.Forms.HScrollBar();
            this.HScrollBarRoll = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.HScrollBarPitch = new System.Windows.Forms.HScrollBar();
            this.MyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HScrollBarTheta
            // 
            this.HScrollBarTheta.Location = new System.Drawing.Point(143, 72);
            this.HScrollBarTheta.Name = "HScrollBarTheta";
            this.HScrollBarTheta.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarTheta.TabIndex = 13;
            this.HScrollBarTheta.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarTheta_Scroll);
            // 
            // HScrollBarC
            // 
            this.HScrollBarC.Location = new System.Drawing.Point(263, 51);
            this.HScrollBarC.Name = "HScrollBarC";
            this.HScrollBarC.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarC.TabIndex = 12;
            this.HScrollBarC.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarC_Scroll);
            // 
            // HScrollBarB
            // 
            this.HScrollBarB.Location = new System.Drawing.Point(263, 30);
            this.HScrollBarB.Name = "HScrollBarB";
            this.HScrollBarB.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarB.TabIndex = 11;
            this.HScrollBarB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarB_Scroll);
            // 
            // HScrollBarA
            // 
            this.HScrollBarA.Location = new System.Drawing.Point(263, 9);
            this.HScrollBarA.Name = "HScrollBarA";
            this.HScrollBarA.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarA.TabIndex = 10;
            this.HScrollBarA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarA_Scroll);
            // 
            // HScrollBarRoll
            // 
            this.HScrollBarRoll.Location = new System.Drawing.Point(9, 51);
            this.HScrollBarRoll.Name = "HScrollBarRoll";
            this.HScrollBarRoll.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarRoll.TabIndex = 9;
            this.HScrollBarRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarRoll_Scroll);
            // 
            // HScrollBarYaw
            // 
            this.HScrollBarYaw.Location = new System.Drawing.Point(9, 30);
            this.HScrollBarYaw.Name = "HScrollBarYaw";
            this.HScrollBarYaw.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarYaw.TabIndex = 8;
            this.HScrollBarYaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYaw_Scroll);
            // 
            // HScrollBarPitch
            // 
            this.HScrollBarPitch.Location = new System.Drawing.Point(9, 9);
            this.HScrollBarPitch.Name = "HScrollBarPitch";
            this.HScrollBarPitch.Size = new System.Drawing.Size(250, 17);
            this.HScrollBarPitch.TabIndex = 7;
            this.HScrollBarPitch.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarPitch_Scroll);
            // 
            // MyPictureBox
            // 
            this.MyPictureBox.Location = new System.Drawing.Point(9, 92);
            this.MyPictureBox.Name = "MyPictureBox";
            this.MyPictureBox.Size = new System.Drawing.Size(779, 346);
            this.MyPictureBox.TabIndex = 14;
            this.MyPictureBox.TabStop = false;
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MyPictureBox);
            this.Controls.Add(this.HScrollBarTheta);
            this.Controls.Add(this.HScrollBarC);
            this.Controls.Add(this.HScrollBarB);
            this.Controls.Add(this.HScrollBarA);
            this.Controls.Add(this.HScrollBarRoll);
            this.Controls.Add(this.HScrollBarYaw);
            this.Controls.Add(this.HScrollBarPitch);
            this.Name = "Form13";
            this.Text = "Form13";
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar HScrollBarTheta;
        private System.Windows.Forms.HScrollBar HScrollBarC;
        private System.Windows.Forms.HScrollBar HScrollBarB;
        private System.Windows.Forms.HScrollBar HScrollBarA;
        private System.Windows.Forms.HScrollBar HScrollBarRoll;
        private System.Windows.Forms.HScrollBar HScrollBarYaw;
        private System.Windows.Forms.HScrollBar HScrollBarPitch;
        private System.Windows.Forms.PictureBox MyPictureBox;
    }
}