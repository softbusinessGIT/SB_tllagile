namespace SB_tllagile
{
    partial class PainelLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.RecupButton = new System.Windows.Forms.Button();
            this.EntrarButton = new System.Windows.Forms.Button();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.UserText = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.RecupPanel = new System.Windows.Forms.Panel();
            this.RecupLabel = new System.Windows.Forms.Label();
            this.CancelRecupButton = new System.Windows.Forms.Button();
            this.PassRecupText = new System.Windows.Forms.TextBox();
            this.PassConfRecupText = new System.Windows.Forms.TextBox();
            this.UserRecupText = new System.Windows.Forms.TextBox();
            this.PassConfLabelRecup = new System.Windows.Forms.Label();
            this.PassLabelRecup = new System.Windows.Forms.Label();
            this.UserLabelRecup = new System.Windows.Forms.Label();
            this.AplicarRecupButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.RecupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LoginPanel);
            this.panel1.Controls.Add(this.RecupPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 537);
            this.panel1.TabIndex = 0;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.LoginLabel);
            this.LoginPanel.Controls.Add(this.RecupButton);
            this.LoginPanel.Controls.Add(this.EntrarButton);
            this.LoginPanel.Controls.Add(this.PasswordText);
            this.LoginPanel.Controls.Add(this.UserText);
            this.LoginPanel.Controls.Add(this.UserLabel);
            this.LoginPanel.Controls.Add(this.PasswordLabel);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(933, 537);
            this.LoginPanel.TabIndex = 2;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(392, 78);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(120, 24);
            this.LoginLabel.TabIndex = 6;
            this.LoginLabel.Text = "Página Login";
            // 
            // RecupButton
            // 
            this.RecupButton.Location = new System.Drawing.Point(465, 297);
            this.RecupButton.Name = "RecupButton";
            this.RecupButton.Size = new System.Drawing.Size(91, 39);
            this.RecupButton.TabIndex = 5;
            this.RecupButton.Text = "Recuperar Pass";
            this.RecupButton.UseVisualStyleBackColor = true;
            this.RecupButton.Click += new System.EventHandler(this.RecupButton_Click);
            // 
            // EntrarButton
            // 
            this.EntrarButton.Location = new System.Drawing.Point(371, 297);
            this.EntrarButton.Name = "EntrarButton";
            this.EntrarButton.Size = new System.Drawing.Size(88, 39);
            this.EntrarButton.TabIndex = 4;
            this.EntrarButton.Text = "Entrar";
            this.EntrarButton.UseVisualStyleBackColor = true;
            this.EntrarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(456, 256);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(100, 20);
            this.PasswordText.TabIndex = 3;
            this.PasswordText.Text = "12345";
            this.PasswordText.UseSystemPasswordChar = true;
            // 
            // UserText
            // 
            this.UserText.Location = new System.Drawing.Point(456, 212);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(100, 20);
            this.UserText.TabIndex = 2;
            this.UserText.Text = "fmalmeida";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(368, 215);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(58, 13);
            this.UserLabel.TabIndex = 0;
            this.UserLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(368, 256);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // RecupPanel
            // 
            this.RecupPanel.Controls.Add(this.RecupLabel);
            this.RecupPanel.Controls.Add(this.CancelRecupButton);
            this.RecupPanel.Controls.Add(this.PassRecupText);
            this.RecupPanel.Controls.Add(this.PassConfRecupText);
            this.RecupPanel.Controls.Add(this.UserRecupText);
            this.RecupPanel.Controls.Add(this.PassConfLabelRecup);
            this.RecupPanel.Controls.Add(this.PassLabelRecup);
            this.RecupPanel.Controls.Add(this.UserLabelRecup);
            this.RecupPanel.Controls.Add(this.AplicarRecupButton);
            this.RecupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecupPanel.Location = new System.Drawing.Point(0, 0);
            this.RecupPanel.Name = "RecupPanel";
            this.RecupPanel.Size = new System.Drawing.Size(933, 537);
            this.RecupPanel.TabIndex = 7;
            // 
            // RecupLabel
            // 
            this.RecupLabel.AutoSize = true;
            this.RecupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecupLabel.Location = new System.Drawing.Point(351, 78);
            this.RecupLabel.Name = "RecupLabel";
            this.RecupLabel.Size = new System.Drawing.Size(219, 24);
            this.RecupLabel.TabIndex = 9;
            this.RecupLabel.Text = "Página de Recuperação ";
            // 
            // CancelRecupButton
            // 
            this.CancelRecupButton.Location = new System.Drawing.Point(475, 288);
            this.CancelRecupButton.Name = "CancelRecupButton";
            this.CancelRecupButton.Size = new System.Drawing.Size(90, 40);
            this.CancelRecupButton.TabIndex = 8;
            this.CancelRecupButton.Text = "Cancelar";
            this.CancelRecupButton.UseVisualStyleBackColor = true;
            this.CancelRecupButton.Click += new System.EventHandler(this.CancelRecupButton_Click);
            // 
            // PassRecupText
            // 
            this.PassRecupText.Location = new System.Drawing.Point(465, 215);
            this.PassRecupText.Name = "PassRecupText";
            this.PassRecupText.Size = new System.Drawing.Size(100, 20);
            this.PassRecupText.TabIndex = 7;
            // 
            // PassConfRecupText
            // 
            this.PassConfRecupText.Location = new System.Drawing.Point(465, 249);
            this.PassConfRecupText.Name = "PassConfRecupText";
            this.PassConfRecupText.Size = new System.Drawing.Size(100, 20);
            this.PassConfRecupText.TabIndex = 6;
            // 
            // UserRecupText
            // 
            this.UserRecupText.Location = new System.Drawing.Point(465, 179);
            this.UserRecupText.Name = "UserRecupText";
            this.UserRecupText.Size = new System.Drawing.Size(100, 20);
            this.UserRecupText.TabIndex = 5;
            // 
            // PassConfLabelRecup
            // 
            this.PassConfLabelRecup.AutoSize = true;
            this.PassConfLabelRecup.Location = new System.Drawing.Point(352, 252);
            this.PassConfLabelRecup.Name = "PassConfLabelRecup";
            this.PassConfLabelRecup.Size = new System.Drawing.Size(103, 13);
            this.PassConfLabelRecup.TabIndex = 4;
            this.PassConfLabelRecup.Text = "Confirmar Password:";
            // 
            // PassLabelRecup
            // 
            this.PassLabelRecup.AutoSize = true;
            this.PassLabelRecup.Location = new System.Drawing.Point(352, 219);
            this.PassLabelRecup.Name = "PassLabelRecup";
            this.PassLabelRecup.Size = new System.Drawing.Size(56, 13);
            this.PassLabelRecup.TabIndex = 3;
            this.PassLabelRecup.Text = "Password:";
            // 
            // UserLabelRecup
            // 
            this.UserLabelRecup.AutoSize = true;
            this.UserLabelRecup.Location = new System.Drawing.Point(352, 182);
            this.UserLabelRecup.Name = "UserLabelRecup";
            this.UserLabelRecup.Size = new System.Drawing.Size(53, 13);
            this.UserLabelRecup.TabIndex = 2;
            this.UserLabelRecup.Text = "Utilizador:";
            // 
            // AplicarRecupButton
            // 
            this.AplicarRecupButton.Location = new System.Drawing.Point(355, 288);
            this.AplicarRecupButton.Name = "AplicarRecupButton";
            this.AplicarRecupButton.Size = new System.Drawing.Size(90, 40);
            this.AplicarRecupButton.TabIndex = 0;
            this.AplicarRecupButton.Text = "Aplicar";
            this.AplicarRecupButton.UseVisualStyleBackColor = true;
            // 
            // PainelLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 537);
            this.Controls.Add(this.panel1);
            this.Name = "PainelLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SB-TLLAGILE";
            this.panel1.ResumeLayout(false);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.RecupPanel.ResumeLayout(false);
            this.RecupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button RecupButton;
        private System.Windows.Forms.Button EntrarButton;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox UserText;
        private System.Windows.Forms.Panel RecupPanel;
        private System.Windows.Forms.Button CancelRecupButton;
        private System.Windows.Forms.TextBox PassRecupText;
        private System.Windows.Forms.TextBox PassConfRecupText;
        private System.Windows.Forms.TextBox UserRecupText;
        private System.Windows.Forms.Label PassConfLabelRecup;
        private System.Windows.Forms.Label PassLabelRecup;
        private System.Windows.Forms.Label UserLabelRecup;
        private System.Windows.Forms.Button AplicarRecupButton;
        private System.Windows.Forms.Label RecupLabel;
    }
}

