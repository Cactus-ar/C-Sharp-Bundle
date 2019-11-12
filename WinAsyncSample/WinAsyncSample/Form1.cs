using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ejemplo del uso de faker para generar texto, el paquete nuguet se llama Bogus.
// Tambien como implementar los cuadros de dialogo de abrir y guardar archivo
//por ultimo un pequeño ejemplo de como usar subprocesos al
//invocar un worker que trunca el contenido del control de texto..


namespace WinAsyncSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarBackGroundWorker();
        }

        private void InicializarBackGroundWorker()
        {
            conversorTexto.DoWork += new DoWorkEventHandler(BackGroundWorker1_ComenzarTarea);
            conversorTexto.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackGroundWorker1_finalizado);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Seleccione un Archivo de Texto",
                Filter = "Archivo Texto (*.txt)|*.txt",
                Title = "Abrir un Archivo de Texto"
            };

        }

        private void BackGroundWorker1_finalizado(object sender, RunWorkerCompletedEventArgs e)
        {
            txt_box.Text = e.Result.ToString();
            lbl_count.Text = $"Cantidad de Caracteres: {txt_box.TextLength.ToString()}";
            txt_box.Refresh();
            btn_Abrir.Enabled = true;
            btn_generar.Enabled = true;
            btn_Guardar.Enabled = true;
            btn_Procesa.Enabled = true;
        }

        private void BackGroundWorker1_ComenzarTarea(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            btn_Abrir.Enabled = false;
            btn_generar.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Procesa.Enabled = false;

            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = TransformarTexto((TextBox) e.Argument, worker, e);
        }

        private string GenerarParrafo()
        {
            var faker = new Faker("es_MX");
            string texto = faker.Lorem.Paragraph(15);
            return texto;

        }

        private string TransformarTexto(TextBox box, BackgroundWorker worker, DoWorkEventArgs e)
        {
            lbl_count.Text = "Procesando...";
            char[] contenedor = box.Text.ToCharArray();
            string reverso = string.Empty;

            for (int i = contenedor.Length -1 ; i > -1; i--)
            {
                reverso += contenedor[i];
            }
           
            Thread.Sleep(5000); //Para probar los workers
            return reverso;

        }


        private void btn_generar_Click(object sender, EventArgs e)
        {

            btn_generar.Text = "Agregar Más";
            txt_box.Text += GenerarParrafo();
            lbl_count.Text = $"Cantidad de Caracteres: {txt_box.TextLength.ToString()}";
            txt_box.Refresh();

        }


        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    txt_box.Text = sr.ReadToEnd();
                    lbl_count.Text = $"Cantidad de Caracteres: {txt_box.TextLength.ToString()}";
                    sr.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Error de Seguridad.\n\n Mensaje: {ex.Message}\n\n" +
                    $"Detalles:\n\n{ex.StackTrace}");
                }

                
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Filter = "Archivo Texto (*.txt)|*.txt";
            dialogoGuardar.Title = "Guardar Archivo Texto";
            dialogoGuardar.ShowDialog();

            if (dialogoGuardar.FileName != "")
            {

                if (!File.Exists(dialogoGuardar.FileName)) // Si el archivo No existe
                {
                    File.Create(dialogoGuardar.FileName).Close(); // Crear Archivo
                    using (StreamWriter sw = File.AppendText(dialogoGuardar.FileName))
                    {
                        if(txt_box.TextLength > 0)
                            sw.WriteLine(txt_box.Text); // Escribir el contenido del textbox si no  esta vacio
                        else
                            sw.WriteLine(""); // generar un archivo vacio
                    }
                }
                else // si Ya existe el archivo
                {
                    
                    using (StreamWriter sw = File.AppendText(dialogoGuardar.FileName))
                    {
                        if (txt_box.TextLength > 0)
                            sw.WriteLine(txt_box.Text); // escribir el contenido del box
                        else
                            sw.WriteLine(""); // generar un archivo vacio
                    }

                }
            }

            dialogoGuardar.Dispose();

        }

        private void btn_Procesa_Click(object sender, EventArgs e)
        {
            conversorTexto.RunWorkerAsync(txt_box);
        }
    }
}
