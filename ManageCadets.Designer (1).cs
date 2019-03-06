namespace Lee_Hooymans_V1
{
    partial class ManageCadets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCadets));
            this.table1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jah_Lab2_DBDataSet = new Lee_Hooymans_V1.jah_Lab2_DBDataSet();
            this.cadetsDataSet = new Lee_Hooymans_V1.CadetsDataSet();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1TableAdapter = new Lee_Hooymans_V1.CadetsDataSetTableAdapters.Table1TableAdapter();
            this.table1TableAdapter1 = new Lee_Hooymans_V1.jah_Lab2_DBDataSetTableAdapters.Table1TableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cadetNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cadetCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jah_Lab2_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadetsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // table1BindingSource1
            // 
            this.table1BindingSource1.DataMember = "Table1";
            this.table1BindingSource1.DataSource = this.jah_Lab2_DBDataSet;
            // 
            // jah_Lab2_DBDataSet
            // 
            this.jah_Lab2_DBDataSet.DataSetName = "jah_Lab2_DBDataSet";
            this.jah_Lab2_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cadetsDataSet
            // 
            this.cadetsDataSet.DataSetName = "CadetsDataSet";
            this.cadetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "Table1";
            this.table1BindingSource.DataSource = this.cadetsDataSet;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // table1TableAdapter1
            // 
            this.table1TableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.cadetNameDataGridViewTextBoxColumn,
            this.cadetCodeDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.pINDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.table1BindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 245);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // cadetNameDataGridViewTextBoxColumn
            // 
            this.cadetNameDataGridViewTextBoxColumn.DataPropertyName = "CadetName";
            this.cadetNameDataGridViewTextBoxColumn.HeaderText = "CadetName";
            this.cadetNameDataGridViewTextBoxColumn.Name = "cadetNameDataGridViewTextBoxColumn";
            // 
            // cadetCodeDataGridViewTextBoxColumn
            // 
            this.cadetCodeDataGridViewTextBoxColumn.DataPropertyName = "CadetCode";
            this.cadetCodeDataGridViewTextBoxColumn.HeaderText = "CadetCode";
            this.cadetCodeDataGridViewTextBoxColumn.Name = "cadetCodeDataGridViewTextBoxColumn";
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            // 
            // pINDataGridViewTextBoxColumn
            // 
            this.pINDataGridViewTextBoxColumn.DataPropertyName = "PIN";
            this.pINDataGridViewTextBoxColumn.HeaderText = "PIN";
            this.pINDataGridViewTextBoxColumn.Name = "pINDataGridViewTextBoxColumn";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 269);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "Import List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 308);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // ManageCadets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 406);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageCadets";
            this.Text = "ManageCadets";
            this.Load += new System.EventHandler(this.ManageCadets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jah_Lab2_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadetsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CadetsDataSet cadetsDataSet;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private CadetsDataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private jah_Lab2_DBDataSet jah_Lab2_DBDataSet;
        private System.Windows.Forms.BindingSource table1BindingSource1;
        private jah_Lab2_DBDataSetTableAdapters.Table1TableAdapter table1TableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cadetNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cadetCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pINDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}