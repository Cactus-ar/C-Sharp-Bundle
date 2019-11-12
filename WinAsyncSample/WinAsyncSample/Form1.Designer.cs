namespace WinAsyncSample
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_generar = new System.Windows.Forms.Button();
            this.txt_box = new System.Windows.Forms.TextBox();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_Abrir = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Procesa = new System.Windows.Forms.Button();
            this.conversorTexto = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(27, 35);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(125, 23);
            this.btn_generar.TabIndex = 0;
            this.btn_generar.Text = "Generar Texto";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // txt_box
            // 
            this.txt_box.Location = new System.Drawing.Point(27, 77);
            this.txt_box.Multiline = true;
            this.txt_box.Name = "txt_box";
            this.txt_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_box.Size = new System.Drawing.Size(387, 232);
            this.txt_box.TabIndex = 1;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(31, 332);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(121, 13);
            this.lbl_count.TabIndex = 2;
            this.lbl_count.Text = "Cantidad de Caracteres:";
            // 
            // btn_Abrir
            // 
            this.btn_Abrir.Location = new System.Drawing.Point(158, 35);
            this.btn_Abrir.Name = "btn_Abrir";
            this.btn_Abrir.Size = new System.Drawing.Size(125, 23);
            this.btn_Abrir.TabIndex = 3;
            this.btn_Abrir.Text = "Abrir Archivo";
            this.btn_Abrir.UseVisualStyleBackColor = true;
            this.btn_Abrir.Click += new System.EventHandler(this.btn_Abrir_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(289, 35);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(125, 23);
            this.btn_Guardar.TabIndex = 4;
            this.btn_Guardar.Text = "Guardar Archivo";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Procesa
            // 
            this.btn_Procesa.Location = new System.Drawing.Point(27, 358);
            this.btn_Procesa.Name = "btn_Procesa";
            this.btn_Procesa.Size = new System.Drawing.Size(387, 51);
            this.btn_Procesa.TabIndex = 5;
            this.btn_Procesa.Text = "Procesar";
            this.btn_Procesa.UseVisualStyleBackColor = true;
            this.btn_Procesa.Click += new System.EventHandler(this.btn_Procesa_Click);
            // 
            // conversorTexto
            // 
            this.conversorTexto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackGroundWorker1_ComenzarTarea);
            this.conversorTexto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackGroundWorker1_finalizado);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 421);
            this.Controls.Add(this.btn_Procesa);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Abrir);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.txt_box);
            this.Controls.Add(this.btn_generar);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejemplo Async";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.TextBox txt_box;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Button btn_Abrir;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Procesa;
        private System.ComponentModel.BackgroundWorker conversorTexto;
    }
}

