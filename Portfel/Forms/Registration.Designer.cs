namespace Portfel.Forms
{
    partial class Registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(356, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(335, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(346, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-Mail";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(346, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hasło";
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(309, 40);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(144, 23);
            this.firstNameBox.TabIndex = 4;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(311, 107);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(142, 23);
            this.lastNameBox.TabIndex = 5;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(311, 186);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(144, 23);
            this.emailBox.TabIndex = 6;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(313, 254);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(142, 23);
            this.passwordBox.TabIndex = 7;
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(532, 155);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(125, 64);
            this.signUpButton.TabIndex = 8;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(311, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Potwierdź hasło";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(313, 338);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.Size = new System.Drawing.Size(142, 23);
            this.confirmPasswordBox.TabIndex = 10;
            this.confirmPasswordBox.TextChanged += new System.EventHandler(this.confirmPasswordBox_TextChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox firstNameBox;
        private TextBox lastNameBox;
        private TextBox emailBox;
        private TextBox passwordBox;
        private Button signUpButton;
        private Label label5;
        private TextBox confirmPasswordBox;
    }
}