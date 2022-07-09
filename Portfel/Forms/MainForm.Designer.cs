namespace Portfel.Forms
{
    partial class MainForm
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.profitBox = new System.Windows.Forms.TextBox();
            this.ProfitButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.WasteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WelcomeLabel.Location = new System.Drawing.Point(334, 39);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(109, 46);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "label1";
            this.WelcomeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(574, 290);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // profitBox
            // 
            this.profitBox.Location = new System.Drawing.Point(36, 108);
            this.profitBox.Name = "profitBox";
            this.profitBox.Size = new System.Drawing.Size(100, 23);
            this.profitBox.TabIndex = 2;
            // 
            // ProfitButton
            // 
            this.ProfitButton.Location = new System.Drawing.Point(163, 108);
            this.ProfitButton.Name = "ProfitButton";
            this.ProfitButton.Size = new System.Drawing.Size(121, 23);
            this.ProfitButton.TabIndex = 3;
            this.ProfitButton.Text = "Dodaj dochód";
            this.ProfitButton.UseVisualStyleBackColor = true;
            this.ProfitButton.Click += new System.EventHandler(this.ProfitButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(36, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Opłaty",
            "Produkty spożywcze",
            "Środki czyszczące",
            "Paliwo"});
            this.comboBox1.Location = new System.Drawing.Point(163, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // WasteButton
            // 
            this.WasteButton.Location = new System.Drawing.Point(311, 157);
            this.WasteButton.Name = "WasteButton";
            this.WasteButton.Size = new System.Drawing.Size(111, 26);
            this.WasteButton.TabIndex = 6;
            this.WasteButton.Text = "Dodaj wydatek";
            this.WasteButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WasteButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ProfitButton);
            this.Controls.Add(this.profitBox);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomeLabel;
        private MonthCalendar monthCalendar1;
        private TextBox profitBox;
        private Button ProfitButton;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Button WasteButton;
        private Label label1;
    }
}