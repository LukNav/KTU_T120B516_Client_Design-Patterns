namespace WindowsFormsApplication
{
    partial class MenuForm
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SubmitNameButton = new System.Windows.Forms.Button();
            this.EnterNameLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.ReadyToPlayButton = new System.Windows.Forms.Button();
            this.ReadyToPlayLabel = new System.Windows.Forms.Label();
            this.WaitingForPlayersLabel = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.GameStartedLabel = new System.Windows.Forms.Label();
            this.Player1FactionColor = new System.Windows.Forms.Label();
            this.Player2FactionColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(350, 193);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(91, 23);
            this.NameTextBox.TabIndex = 0;
            // 
            // SubmitNameButton
            // 
            this.SubmitNameButton.Location = new System.Drawing.Point(447, 193);
            this.SubmitNameButton.Name = "SubmitNameButton";
            this.SubmitNameButton.Size = new System.Drawing.Size(88, 23);
            this.SubmitNameButton.TabIndex = 1;
            this.SubmitNameButton.Text = "Start Session";
            this.SubmitNameButton.UseVisualStyleBackColor = true;
            this.SubmitNameButton.Click += new System.EventHandler(this.SubmitNameButton_Click);
            // 
            // EnterNameLabel
            // 
            this.EnterNameLabel.AutoSize = true;
            this.EnterNameLabel.Location = new System.Drawing.Point(248, 197);
            this.EnterNameLabel.Name = "EnterNameLabel";
            this.EnterNameLabel.Size = new System.Drawing.Size(96, 15);
            this.EnterNameLabel.TabIndex = 3;
            this.EnterNameLabel.Text = "Enter your Name";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(345, 165);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.ErrorLabel.TabIndex = 4;
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(34, 391);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(45, 15);
            this.Player1Label.TabIndex = 5;
            this.Player1Label.Text = "Player1";
            this.Player1Label.Visible = false;
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(34, 415);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(45, 15);
            this.Player2Label.TabIndex = 6;
            this.Player2Label.Text = "Player2";
            this.Player2Label.Visible = false;
            // 
            // Player1Name
            // 
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(141, 391);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(25, 15);
            this.Player1Name.TabIndex = 7;
            this.Player1Name.Text = "xxx";
            this.Player1Name.Visible = false;
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(141, 415);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(25, 15);
            this.Player2Name.TabIndex = 8;
            this.Player2Name.Text = "yyy";
            this.Player2Name.Visible = false;
            // 
            // ReadyToPlayButton
            // 
            this.ReadyToPlayButton.Location = new System.Drawing.Point(353, 164);
            this.ReadyToPlayButton.Name = "ReadyToPlayButton";
            this.ReadyToPlayButton.Size = new System.Drawing.Size(88, 23);
            this.ReadyToPlayButton.TabIndex = 9;
            this.ReadyToPlayButton.Text = "Ready";
            this.ReadyToPlayButton.UseVisualStyleBackColor = true;
            this.ReadyToPlayButton.Visible = false;
            this.ReadyToPlayButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // ReadyToPlayLabel
            // 
            this.ReadyToPlayLabel.AutoSize = true;
            this.ReadyToPlayLabel.Location = new System.Drawing.Point(335, 146);
            this.ReadyToPlayLabel.Name = "ReadyToPlayLabel";
            this.ReadyToPlayLabel.Size = new System.Drawing.Size(124, 15);
            this.ReadyToPlayLabel.TabIndex = 10;
            this.ReadyToPlayLabel.Text = "Are you ready to play?";
            this.ReadyToPlayLabel.Visible = false;
            // 
            // WaitingForPlayersLabel
            // 
            this.WaitingForPlayersLabel.AutoSize = true;
            this.WaitingForPlayersLabel.Location = new System.Drawing.Point(285, 180);
            this.WaitingForPlayersLabel.Name = "WaitingForPlayersLabel";
            this.WaitingForPlayersLabel.Size = new System.Drawing.Size(221, 15);
            this.WaitingForPlayersLabel.TabIndex = 11;
            this.WaitingForPlayersLabel.Text = "Waiting for players to join and get Ready";
            this.WaitingForPlayersLabel.Visible = false;
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
            this.PlayersLabel.Visible = false;
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
            this.GameStartedLabel.Visible = false;
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
            this.Player1FactionColor.Visible = false;
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
            this.Player2FactionColor.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Player2FactionColor);
            this.Controls.Add(this.Player1FactionColor);
            this.Controls.Add(this.GameStartedLabel);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.WaitingForPlayersLabel);
            this.Controls.Add(this.ReadyToPlayLabel);
            this.Controls.Add(this.ReadyToPlayButton);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.EnterNameLabel);
            this.Controls.Add(this.SubmitNameButton);
            this.Controls.Add(this.NameTextBox);
            this.Name = $"Menu: {Program.LocalHostPort}";
            this.Text = $"Menu: {Program.LocalHostPort}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox NameTextBox;
        private Button SubmitNameButton;
        private Label EnterNameLabel;
        private Label ErrorLabel;
        private Label Player1Label;
        private Label Player2Label;
        private Label Player1Name;
        private Label Player2Name;
        private Button ReadyToPlayButton;
        private Label ReadyToPlayLabel;
        private Label WaitingForPlayersLabel;
        private Label PlayersLabel;
        private Label GameStartedLabel;
        private Label Player1FactionColor;
        private Label Player2FactionColor;
    }
}