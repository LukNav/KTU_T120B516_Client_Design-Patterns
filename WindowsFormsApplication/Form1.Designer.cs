namespace WindowsFormsApplication
{
    partial class Form1
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.EnterNameLabel);
            this.Controls.Add(this.SubmitNameButton);
            this.Controls.Add(this.NameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox NameTextBox;
        private Button SubmitNameButton;
        private Label EnterNameLabel;
        private Label ErrorLabel;
    }
}