namespace CampusNex.PopUps
{
    partial class CNMessage
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
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CNMessage));
            this.closeBtnViewMember = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.msgtype = new System.Windows.Forms.Label();
            this.reasons = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeBtnViewMember
            // 
            this.closeBtnViewMember.AllowAnimations = true;
            this.closeBtnViewMember.AllowBorderColorChanges = true;
            this.closeBtnViewMember.AllowMouseEffects = true;
            this.closeBtnViewMember.AnimationSpeed = 200;
            this.closeBtnViewMember.BackColor = System.Drawing.Color.Transparent;
            this.closeBtnViewMember.BackgroundColor = System.Drawing.Color.Transparent;
            this.closeBtnViewMember.BorderColor = System.Drawing.Color.Transparent;
            this.closeBtnViewMember.BorderRadius = 1;
            this.closeBtnViewMember.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.closeBtnViewMember.BorderThickness = 1;
            this.closeBtnViewMember.ColorContrastOnClick = 30;
            this.closeBtnViewMember.ColorContrastOnHover = 30;
            this.closeBtnViewMember.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.closeBtnViewMember.CustomizableEdges = borderEdges2;
            this.closeBtnViewMember.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closeBtnViewMember.Image = ((System.Drawing.Image)(resources.GetObject("closeBtnViewMember.Image")));
            this.closeBtnViewMember.ImageMargin = new System.Windows.Forms.Padding(0);
            this.closeBtnViewMember.Location = new System.Drawing.Point(373, 12);
            this.closeBtnViewMember.Name = "closeBtnViewMember";
            this.closeBtnViewMember.RoundBorders = true;
            this.closeBtnViewMember.ShowBorders = true;
            this.closeBtnViewMember.Size = new System.Drawing.Size(49, 49);
            this.closeBtnViewMember.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.closeBtnViewMember.TabIndex = 2;
            this.closeBtnViewMember.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // msgtype
            // 
            this.msgtype.AutoSize = true;
            this.msgtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgtype.ForeColor = System.Drawing.Color.DodgerBlue;
            this.msgtype.Location = new System.Drawing.Point(120, 24);
            this.msgtype.Name = "msgtype";
            this.msgtype.Size = new System.Drawing.Size(167, 24);
            this.msgtype.TabIndex = 11;
            this.msgtype.Text = "Society Rejected";
            // 
            // reasons
            // 
            this.reasons.AutoSize = true;
            this.reasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasons.ForeColor = System.Drawing.Color.White;
            this.reasons.Location = new System.Drawing.Point(62, 104);
            this.reasons.MaximumSize = new System.Drawing.Size(300, 100);
            this.reasons.MinimumSize = new System.Drawing.Size(300, 100);
            this.reasons.Name = "reasons";
            this.reasons.Size = new System.Drawing.Size(300, 100);
            this.reasons.TabIndex = 12;
            this.reasons.Text = "Reason for Society Rejection";
            this.reasons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(159, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Comments";
            // 
            // CNMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(421, 220);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reasons);
            this.Controls.Add(this.msgtype);
            this.Controls.Add(this.closeBtnViewMember);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CNMessage";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuIconButton closeBtnViewMember;
        private System.Windows.Forms.Label msgtype;
        private System.Windows.Forms.Label reasons;
        private System.Windows.Forms.Label label2;
    }
}