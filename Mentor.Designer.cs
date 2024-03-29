namespace CampusNex
{
    partial class Mentor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mentor));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reqBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.eventsBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.societiesBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StudentPages = new Bunifu.UI.WinForms.BunifuPages();
            this.SocietiesPage = new System.Windows.Forms.TabPage();
            this.societyCardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.userName = new Bunifu.UI.WinForms.BunifuLabel();
            this.userPic = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.searchBar = new Bunifu.UI.WinForms.BunifuTextBox();
            this.EventsPage = new System.Windows.Forms.TabPage();
            this.Requests = new System.Windows.Forms.TabPage();
            this.socReqGrid = new System.Windows.Forms.DataGridView();
            this.soclogo = new System.Windows.Forms.DataGridViewImageColumn();
            this.socName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AcceptReg = new System.Windows.Forms.DataGridViewButtonColumn();
            this.reqLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.reqLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StudentPages.SuspendLayout();
            this.SocietiesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.Requests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socReqGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.reqBtn);
            this.panel1.Controls.Add(this.eventsBtn);
            this.panel1.Controls.Add(this.societiesBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 729);
            this.panel1.TabIndex = 0;
            // 
            // reqBtn
            // 
            this.reqBtn.AllowAnimations = true;
            this.reqBtn.AllowMouseEffects = true;
            this.reqBtn.AllowToggling = true;
            this.reqBtn.AnimationSpeed = 200;
            this.reqBtn.AutoGenerateColors = false;
            this.reqBtn.AutoRoundBorders = false;
            this.reqBtn.AutoSizeLeftIcon = true;
            this.reqBtn.AutoSizeRightIcon = true;
            this.reqBtn.BackColor = System.Drawing.Color.Transparent;
            this.reqBtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.reqBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reqBtn.BackgroundImage")));
            this.reqBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.reqBtn.ButtonText = "Requests";
            this.reqBtn.ButtonTextMarginLeft = 0;
            this.reqBtn.ColorContrastOnClick = 45;
            this.reqBtn.ColorContrastOnHover = 45;
            this.reqBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.reqBtn.CustomizableEdges = borderEdges1;
            this.reqBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.reqBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.reqBtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.reqBtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.reqBtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.reqBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqBtn.ForeColor = System.Drawing.Color.White;
            this.reqBtn.IconLeft = null;
            this.reqBtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reqBtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.reqBtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.reqBtn.IconMarginLeft = 11;
            this.reqBtn.IconPadding = 10;
            this.reqBtn.IconRight = null;
            this.reqBtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reqBtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.reqBtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.reqBtn.IconSize = 25;
            this.reqBtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.reqBtn.IdleBorderRadius = 0;
            this.reqBtn.IdleBorderThickness = 0;
            this.reqBtn.IdleFillColor = System.Drawing.Color.Empty;
            this.reqBtn.IdleIconLeftImage = null;
            this.reqBtn.IdleIconRightImage = null;
            this.reqBtn.IndicateFocus = true;
            this.reqBtn.Location = new System.Drawing.Point(27, 315);
            this.reqBtn.Margin = new System.Windows.Forms.Padding(5);
            this.reqBtn.Name = "reqBtn";
            this.reqBtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.reqBtn.OnDisabledState.BorderRadius = 39;
            this.reqBtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.reqBtn.OnDisabledState.BorderThickness = 1;
            this.reqBtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.reqBtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.reqBtn.OnDisabledState.IconLeftImage = null;
            this.reqBtn.OnDisabledState.IconRightImage = null;
            this.reqBtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.reqBtn.onHoverState.BorderRadius = 39;
            this.reqBtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dash;
            this.reqBtn.onHoverState.BorderThickness = 1;
            this.reqBtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.reqBtn.onHoverState.ForeColor = System.Drawing.Color.DodgerBlue;
            this.reqBtn.onHoverState.IconLeftImage = null;
            this.reqBtn.onHoverState.IconRightImage = null;
            this.reqBtn.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.reqBtn.OnIdleState.BorderRadius = 39;
            this.reqBtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.reqBtn.OnIdleState.BorderThickness = 1;
            this.reqBtn.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.reqBtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.reqBtn.OnIdleState.IconLeftImage = null;
            this.reqBtn.OnIdleState.IconRightImage = null;
            this.reqBtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.reqBtn.OnPressedState.BorderRadius = 39;
            this.reqBtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.reqBtn.OnPressedState.BorderThickness = 1;
            this.reqBtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.reqBtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.reqBtn.OnPressedState.IconLeftImage = null;
            this.reqBtn.OnPressedState.IconRightImage = null;
            this.reqBtn.Size = new System.Drawing.Size(220, 50);
            this.reqBtn.TabIndex = 4;
            this.reqBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reqBtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.reqBtn.TextMarginLeft = 0;
            this.reqBtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.reqBtn.UseDefaultRadiusAndThickness = true;
            this.reqBtn.Click += new System.EventHandler(this.reqBtn_Click);
            // 
            // eventsBtn
            // 
            this.eventsBtn.AllowAnimations = true;
            this.eventsBtn.AllowMouseEffects = true;
            this.eventsBtn.AllowToggling = true;
            this.eventsBtn.AnimationSpeed = 200;
            this.eventsBtn.AutoGenerateColors = false;
            this.eventsBtn.AutoRoundBorders = false;
            this.eventsBtn.AutoSizeLeftIcon = true;
            this.eventsBtn.AutoSizeRightIcon = true;
            this.eventsBtn.BackColor = System.Drawing.Color.Transparent;
            this.eventsBtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.eventsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eventsBtn.BackgroundImage")));
            this.eventsBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.eventsBtn.ButtonText = "Events";
            this.eventsBtn.ButtonTextMarginLeft = 0;
            this.eventsBtn.ColorContrastOnClick = 45;
            this.eventsBtn.ColorContrastOnHover = 45;
            this.eventsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.eventsBtn.CustomizableEdges = borderEdges2;
            this.eventsBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.eventsBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.eventsBtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.eventsBtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.eventsBtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.eventsBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsBtn.ForeColor = System.Drawing.Color.White;
            this.eventsBtn.IconLeft = null;
            this.eventsBtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventsBtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.eventsBtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.eventsBtn.IconMarginLeft = 11;
            this.eventsBtn.IconPadding = 10;
            this.eventsBtn.IconRight = null;
            this.eventsBtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eventsBtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.eventsBtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.eventsBtn.IconSize = 25;
            this.eventsBtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.eventsBtn.IdleBorderRadius = 0;
            this.eventsBtn.IdleBorderThickness = 0;
            this.eventsBtn.IdleFillColor = System.Drawing.Color.Empty;
            this.eventsBtn.IdleIconLeftImage = null;
            this.eventsBtn.IdleIconRightImage = null;
            this.eventsBtn.IndicateFocus = true;
            this.eventsBtn.Location = new System.Drawing.Point(27, 234);
            this.eventsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.eventsBtn.Name = "eventsBtn";
            this.eventsBtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.eventsBtn.OnDisabledState.BorderRadius = 39;
            this.eventsBtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.eventsBtn.OnDisabledState.BorderThickness = 1;
            this.eventsBtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.eventsBtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.eventsBtn.OnDisabledState.IconLeftImage = null;
            this.eventsBtn.OnDisabledState.IconRightImage = null;
            this.eventsBtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.eventsBtn.onHoverState.BorderRadius = 39;
            this.eventsBtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dash;
            this.eventsBtn.onHoverState.BorderThickness = 1;
            this.eventsBtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.eventsBtn.onHoverState.ForeColor = System.Drawing.Color.DodgerBlue;
            this.eventsBtn.onHoverState.IconLeftImage = null;
            this.eventsBtn.onHoverState.IconRightImage = null;
            this.eventsBtn.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.eventsBtn.OnIdleState.BorderRadius = 39;
            this.eventsBtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.eventsBtn.OnIdleState.BorderThickness = 1;
            this.eventsBtn.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.eventsBtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.eventsBtn.OnIdleState.IconLeftImage = null;
            this.eventsBtn.OnIdleState.IconRightImage = null;
            this.eventsBtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.eventsBtn.OnPressedState.BorderRadius = 39;
            this.eventsBtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.eventsBtn.OnPressedState.BorderThickness = 1;
            this.eventsBtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.eventsBtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.eventsBtn.OnPressedState.IconLeftImage = null;
            this.eventsBtn.OnPressedState.IconRightImage = null;
            this.eventsBtn.Size = new System.Drawing.Size(220, 50);
            this.eventsBtn.TabIndex = 3;
            this.eventsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eventsBtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.eventsBtn.TextMarginLeft = 0;
            this.eventsBtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.eventsBtn.UseDefaultRadiusAndThickness = true;
            this.eventsBtn.Click += new System.EventHandler(this.societiesBtn_Click);
            // 
            // societiesBtn
            // 
            this.societiesBtn.AllowAnimations = true;
            this.societiesBtn.AllowMouseEffects = true;
            this.societiesBtn.AllowToggling = true;
            this.societiesBtn.AnimationSpeed = 200;
            this.societiesBtn.AutoGenerateColors = false;
            this.societiesBtn.AutoRoundBorders = false;
            this.societiesBtn.AutoSizeLeftIcon = true;
            this.societiesBtn.AutoSizeRightIcon = true;
            this.societiesBtn.BackColor = System.Drawing.Color.Transparent;
            this.societiesBtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.societiesBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("societiesBtn.BackgroundImage")));
            this.societiesBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.societiesBtn.ButtonText = "Societies";
            this.societiesBtn.ButtonTextMarginLeft = 0;
            this.societiesBtn.ColorContrastOnClick = 45;
            this.societiesBtn.ColorContrastOnHover = 45;
            this.societiesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.societiesBtn.CustomizableEdges = borderEdges3;
            this.societiesBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.societiesBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.societiesBtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.societiesBtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.societiesBtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.societiesBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.societiesBtn.ForeColor = System.Drawing.Color.White;
            this.societiesBtn.IconLeft = null;
            this.societiesBtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.societiesBtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.societiesBtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.societiesBtn.IconMarginLeft = 11;
            this.societiesBtn.IconPadding = 10;
            this.societiesBtn.IconRight = null;
            this.societiesBtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.societiesBtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.societiesBtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.societiesBtn.IconSize = 25;
            this.societiesBtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.societiesBtn.IdleBorderRadius = 0;
            this.societiesBtn.IdleBorderThickness = 0;
            this.societiesBtn.IdleFillColor = System.Drawing.Color.Empty;
            this.societiesBtn.IdleIconLeftImage = null;
            this.societiesBtn.IdleIconRightImage = null;
            this.societiesBtn.IndicateFocus = true;
            this.societiesBtn.Location = new System.Drawing.Point(27, 155);
            this.societiesBtn.Margin = new System.Windows.Forms.Padding(5);
            this.societiesBtn.Name = "societiesBtn";
            this.societiesBtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.societiesBtn.OnDisabledState.BorderRadius = 39;
            this.societiesBtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.societiesBtn.OnDisabledState.BorderThickness = 1;
            this.societiesBtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.societiesBtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.societiesBtn.OnDisabledState.IconLeftImage = null;
            this.societiesBtn.OnDisabledState.IconRightImage = null;
            this.societiesBtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.societiesBtn.onHoverState.BorderRadius = 39;
            this.societiesBtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dash;
            this.societiesBtn.onHoverState.BorderThickness = 1;
            this.societiesBtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.societiesBtn.onHoverState.ForeColor = System.Drawing.Color.DodgerBlue;
            this.societiesBtn.onHoverState.IconLeftImage = null;
            this.societiesBtn.onHoverState.IconRightImage = null;
            this.societiesBtn.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.societiesBtn.OnIdleState.BorderRadius = 39;
            this.societiesBtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.societiesBtn.OnIdleState.BorderThickness = 1;
            this.societiesBtn.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.societiesBtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.societiesBtn.OnIdleState.IconLeftImage = null;
            this.societiesBtn.OnIdleState.IconRightImage = null;
            this.societiesBtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.societiesBtn.OnPressedState.BorderRadius = 39;
            this.societiesBtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.societiesBtn.OnPressedState.BorderThickness = 1;
            this.societiesBtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.societiesBtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.societiesBtn.OnPressedState.IconLeftImage = null;
            this.societiesBtn.OnPressedState.IconRightImage = null;
            this.societiesBtn.Size = new System.Drawing.Size(220, 50);
            this.societiesBtn.TabIndex = 2;
            this.societiesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.societiesBtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.societiesBtn.TextMarginLeft = 0;
            this.societiesBtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.societiesBtn.UseDefaultRadiusAndThickness = true;
            this.societiesBtn.Click += new System.EventHandler(this.societiesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(82)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(109, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "CampusNex";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CampusNex.Properties.Resources.CampusNex1;
            this.pictureBox1.Location = new System.Drawing.Point(-66, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // StudentPages
            // 
            this.StudentPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.StudentPages.AllowTransitions = false;
            this.StudentPages.Controls.Add(this.SocietiesPage);
            this.StudentPages.Controls.Add(this.EventsPage);
            this.StudentPages.Controls.Add(this.Requests);
            this.StudentPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentPages.Location = new System.Drawing.Point(271, 0);
            this.StudentPages.Multiline = true;
            this.StudentPages.Name = "StudentPages";
            this.StudentPages.Page = this.SocietiesPage;
            this.StudentPages.PageIndex = 0;
            this.StudentPages.PageName = "SocietiesPage";
            this.StudentPages.PageTitle = "Societies";
            this.StudentPages.SelectedIndex = 0;
            this.StudentPages.Size = new System.Drawing.Size(1079, 729);
            this.StudentPages.TabIndex = 1;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.StudentPages.Transition = animation1;
            this.StudentPages.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            // 
            // SocietiesPage
            // 
            this.SocietiesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.SocietiesPage.Controls.Add(this.societyCardsPanel);
            this.SocietiesPage.Controls.Add(this.userName);
            this.SocietiesPage.Controls.Add(this.userPic);
            this.SocietiesPage.Controls.Add(this.searchBar);
            this.SocietiesPage.Location = new System.Drawing.Point(4, 4);
            this.SocietiesPage.Name = "SocietiesPage";
            this.SocietiesPage.Padding = new System.Windows.Forms.Padding(3);
            this.SocietiesPage.Size = new System.Drawing.Size(1071, 703);
            this.SocietiesPage.TabIndex = 0;
            this.SocietiesPage.Text = "Societies";
            // 
            // societyCardsPanel
            // 
            this.societyCardsPanel.AutoScroll = true;
            this.societyCardsPanel.BackColor = System.Drawing.Color.Transparent;
            this.societyCardsPanel.Location = new System.Drawing.Point(25, 126);
            this.societyCardsPanel.Margin = new System.Windows.Forms.Padding(10);
            this.societyCardsPanel.Name = "societyCardsPanel";
            this.societyCardsPanel.Padding = new System.Windows.Forms.Padding(40, 10, 10, 10);
            this.societyCardsPanel.Size = new System.Drawing.Size(996, 492);
            this.societyCardsPanel.TabIndex = 4;
            // 
            // userName
            // 
            this.userName.AllowParentOverrides = false;
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.AutoEllipsis = false;
            this.userName.Cursor = System.Windows.Forms.Cursors.Default;
            this.userName.CursorType = System.Windows.Forms.Cursors.Default;
            this.userName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.userName.Location = new System.Drawing.Point(878, 66);
            this.userName.Name = "userName";
            this.userName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userName.Size = new System.Drawing.Size(97, 18);
            this.userName.TabIndex = 3;
            this.userName.Text = "User Name";
            this.userName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.userName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // userPic
            // 
            this.userPic.AllowFocused = false;
            this.userPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userPic.AutoSizeHeight = true;
            this.userPic.BorderRadius = 50;
            this.userPic.Image = ((System.Drawing.Image)(resources.GetObject("userPic.Image")));
            this.userPic.IsCircle = true;
            this.userPic.Location = new System.Drawing.Point(786, 25);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(100, 100);
            this.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPic.TabIndex = 2;
            this.userPic.TabStop = false;
            this.userPic.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // searchBar
            // 
            this.searchBar.AcceptsReturn = false;
            this.searchBar.AcceptsTab = false;
            this.searchBar.AnimationSpeed = 200;
            this.searchBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchBar.AutoSizeHeight = true;
            this.searchBar.BackColor = System.Drawing.Color.Transparent;
            this.searchBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBar.BackgroundImage")));
            this.searchBar.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.searchBar.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.searchBar.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.searchBar.BorderColorIdle = System.Drawing.Color.Silver;
            this.searchBar.BorderRadius = 30;
            this.searchBar.BorderThickness = 1;
            this.searchBar.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.searchBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchBar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.DefaultFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.DefaultText = "";
            this.searchBar.FillColor = System.Drawing.Color.LightGray;
            this.searchBar.HideSelection = true;
            this.searchBar.IconLeft = null;
            this.searchBar.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.IconPadding = 10;
            this.searchBar.IconRight = global::CampusNex.Properties.Resources.searchIcon;
            this.searchBar.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.Lines = new string[0];
            this.searchBar.Location = new System.Drawing.Point(69, 52);
            this.searchBar.MaxLength = 32767;
            this.searchBar.MinimumSize = new System.Drawing.Size(1, 1);
            this.searchBar.Modified = false;
            this.searchBar.Multiline = false;
            this.searchBar.Name = "searchBar";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            stateProperties1.FillColor = System.Drawing.Color.White;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBar.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.searchBar.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.White;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBar.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.LightGray;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Transparent;
            this.searchBar.OnIdleState = stateProperties4;
            this.searchBar.Padding = new System.Windows.Forms.Padding(3);
            this.searchBar.PasswordChar = '\0';
            this.searchBar.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.searchBar.PlaceholderText = "Search Societies";
            this.searchBar.ReadOnly = false;
            this.searchBar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchBar.SelectedText = "";
            this.searchBar.SelectionLength = 0;
            this.searchBar.SelectionStart = 0;
            this.searchBar.ShortcutsEnabled = true;
            this.searchBar.Size = new System.Drawing.Size(525, 41);
            this.searchBar.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.searchBar.TabIndex = 1;
            this.searchBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchBar.TextMarginBottom = 0;
            this.searchBar.TextMarginLeft = 10;
            this.searchBar.TextMarginTop = 1;
            this.searchBar.TextPlaceholder = "Search Societies";
            this.searchBar.UseSystemPasswordChar = false;
            this.searchBar.WordWrap = true;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // EventsPage
            // 
            this.EventsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.EventsPage.Location = new System.Drawing.Point(4, 4);
            this.EventsPage.Name = "EventsPage";
            this.EventsPage.Padding = new System.Windows.Forms.Padding(3);
            this.EventsPage.Size = new System.Drawing.Size(1071, 703);
            this.EventsPage.TabIndex = 1;
            this.EventsPage.Text = "Events";
            // 
            // Requests
            // 
            this.Requests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.Requests.Controls.Add(this.socReqGrid);
            this.Requests.Controls.Add(this.reqLabel2);
            this.Requests.Controls.Add(this.reqLabel1);
            this.Requests.Location = new System.Drawing.Point(4, 4);
            this.Requests.Name = "Requests";
            this.Requests.Padding = new System.Windows.Forms.Padding(3);
            this.Requests.Size = new System.Drawing.Size(1071, 703);
            this.Requests.TabIndex = 2;
            this.Requests.Text = "Requests";
            // 
            // socReqGrid
            // 
            this.socReqGrid.AllowUserToAddRows = false;
            this.socReqGrid.AllowUserToDeleteRows = false;
            this.socReqGrid.AllowUserToOrderColumns = true;
            this.socReqGrid.AllowUserToResizeRows = false;
            this.socReqGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.socReqGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.socReqGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.socReqGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.socReqGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.socReqGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.socReqGrid.ColumnHeadersHeight = 30;
            this.socReqGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.socReqGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soclogo,
            this.socName,
            this.reqStatus,
            this.viewDetails,
            this.AcceptReg});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.socReqGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.socReqGrid.EnableHeadersVisualStyles = false;
            this.socReqGrid.Location = new System.Drawing.Point(43, 115);
            this.socReqGrid.Name = "socReqGrid";
            this.socReqGrid.ReadOnly = true;
            this.socReqGrid.RowHeadersVisible = false;
            this.socReqGrid.RowTemplate.Height = 40;
            this.socReqGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.socReqGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.socReqGrid.Size = new System.Drawing.Size(784, 225);
            this.socReqGrid.TabIndex = 2;
            this.socReqGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.socReqGrid_CellContentClick);
            // 
            // soclogo
            // 
            this.soclogo.FillWeight = 30F;
            this.soclogo.HeaderText = "";
            this.soclogo.Name = "soclogo";
            this.soclogo.ReadOnly = true;
            // 
            // socName
            // 
            this.socName.HeaderText = "Society Name";
            this.socName.Name = "socName";
            this.socName.ReadOnly = true;
            // 
            // reqStatus
            // 
            this.reqStatus.HeaderText = "Student Name";
            this.reqStatus.Name = "reqStatus";
            this.reqStatus.ReadOnly = true;
            this.reqStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reqStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // viewDetails
            // 
            this.viewDetails.HeaderText = "View Request";
            this.viewDetails.Name = "viewDetails";
            this.viewDetails.ReadOnly = true;
            // 
            // AcceptReg
            // 
            this.AcceptReg.HeaderText = "Accept";
            this.AcceptReg.Name = "AcceptReg";
            this.AcceptReg.ReadOnly = true;
            // 
            // reqLabel2
            // 
            this.reqLabel2.AllowParentOverrides = false;
            this.reqLabel2.AutoEllipsis = false;
            this.reqLabel2.CursorType = null;
            this.reqLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqLabel2.ForeColor = System.Drawing.Color.White;
            this.reqLabel2.Location = new System.Drawing.Point(43, 346);
            this.reqLabel2.Name = "reqLabel2";
            this.reqLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reqLabel2.Size = new System.Drawing.Size(195, 29);
            this.reqLabel2.TabIndex = 1;
            this.reqLabel2.Text = "Events Requests";
            this.reqLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.reqLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // reqLabel1
            // 
            this.reqLabel1.AllowParentOverrides = false;
            this.reqLabel1.AutoEllipsis = false;
            this.reqLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.reqLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.reqLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqLabel1.ForeColor = System.Drawing.Color.White;
            this.reqLabel1.Location = new System.Drawing.Point(43, 66);
            this.reqLabel1.Name = "reqLabel1";
            this.reqLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reqLabel1.Size = new System.Drawing.Size(203, 29);
            this.reqLabel1.TabIndex = 0;
            this.reqLabel1.Text = "Society Requests";
            this.reqLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.reqLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AceCodersLogo.png");
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // Mentor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.StudentPages);
            this.Controls.Add(this.panel1);
            this.Name = "Mentor";
            this.Text = "Mentor";
            this.Load += new System.EventHandler(this.Mentor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StudentPages.ResumeLayout(false);
            this.SocietiesPage.ResumeLayout(false);
            this.SocietiesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.Requests.ResumeLayout(false);
            this.Requests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socReqGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton societiesBtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton eventsBtn;
        private Bunifu.UI.WinForms.BunifuPages StudentPages;
        private System.Windows.Forms.TabPage SocietiesPage;
        private System.Windows.Forms.TabPage EventsPage;
        private Bunifu.UI.WinForms.BunifuTextBox searchBar;
        private Bunifu.UI.WinForms.BunifuLabel userName;
        private Bunifu.UI.WinForms.BunifuPictureBox userPic;
        private System.Windows.Forms.FlowLayoutPanel societyCardsPanel;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton reqBtn;
        private System.Windows.Forms.TabPage Requests;
        private Bunifu.UI.WinForms.BunifuLabel reqLabel1;
        private Bunifu.UI.WinForms.BunifuLabel reqLabel2;
        private System.Windows.Forms.DataGridView socReqGrid;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewImageColumn soclogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn socName;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqStatus;
        private System.Windows.Forms.DataGridViewButtonColumn viewDetails;
        private System.Windows.Forms.DataGridViewButtonColumn AcceptReg;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
    }
}