namespace Focusr
{
    using Focusr.Controls;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.tbxCountdownTime = new System.Windows.Forms.MaskedTextBox();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new Focusr.Controls.FlatButton();
            this.lblSeconds = new Focusr.Controls.Label();
            this.lblMinutes = new Focusr.Controls.Label();
            this.lblHours = new Focusr.Controls.Label();
            this.lblCountdownTime = new Focusr.Controls.Label();
            this.btnControl = new Focusr.Controls.FlatButton();
            this.btnStop = new Focusr.Controls.FlatButton();
            this.SuspendLayout();
            // 
            // tbxCountdownTime
            // 
            this.tbxCountdownTime.BackColor = System.Drawing.Color.DarkGreen;
            this.tbxCountdownTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCountdownTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxCountdownTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 28F);
            this.tbxCountdownTime.ForeColor = System.Drawing.Color.White;
            this.tbxCountdownTime.HidePromptOnLeave = true;
            this.tbxCountdownTime.Location = new System.Drawing.Point(2, 16);
            this.tbxCountdownTime.Margin = new System.Windows.Forms.Padding(0);
            this.tbxCountdownTime.Mask = "00:00:00";
            this.tbxCountdownTime.Name = "tbxCountdownTime";
            this.tbxCountdownTime.Size = new System.Drawing.Size(172, 48);
            this.tbxCountdownTime.TabIndex = 2;
            this.tbxCountdownTime.Text = "001500";
            this.tbxCountdownTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCountdownTime.ValidatingType = typeof(System.DateTime);
            this.tbxCountdownTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCountdownTime_KeyPress);
            this.tbxCountdownTime.MouseEnter += new System.EventHandler(this.tbxCountdownTime_MouseEnter);
            this.tbxCountdownTime.MouseLeave += new System.EventHandler(this.tbxCountdownTime_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Wingdings 2", 10F);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(166, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Í";
            this.btnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.White;
            this.lblSeconds.Location = new System.Drawing.Point(128, 3);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(27, 16);
            this.lblSeconds.TabIndex = 5;
            this.lblSeconds.Text = "SEC";
            this.lblSeconds.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.Color.White;
            this.lblMinutes.Location = new System.Drawing.Point(76, 3);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(31, 16);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "MIN";
            this.lblMinutes.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.White;
            this.lblHours.Location = new System.Drawing.Point(13, 3);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(47, 16);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "HOURS";
            this.lblHours.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lblCountdownTime
            // 
            this.lblCountdownTime.AutoSize = true;
            this.lblCountdownTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdownTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F);
            this.lblCountdownTime.Location = new System.Drawing.Point(5, 16);
            this.lblCountdownTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblCountdownTime.Name = "lblCountdownTime";
            this.lblCountdownTime.Size = new System.Drawing.Size(170, 48);
            this.lblCountdownTime.TabIndex = 1;
            this.lblCountdownTime.Text = "00:15:00";
            this.lblCountdownTime.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lblCountdownTime.TextChanged += new System.EventHandler(this.lblCountdownTime_TextChanged);
            this.lblCountdownTime.MouseEnter += new System.EventHandler(this.lblCountdownTime_MouseEnter);
            this.lblCountdownTime.MouseLeave += new System.EventHandler(this.lblCountdownTime_MouseLeave);
            // 
            // btnControl
            // 
            this.btnControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControl.BackColor = System.Drawing.Color.Transparent;
            this.btnControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnControl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnControl.Location = new System.Drawing.Point(166, 24);
            this.btnControl.Margin = new System.Windows.Forms.Padding(0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnControl.Size = new System.Drawing.Size(24, 24);
            this.btnControl.TabIndex = 8;
            this.btnControl.TabStop = false;
            this.btnControl.Text = "u";
            this.btnControl.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(166, 48);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnStop.Size = new System.Drawing.Size(24, 24);
            this.btnStop.TabIndex = 9;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Q";
            this.btnStop.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(190, 72);
            this.ControlBox = false;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountdownTime);
            this.Controls.Add(this.tbxCountdownTime);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblHours);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.Label lblCountdownTime;
        private System.Windows.Forms.MaskedTextBox tbxCountdownTime;
        private Controls.Label lblHours;
        private Controls.Label lblMinutes;
        private Controls.Label lblSeconds;
        private System.Windows.Forms.Timer tmrCountdown;
        private FlatButton btnClose;
        private FlatButton btnControl;
        private FlatButton btnStop;
    }
}

