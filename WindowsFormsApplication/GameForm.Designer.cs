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
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.GameStartedLabel = new System.Windows.Forms.Label();
            this.Player1FactionColor = new System.Windows.Forms.Label();
            this.Player2FactionColor = new System.Windows.Forms.Label();
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
            // GameStartedLabel
            // 
            this.GameStartedLabel.AutoSize = true;
            this.GameStartedLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameStartedLabel.Location = new System.Drawing.Point(263, 37);
            this.GameStartedLabel.Name = "GameStartedLabel";
            this.GameStartedLabel.Size = new System.Drawing.Size(272, 32);
            this.GameStartedLabel.TabIndex = 14;
            this.GameStartedLabel.Text = "The Game Has Started!!!";
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Player2FactionColor);
            this.Controls.Add(this.Player1FactionColor);
            this.Controls.Add(this.GameStartedLabel);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Name = "GameForm";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Player1Label;
        private Label Player2Label;
        private Label Player1Name;
        private Label Player2Name;
        private Label PlayersLabel;
        private Label GameStartedLabel;
        private Label Player1FactionColor;
        private Label Player2FactionColor;
    }
}