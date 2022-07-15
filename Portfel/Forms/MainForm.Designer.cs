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
            this.expenseBox = new System.Windows.Forms.TextBox();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.WasteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.displayExpense = new System.Windows.Forms.Button();
            this.displayIncome = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.raportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WelcomeLabel.Location = new System.Drawing.Point(214, 28);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(419, 46);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Witaj w aplikacji Portfel 1.0";
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
            // expenseBox
            // 
            this.expenseBox.Location = new System.Drawing.Point(36, 160);
            this.expenseBox.Name = "expenseBox";
            this.expenseBox.Size = new System.Drawing.Size(100, 23);
            this.expenseBox.TabIndex = 4;
            // 
            // productComboBox
            // 
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Items.AddRange(new object[] {
            "Opłaty",
            "Produkty spożywcze",
            "Środki czyszczące",
            "Paliwo"});
            this.productComboBox.Location = new System.Drawing.Point(163, 160);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(121, 23);
            this.productComboBox.TabIndex = 5;
            // 
            // WasteButton
            // 
            this.WasteButton.Location = new System.Drawing.Point(311, 157);
            this.WasteButton.Name = "WasteButton";
            this.WasteButton.Size = new System.Drawing.Size(111, 26);
            this.WasteButton.TabIndex = 6;
            this.WasteButton.Text = "Dodaj wydatek";
            this.WasteButton.UseVisualStyleBackColor = true;
            this.WasteButton.Click += new System.EventHandler(this.WasteButton_Click);
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
            // displayExpense
            // 
            this.displayExpense.Location = new System.Drawing.Point(625, 108);
            this.displayExpense.Name = "displayExpense";
            this.displayExpense.Size = new System.Drawing.Size(140, 25);
            this.displayExpense.TabIndex = 9;
            this.displayExpense.Text = "Wyświetl wydatki";
            this.displayExpense.UseVisualStyleBackColor = true;
            this.displayExpense.Click += new System.EventHandler(this.displayExpense_Click);
            // 
            // displayIncome
            // 
            this.displayIncome.Location = new System.Drawing.Point(625, 160);
            this.displayIncome.Name = "displayIncome";
            this.displayIncome.Size = new System.Drawing.Size(140, 25);
            this.displayIncome.TabIndex = 10;
            this.displayIncome.Text = "Wyświetl dochody";
            this.displayIncome.UseVisualStyleBackColor = true;
            this.displayIncome.Click += new System.EventHandler(this.displayIncome_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Value,
            this.Date,
            this.ProductName});
            this.dgv.Location = new System.Drawing.Point(12, 253);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 25;
            this.dgv.Size = new System.Drawing.Size(441, 132);
            this.dgv.TabIndex = 11;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ExpenseId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Kwota";
            this.Value.Name = "Value";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Data";
            this.Date.Name = "Date";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Produkt";
            this.ProductName.Name = "ProductName";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv2.Location = new System.Drawing.Point(12, 253);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowTemplate.Height = 25;
            this.dgv2.Size = new System.Drawing.Size(342, 132);
            this.dgv2.TabIndex = 12;
            this.dgv2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IncomeId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Kwota";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // raportButton
            // 
            this.raportButton.Location = new System.Drawing.Point(605, 232);
            this.raportButton.Name = "raportButton";
            this.raportButton.Size = new System.Drawing.Size(160, 32);
            this.raportButton.TabIndex = 13;
            this.raportButton.Text = "Generuj raport";
            this.raportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.raportButton.UseVisualStyleBackColor = true;
            this.raportButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.raportButton);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.displayIncome);
            this.Controls.Add(this.displayExpense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WasteButton);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.expenseBox);
            this.Controls.Add(this.ProfitButton);
            this.Controls.Add(this.profitBox);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomeLabel;
        private MonthCalendar monthCalendar1;
        private TextBox profitBox;
        private Button ProfitButton;
        private TextBox expenseBox;
        private ComboBox productComboBox;
        private Button WasteButton;
        private Label label1;
        private Button displayExpense;
        private Button displayIncome;
        private DataGridView dgv;
        private DataGridView dgv2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button raportButton;
    }
}