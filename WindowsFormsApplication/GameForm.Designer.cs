namespace WindowsFormsApplication
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1FactionColor = new System.Windows.Forms.Label();
            this.Player2FactionColor = new System.Windows.Forms.Label();
            this.Pawn1Picture = new System.Windows.Forms.PictureBox();
            this.Pawn2Picture = new System.Windows.Forms.PictureBox();
            this.Pawn3Picture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pawn3PictureHighlight = new System.Windows.Forms.PictureBox();
            this.Pawn2PictureHighlight = new System.Windows.Forms.PictureBox();
            this.Pawn1PictureHighlight = new System.Windows.Forms.PictureBox();
            this.SpawnPawnButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loadStateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3PictureHighlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2PictureHighlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1PictureHighlight)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(43, 1327);
            this.Player1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(69, 25);
            this.Player1Label.TabIndex = 5;
            this.Player1Label.Text = "Player1";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(43, 1367);
            this.Player2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(69, 25);
            this.Player2Label.TabIndex = 6;
            this.Player2Label.Text = "Player2";
            // 
            // Player1Name
            // 
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(196, 1327);
            this.Player1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(36, 25);
            this.Player1Name.TabIndex = 7;
            this.Player1Name.Text = "xxx";
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(196, 1367);
            this.Player2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(39, 25);
            this.Player2Name.TabIndex = 8;
            this.Player2Name.Text = "yyy";
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayersLabel.Location = new System.Drawing.Point(43, 1267);
            this.PlayersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(106, 40);
            this.PlayersLabel.TabIndex = 12;
            this.PlayersLabel.Text = "Players";
            // 
            // Player1FactionColor
            // 
            this.Player1FactionColor.AutoSize = true;
            this.Player1FactionColor.BackColor = System.Drawing.Color.Red;
            this.Player1FactionColor.Location = new System.Drawing.Point(11, 1327);
            this.Player1FactionColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1FactionColor.Name = "Player1FactionColor";
            this.Player1FactionColor.Size = new System.Drawing.Size(27, 25);
            this.Player1FactionColor.TabIndex = 15;
            this.Player1FactionColor.Text = "   ";
            // 
            // Player2FactionColor
            // 
            this.Player2FactionColor.AutoSize = true;
            this.Player2FactionColor.BackColor = System.Drawing.Color.Red;
            this.Player2FactionColor.Location = new System.Drawing.Point(11, 1367);
            this.Player2FactionColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2FactionColor.Name = "Player2FactionColor";
            this.Player2FactionColor.Size = new System.Drawing.Size(27, 25);
            this.Player2FactionColor.TabIndex = 16;
            this.Player2FactionColor.Text = "   ";
            // 
            // Pawn1Picture
            // 
            this.Pawn1Picture.Location = new System.Drawing.Point(43, 130);
            this.Pawn1Picture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pawn1Picture.Name = "Pawn1Picture";
            this.Pawn1Picture.Size = new System.Drawing.Size(100, 117);
            this.Pawn1Picture.TabIndex = 18;
            this.Pawn1Picture.TabStop = false;
            this.Pawn1Picture.Click += new System.EventHandler(this.Pawn1Picture_Click);
            // 
            // Pawn2Picture
            // 
            this.Pawn2Picture.Location = new System.Drawing.Point(43, 257);
            this.Pawn2Picture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pawn2Picture.Name = "Pawn2Picture";
            this.Pawn2Picture.Size = new System.Drawing.Size(100, 117);
            this.Pawn2Picture.TabIndex = 20;
            this.Pawn2Picture.TabStop = false;
            this.Pawn2Picture.Click += new System.EventHandler(this.Pawn2Picture_Click);
            // 
            // Pawn3Picture
            // 
            this.Pawn3Picture.Location = new System.Drawing.Point(43, 383);
            this.Pawn3Picture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pawn3Picture.Name = "Pawn3Picture";
            this.Pawn3Picture.Size = new System.Drawing.Size(100, 117);
            this.Pawn3Picture.TabIndex = 22;
            this.Pawn3Picture.TabStop = false;
            this.Pawn3Picture.Click += new System.EventHandler(this.Pawn3Picture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 40);
            this.label1.TabIndex = 23;
            this.label1.Text = "Your Troops";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pawn3PictureHighlight
            // 
            this.Pawn3PictureHighlight.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Pawn3PictureHighlight.Location = new System.Drawing.Point(36, 373);
            this.Pawn3PictureHighlight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pawn3PictureHighlight.Name = "Pawn3PictureHighlight";
            this.Pawn3PictureHighlight.Size = new System.Drawing.Size(114, 133);
            this.Pawn3PictureHighlight.TabIndex = 26;
            this.Pawn3PictureHighlight.TabStop = false;
            this.Pawn3PictureHighlight.Visible = false;
            // 
            // Pawn2PictureHighlight
            // 
            this.Pawn2PictureHighlight.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Pawn2PictureHighlight.Location = new System.Drawing.Point(36, 247);
            this.Pawn2PictureHighlight.Margin = new System.Windows.Forms.Padding(0);
            this.Pawn2PictureHighlight.Name = "Pawn2PictureHighlight";
            this.Pawn2PictureHighlight.Size = new System.Drawing.Size(114, 133);
            this.Pawn2PictureHighlight.TabIndex = 25;
            this.Pawn2PictureHighlight.TabStop = false;
            this.Pawn2PictureHighlight.Visible = false;
            // 
            // Pawn1PictureHighlight
            // 
            this.Pawn1PictureHighlight.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Pawn1PictureHighlight.Location = new System.Drawing.Point(36, 120);
            this.Pawn1PictureHighlight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pawn1PictureHighlight.Name = "Pawn1PictureHighlight";
            this.Pawn1PictureHighlight.Size = new System.Drawing.Size(114, 133);
            this.Pawn1PictureHighlight.TabIndex = 24;
            this.Pawn1PictureHighlight.TabStop = false;
            // 
            // SpawnPawnButton
            // 
            this.SpawnPawnButton.Location = new System.Drawing.Point(39, 517);
            this.SpawnPawnButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpawnPawnButton.Name = "SpawnPawnButton";
            this.SpawnPawnButton.Size = new System.Drawing.Size(107, 38);
            this.SpawnPawnButton.TabIndex = 27;
            this.SpawnPawnButton.Text = "Spawn";
            this.SpawnPawnButton.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // loadStateButton
            // 
            this.loadStateButton.Location = new System.Drawing.Point(17, 36);
            this.loadStateButton.Name = "loadStateButton";
            this.loadStateButton.Size = new System.Drawing.Size(187, 34);
            this.loadStateButton.TabIndex = 28;
            this.loadStateButton.Text = "TestLoadState";
            this.loadStateButton.UseVisualStyleBackColor = true;
            this.loadStateButton.Click += new System.EventHandler(this.loadStateButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 1500);
            this.Controls.Add(this.loadStateButton);
            this.Controls.Add(this.SpawnPawnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pawn3Picture);
            this.Controls.Add(this.Pawn2Picture);
            this.Controls.Add(this.Pawn1Picture);
            this.Controls.Add(this.Player2FactionColor);
            this.Controls.Add(this.Player1FactionColor);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.Pawn1PictureHighlight);
            this.Controls.Add(this.Pawn3PictureHighlight);
            this.Controls.Add(this.Pawn2PictureHighlight);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3PictureHighlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2PictureHighlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1PictureHighlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Player1Label;
        private Label Player2Label;
        private Label Player1Name;
        private Label Player2Name;
        private Label PlayersLabel;
        private Label Player1FactionColor;
        private Label Player2FactionColor;
        private ImageList imageList1;
        private PictureBox Pawn1Picture;
        private PictureBox Pawn2Picture;
        private PictureBox Pawn3Picture;
        private Label label1;
        private PictureBox Pawn3PictureHighlight;
        private PictureBox Pawn2PictureHighlight;
        private PictureBox Pawn1PictureHighlight;
        private Button SpawnPawnButton;
        private System.Windows.Forms.Timer timer1;
        private Button loadStateButton;
    }
}