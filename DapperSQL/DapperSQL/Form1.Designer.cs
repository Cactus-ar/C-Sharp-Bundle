namespace DapperSQL
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
            this.lst_personas = new System.Windows.Forms.ListBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Busca = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_personas
            // 
            this.lst_personas.FormattingEnabled = true;
            this.lst_personas.Location = new System.Drawing.Point(12, 90);
            this.lst_personas.Name = "lst_personas";
            this.lst_personas.Size = new System.Drawing.Size(494, 225);
            this.lst_personas.TabIndex = 0;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(71, 21);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(173, 20);
            this.txt_apellido.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apellido:";
            // 
            // btn_Busca
            // 
            this.btn_Busca.Location = new System.Drawing.Point(23, 57);
            this.btn_Busca.Name = "btn_Busca";
            this.btn_Busca.Size = new System.Drawing.Size(102, 22);
            this.btn_Busca.TabIndex = 3;
            this.btn_Busca.Text = "Buscar SQL String";
            this.btn_Busca.UseVisualStyleBackColor = true;
            this.btn_Busca.Click += new System.EventHandler(this.btn_Busca_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar SQL Stored Procedure";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 337);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Busca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.lst_personas);
            this.Name = "Form1";
            this.Text = "Dapper SQL Tests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_personas;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Busca;
        private System.Windows.Forms.Button button1;
    }
}

