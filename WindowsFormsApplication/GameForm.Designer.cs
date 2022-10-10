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
            this.Pawn1RadioButton = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Pawn1Picture = new System.Windows.Forms.PictureBox();
            this.Pawn2Picture = new System.Windows.Forms.PictureBox();
            this.Pawn2RadioButton = new System.Windows.Forms.RadioButton();
            this.Pawn3Picture = new System.Windows.Forms.PictureBox();
            this.Pawn3RadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(34, 391);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(45, 15);
            this.Player1Label.TabIndex = 5;
            this.Player1Label.Text = "Player1";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(34, 415);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(45, 15);
            this.Player2Label.TabIndex = 6;
            this.Player2Label.Text = "Player2";
            // 
            // Player1Name
            // 
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(141, 391);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(25, 15);
            this.Player1Name.TabIndex = 7;
            this.Player1Name.Text = "xxx";
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(141, 415);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(25, 15);
            this.Player2Name.TabIndex = 8;
            this.Player2Name.Text = "yyy";
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayersLabel.Location = new System.Drawing.Point(34, 355);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(72, 25);
            this.PlayersLabel.TabIndex = 12;
            this.PlayersLabel.Text = "Players";
            // 
            // Player1FactionColor
            // 
            this.Player1FactionColor.AutoSize = true;
            this.Player1FactionColor.BackColor = System.Drawing.Color.Red;
            this.Player1FactionColor.Location = new System.Drawing.Point(12, 391);
            this.Player1FactionColor.Name = "Player1FactionColor";
            this.Player1FactionColor.Size = new System.Drawing.Size(16, 15);
            this.Player1FactionColor.TabIndex = 15;
            this.Player1FactionColor.Text = "   ";
            // 
            // Player2FactionColor
            // 
            this.Player2FactionColor.AutoSize = true;
            this.Player2FactionColor.BackColor = System.Drawing.Color.Red;
            this.Player2FactionColor.Location = new System.Drawing.Point(12, 415);
            this.Player2FactionColor.Name = "Player2FactionColor";
            this.Player2FactionColor.Size = new System.Drawing.Size(16, 15);
            this.Player2FactionColor.TabIndex = 16;
            this.Player2FactionColor.Text = "   ";
            // 
            // Pawn1RadioButton
            // 
            this.Pawn1RadioButton.AutoSize = true;
            this.Pawn1RadioButton.Checked = true;
            this.Pawn1RadioButton.Location = new System.Drawing.Point(88, 89);
            this.Pawn1RadioButton.Name = "Pawn1RadioButton";
            this.Pawn1RadioButton.Size = new System.Drawing.Size(14, 13);
            this.Pawn1RadioButton.TabIndex = 17;
            this.Pawn1RadioButton.TabStop = true;
            this.Pawn1RadioButton.UseVisualStyleBackColor = true;
            this.Pawn1RadioButton.CheckedChanged += new System.EventHandler(this.Pawn1RadioButton_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Pawn1Picture
            // 
            this.Pawn1Picture.Location = new System.Drawing.Point(12, 62);
            this.Pawn1Picture.Name = "Pawn1Picture";
            this.Pawn1Picture.Size = new System.Drawing.Size(70, 70);
            this.Pawn1Picture.TabIndex = 18;
            this.Pawn1Picture.TabStop = false;
            // 
            // Pawn2Picture
            // 
            this.Pawn2Picture.Location = new System.Drawing.Point(12, 138);
            this.Pawn2Picture.Name = "Pawn2Picture";
            this.Pawn2Picture.Size = new System.Drawing.Size(70, 70);
            this.Pawn2Picture.TabIndex = 20;
            this.Pawn2Picture.TabStop = false;
            // 
            // Pawn2RadioButton
            // 
            this.Pawn2RadioButton.AutoSize = true;
            this.Pawn2RadioButton.Location = new System.Drawing.Point(88, 165);
            this.Pawn2RadioButton.Name = "Pawn2RadioButton";
            this.Pawn2RadioButton.Size = new System.Drawing.Size(14, 13);
            this.Pawn2RadioButton.TabIndex = 19;
            this.Pawn2RadioButton.UseVisualStyleBackColor = true;
            this.Pawn2RadioButton.CheckedChanged += new System.EventHandler(this.Pawn2RadioButton_CheckedChanged);
            // 
            // Pawn3Picture
            // 
            this.Pawn3Picture.Location = new System.Drawing.Point(12, 214);
            this.Pawn3Picture.Name = "Pawn3Picture";
            this.Pawn3Picture.Size = new System.Drawing.Size(70, 70);
            this.Pawn3Picture.TabIndex = 22;
            this.Pawn3Picture.TabStop = false;
            // 
            // Pawn3RadioButton
            // 
            this.Pawn3RadioButton.AutoSize = true;
            this.Pawn3RadioButton.Location = new System.Drawing.Point(88, 241);
            this.Pawn3RadioButton.Name = "Pawn3RadioButton";
            this.Pawn3RadioButton.Size = new System.Drawing.Size(14, 13);
            this.Pawn3RadioButton.TabIndex = 21;
            this.Pawn3RadioButton.UseVisualStyleBackColor = true;
            this.Pawn3RadioButton.CheckedChanged += new System.EventHandler(this.Pawn3RadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 50);
            this.label1.TabIndex = 23;
            this.label1.Text = "Spawnable\r\nPawns";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pawn3Picture);
            this.Controls.Add(this.Pawn3RadioButton);
            this.Controls.Add(this.Pawn2Picture);
            this.Controls.Add(this.Pawn2RadioButton);
            this.Controls.Add(this.Pawn1Picture);
            this.Controls.Add(this.Pawn1RadioButton);
            this.Controls.Add(this.Player2FactionColor);
            this.Controls.Add(this.Player1FactionColor);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pawn1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pawn3Picture)).EndInit();
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
        private RadioButton Pawn1RadioButton;
        private ImageList imageList1;
        private PictureBox Pawn1Picture;
        private PictureBox Pawn2Picture;
        private RadioButton Pawn2RadioButton;
        private PictureBox Pawn3Picture;
        private RadioButton Pawn3RadioButton;
        private Label label1;
    }
}