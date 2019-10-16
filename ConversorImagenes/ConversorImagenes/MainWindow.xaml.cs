using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConversorImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] archivos;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn_examinarClick(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //desactivar la lista para poder borrar su contenido
                    lst_archivos.IsEnabled = false;
                    lst_archivos.Items.Clear();
                    archivos = Directory.GetFiles(fbd.SelectedPath);
                    txt_path.Text = fbd.SelectedPath.ToString();
                    lst_archivos.IsEnabled = true;
                    foreach (var archivo in archivos)
                    {
                        lst_archivos.Items.Add(System.IO.Path.GetFileName(archivo));
                    }
                    System.Windows.Forms.MessageBox.Show("Imágenes encontradas: " + archivos.Length.ToString(), "Mensaje");

                }
            }
        }
        
        private void lst_archivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //existen tantos errores que pueden saltar aqui que no me molesto en diferenciarlos..simplemente ignoro
            try
            {
                string seleccion = lst_archivos.SelectedItem.ToString();

                foreach (string cadena in archivos)
                {
                    if (cadena.Contains(seleccion))
                    {
                        var ruta = new Uri(cadena);
                        img_muestra.Stretch = Stretch.Fill;
                        img_muestra.Source = new BitmapImage(ruta);

                        break;
                    }
                }
            }
            catch (Exception)
            {

                
            }
 
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
