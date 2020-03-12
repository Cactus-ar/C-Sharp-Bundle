namespace GrillaTst
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.comboBox_filtersaved = new System.Windows.Forms.ComboBox();
            this.comboBox_sortsaved = new System.Windows.Forms.ComboBox();
            this.advancedDataGridViewSearchToolBar_main = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.textBox_sort = new System.Windows.Forms.TextBox();
            this.textBox_total = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(24, 110);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.Size = new System.Drawing.Size(1098, 297);
            this.advancedDataGridView_main.TabIndex = 0;
            // 
            // comboBox_filtersaved
            // 
            this.comboBox_filtersaved.FormattingEnabled = true;
            this.comboBox_filtersaved.Location = new System.Drawing.Point(46, 50);
            this.comboBox_filtersaved.Name = "comboBox_filtersaved";
            this.comboBox_filtersaved.Size = new System.Drawing.Size(281, 21);
            this.comboBox_filtersaved.TabIndex = 1;
            // 
            // comboBox_sortsaved
            // 
            this.comboBox_sortsaved.FormattingEnabled = true;
            this.comboBox_sortsaved.Location = new System.Drawing.Point(491, 50);
            this.comboBox_sortsaved.Name = "comboBox_sortsaved";
            this.comboBox_sortsaved.Size = new System.Drawing.Size(391, 21);
            this.comboBox_sortsaved.TabIndex = 2;
            // 
            // advancedDataGridViewSearchToolBar_main
            // 
            this.advancedDataGridViewSearchToolBar_main.AllowMerge = false;
            this.advancedDataGridViewSearchToolBar_main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.advancedDataGridViewSearchToolBar_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewSearchToolBar_main.MaximumSize = new System.Drawing.Size(0, 27);
            this.advancedDataGridViewSearchToolBar_main.MinimumSize = new System.Drawing.Size(0, 27);
            this.advancedDataGridViewSearchToolBar_main.Name = "advancedDataGridViewSearchToolBar_main";
            this.advancedDataGridViewSearchToolBar_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.advancedDataGridViewSearchToolBar_main.Size = new System.Drawing.Size(1346, 27);
            this.advancedDataGridViewSearchToolBar_main.TabIndex = 3;
            this.advancedDataGridViewSearchToolBar_main.Text = "advancedDataGridViewSearchToolBar1";
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(1166, 96);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(153, 20);
            this.textBox_filter.TabIndex = 4;
            // 
            // textBox_sort
            // 
            this.textBox_sort.Location = new System.Drawing.Point(1175, 153);
            this.textBox_sort.Name = "textBox_sort";
            this.textBox_sort.Size = new System.Drawing.Size(143, 20);
            this.textBox_sort.TabIndex = 5;
            // 
            // textBox_total
            // 
            this.textBox_total.Location = new System.Drawing.Point(1167, 221);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.Size = new System.Drawing.Size(168, 20);
            this.textBox_total.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 523);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.textBox_sort);
            this.Controls.Add(this.textBox_filter);
            this.Controls.Add(this.advancedDataGridViewSearchToolBar_main);
            this.Controls.Add(this.comboBox_sortsaved);
            this.Controls.Add(this.comboBox_filtersaved);
            this.Controls.Add(this.advancedDataGridView_main);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.ComboBox comboBox_filtersaved;
        private System.Windows.Forms.ComboBox comboBox_sortsaved;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar advancedDataGridViewSearchToolBar_main;
        private System.Windows.Forms.BindingSource bindingSource_main;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.TextBox textBox_sort;
        private System.Windows.Forms.TextBox textBox_total;
    }
}

