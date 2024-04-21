namespace CampusNex.PopUps
{
    partial class EventRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventRequest));
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            this.socPic = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.presentLbl_ViewEvent = new Bunifu.UI.WinForms.BunifuLabel();
            this.evePic = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.socName = new Bunifu.UI.WinForms.BunifuLabel();
            this.eveName = new Bunifu.UI.WinForms.BunifuLabel();
            this.dateLbl = new Bunifu.UI.WinForms.BunifuLabel();
            this.locationLbl = new Bunifu.UI.WinForms.BunifuLabel();
            this.descLbl = new Bunifu.UI.WinForms.BunifuLabel();
            this.eveDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.dateViewEvent = new Bunifu.UI.WinForms.BunifuLabel();
            this.locationViewEvent = new Bunifu.UI.WinForms.BunifuLabel();
            this.closeButtonViewEvent = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.orgLbl = new Bunifu.UI.WinForms.BunifuLabel();
            this.orgViewEvent = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.socPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evePic)).BeginInit();
            this.SuspendLayout();
            // 
            // socPic
            // 
            this.socPic.AllowFocused = false;
            this.socPic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.socPic.AutoSizeHeight = true;
            this.socPic.BorderRadius = 0;
            this.socPic.Image = ((System.Drawing.Image)(resources.GetObject("socPic.Image")));
            this.socPic.IsCircle = true;
            this.socPic.Location = new System.Drawing.Point(93, 81);
            this.socPic.Margin = new System.Windows.Forms.Padding(4);
            this.socPic.Name = "socPic";
            this.socPic.Size = new System.Drawing.Size(172, 172);
            this.socPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.socPic.TabIndex = 17;
            this.socPic.TabStop = false;
            this.socPic.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            this.socPic.Click += new System.EventHandler(this.eventPic_Click);
            // 
            // presentLbl_ViewEvent
            // 
            this.presentLbl_ViewEvent.AllowParentOverrides = false;
            this.presentLbl_ViewEvent.AutoEllipsis = false;
            this.presentLbl_ViewEvent.CursorType = null;
            this.presentLbl_ViewEvent.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentLbl_ViewEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.presentLbl_ViewEvent.Location = new System.Drawing.Point(335, 166);
            this.presentLbl_ViewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.presentLbl_ViewEvent.Name = "presentLbl_ViewEvent";
            this.presentLbl_ViewEvent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.presentLbl_ViewEvent.Size = new System.Drawing.Size(77, 18);
            this.presentLbl_ViewEvent.TabIndex = 5;
            this.presentLbl_ViewEvent.Text = "presents";
            this.presentLbl_ViewEvent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.presentLbl_ViewEvent.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // evePic
            // 
            this.evePic.AllowFocused = false;
            this.evePic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.evePic.AutoSizeHeight = true;
            this.evePic.BorderRadius = 0;
            this.evePic.Image = ((System.Drawing.Image)(resources.GetObject("evePic.Image")));
            this.evePic.IsCircle = true;
            this.evePic.Location = new System.Drawing.Point(514, 81);
            this.evePic.Margin = new System.Windows.Forms.Padding(4);
            this.evePic.Name = "evePic";
            this.evePic.Size = new System.Drawing.Size(172, 172);
            this.evePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.evePic.TabIndex = 18;
            this.evePic.TabStop = false;
            this.evePic.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            this.evePic.Click += new System.EventHandler(this.evePic_Click);
            // 
            // socName
            // 
            this.socName.AllowParentOverrides = false;
            this.socName.AutoEllipsis = false;
            this.socName.CursorType = null;
            this.socName.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.socName.Location = new System.Drawing.Point(121, 261);
            this.socName.Margin = new System.Windows.Forms.Padding(4);
            this.socName.Name = "socName";
            this.socName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.socName.Size = new System.Drawing.Size(67, 29);
            this.socName.TabIndex = 1;
            this.socName.Text = "FCCS";
            this.socName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.socName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.socName.Click += new System.EventHandler(this.socName_Click);
            // 
            // eveName
            // 
            this.eveName.AllowParentOverrides = false;
            this.eveName.AutoEllipsis = false;
            this.eveName.Cursor = System.Windows.Forms.Cursors.Default;
            this.eveName.CursorType = System.Windows.Forms.Cursors.Default;
            this.eveName.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.eveName.Location = new System.Drawing.Point(495, 273);
            this.eveName.Margin = new System.Windows.Forms.Padding(4);
            this.eveName.Name = "eveName";
            this.eveName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eveName.Size = new System.Drawing.Size(206, 29);
            this.eveName.TabIndex = 19;
            this.eveName.Text = "DataHackothon";
            this.eveName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.eveName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dateLbl
            // 
            this.dateLbl.AllowParentOverrides = false;
            this.dateLbl.AutoEllipsis = false;
            this.dateLbl.CursorType = null;
            this.dateLbl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.dateLbl.Location = new System.Drawing.Point(56, 318);
            this.dateLbl.Margin = new System.Windows.Forms.Padding(4);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateLbl.Size = new System.Drawing.Size(63, 29);
            this.dateLbl.TabIndex = 20;
            this.dateLbl.Text = "Date";
            this.dateLbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateLbl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // locationLbl
            // 
            this.locationLbl.AllowParentOverrides = false;
            this.locationLbl.AutoEllipsis = false;
            this.locationLbl.CursorType = null;
            this.locationLbl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.locationLbl.Location = new System.Drawing.Point(56, 368);
            this.locationLbl.Margin = new System.Windows.Forms.Padding(4);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.locationLbl.Size = new System.Drawing.Size(113, 29);
            this.locationLbl.TabIndex = 21;
            this.locationLbl.Text = "Location";
            this.locationLbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.locationLbl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.locationLbl.Click += new System.EventHandler(this.locationLbl_Click);
            // 
            // descLbl
            // 
            this.descLbl.AllowParentOverrides = false;
            this.descLbl.AutoEllipsis = false;
            this.descLbl.CursorType = null;
            this.descLbl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.descLbl.Location = new System.Drawing.Point(56, 469);
            this.descLbl.Margin = new System.Windows.Forms.Padding(4);
            this.descLbl.Name = "descLbl";
            this.descLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.descLbl.Size = new System.Drawing.Size(153, 29);
            this.descLbl.TabIndex = 22;
            this.descLbl.Text = "Description";
            this.descLbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.descLbl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // eveDesc
            // 
            this.eveDesc.AllowParentOverrides = false;
            this.eveDesc.AutoEllipsis = false;
            this.eveDesc.Cursor = System.Windows.Forms.Cursors.Default;
            this.eveDesc.CursorType = System.Windows.Forms.Cursors.Default;
            this.eveDesc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eveDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.eveDesc.Location = new System.Drawing.Point(153, 520);
            this.eveDesc.Margin = new System.Windows.Forms.Padding(4);
            this.eveDesc.MaximumSize = new System.Drawing.Size(600, 246);
            this.eveDesc.MinimumSize = new System.Drawing.Size(533, 246);
            this.eveDesc.Name = "eveDesc";
            this.eveDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eveDesc.Size = new System.Drawing.Size(533, 246);
            this.eveDesc.TabIndex = 23;
            this.eveDesc.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.eveDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.eveDesc.Click += new System.EventHandler(this.socDesc_Click);
            // 
            // dateViewEvent
            // 
            this.dateViewEvent.AllowParentOverrides = false;
            this.dateViewEvent.AutoEllipsis = false;
            this.dateViewEvent.CursorType = null;
            this.dateViewEvent.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateViewEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.dateViewEvent.Location = new System.Drawing.Point(280, 318);
            this.dateViewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.dateViewEvent.Name = "dateViewEvent";
            this.dateViewEvent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateViewEvent.Size = new System.Drawing.Size(90, 23);
            this.dateViewEvent.TabIndex = 24;
            this.dateViewEvent.Text = "Dateeee";
            this.dateViewEvent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateViewEvent.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // locationViewEvent
            // 
            this.locationViewEvent.AllowParentOverrides = false;
            this.locationViewEvent.AutoEllipsis = false;
            this.locationViewEvent.CursorType = null;
            this.locationViewEvent.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationViewEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.locationViewEvent.Location = new System.Drawing.Point(271, 368);
            this.locationViewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.locationViewEvent.Name = "locationViewEvent";
            this.locationViewEvent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.locationViewEvent.Size = new System.Drawing.Size(114, 23);
            this.locationViewEvent.TabIndex = 25;
            this.locationViewEvent.Text = "Locationss";
            this.locationViewEvent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.locationViewEvent.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // closeButtonViewEvent
            // 
            this.closeButtonViewEvent.AllowAnimations = true;
            this.closeButtonViewEvent.AllowBorderColorChanges = true;
            this.closeButtonViewEvent.AllowMouseEffects = true;
            this.closeButtonViewEvent.AnimationSpeed = 200;
            this.closeButtonViewEvent.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonViewEvent.BackgroundColor = System.Drawing.Color.Transparent;
            this.closeButtonViewEvent.BorderColor = System.Drawing.Color.Transparent;
            this.closeButtonViewEvent.BorderRadius = 1;
            this.closeButtonViewEvent.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.closeButtonViewEvent.BorderThickness = 1;
            this.closeButtonViewEvent.ColorContrastOnClick = 30;
            this.closeButtonViewEvent.ColorContrastOnHover = 30;
            this.closeButtonViewEvent.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.closeButtonViewEvent.CustomizableEdges = borderEdges1;
            this.closeButtonViewEvent.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closeButtonViewEvent.Image = ((System.Drawing.Image)(resources.GetObject("closeButtonViewEvent.Image")));
            this.closeButtonViewEvent.ImageMargin = new System.Windows.Forms.Padding(0);
            this.closeButtonViewEvent.Location = new System.Drawing.Point(735, -1);
            this.closeButtonViewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.closeButtonViewEvent.Name = "closeButtonViewEvent";
            this.closeButtonViewEvent.RoundBorders = true;
            this.closeButtonViewEvent.ShowBorders = true;
            this.closeButtonViewEvent.Size = new System.Drawing.Size(65, 65);
            this.closeButtonViewEvent.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.closeButtonViewEvent.TabIndex = 26;
            this.closeButtonViewEvent.Click += new System.EventHandler(this.closeButtonViewEvent_Click);
            // 
            // orgLbl
            // 
            this.orgLbl.AllowParentOverrides = false;
            this.orgLbl.AutoEllipsis = false;
            this.orgLbl.CursorType = null;
            this.orgLbl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orgLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.orgLbl.Location = new System.Drawing.Point(56, 417);
            this.orgLbl.Margin = new System.Windows.Forms.Padding(4);
            this.orgLbl.Name = "orgLbl";
            this.orgLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orgLbl.Size = new System.Drawing.Size(132, 29);
            this.orgLbl.TabIndex = 27;
            this.orgLbl.Text = "Organizer";
            this.orgLbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.orgLbl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // orgViewEvent
            // 
            this.orgViewEvent.AllowParentOverrides = false;
            this.orgViewEvent.AutoEllipsis = false;
            this.orgViewEvent.CursorType = null;
            this.orgViewEvent.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orgViewEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.orgViewEvent.Location = new System.Drawing.Point(271, 417);
            this.orgViewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.orgViewEvent.Name = "orgViewEvent";
            this.orgViewEvent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orgViewEvent.Size = new System.Drawing.Size(130, 23);
            this.orgViewEvent.TabIndex = 28;
            this.orgViewEvent.Text = "kalsoommm";
            this.orgViewEvent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.orgViewEvent.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // EventRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.ControlBox = false;
            this.Controls.Add(this.orgViewEvent);
            this.Controls.Add(this.orgLbl);
            this.Controls.Add(this.closeButtonViewEvent);
            this.Controls.Add(this.locationViewEvent);
            this.Controls.Add(this.dateViewEvent);
            this.Controls.Add(this.eveDesc);
            this.Controls.Add(this.descLbl);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.eveName);
            this.Controls.Add(this.socName);
            this.Controls.Add(this.evePic);
            this.Controls.Add(this.presentLbl_ViewEvent);
            this.Controls.Add(this.socPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventRequest";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventRequest";
            this.Load += new System.EventHandler(this.EventRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.socPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox socPic;
        private Bunifu.UI.WinForms.BunifuLabel presentLbl_ViewEvent;
        private Bunifu.UI.WinForms.BunifuPictureBox evePic;
        private Bunifu.UI.WinForms.BunifuLabel socName;
        private Bunifu.UI.WinForms.BunifuLabel eveName;
        private Bunifu.UI.WinForms.BunifuLabel dateLbl;
        private Bunifu.UI.WinForms.BunifuLabel locationLbl;
        private Bunifu.UI.WinForms.BunifuLabel descLbl;
        private Bunifu.UI.WinForms.BunifuLabel eveDesc;
        private Bunifu.UI.WinForms.BunifuLabel dateViewEvent;
        private Bunifu.UI.WinForms.BunifuLabel locationViewEvent;
        private Bunifu.UI.WinForms.BunifuButton.BunifuIconButton closeButtonViewEvent;
        private Bunifu.UI.WinForms.BunifuLabel orgLbl;
        private Bunifu.UI.WinForms.BunifuLabel orgViewEvent;
    }
}