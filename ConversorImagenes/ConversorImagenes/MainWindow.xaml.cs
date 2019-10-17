using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConversorImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] archivos;
        DialogResult seleccionCarpeta;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        private void Btn_examinarClick(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                seleccionCarpeta = fbd.ShowDialog();

                if (seleccionCarpeta == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
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
        
        private void Lst_archivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Btn_salir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

       
        private void Btn_Procesar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string seleccion = lst_archivos.SelectedItem.ToString();

                foreach (string cadena in archivos)
                {
                    if (cadena.Contains(seleccion))
                    {
                        var formato = new ImageFormat(Guid.Empty);
                        var ruta = new Uri(cadena);
                        System.Drawing.Image imagen = System.Drawing.Image.FromFile(ruta.AbsolutePath, true);

                        ComboBoxItem Seleccionformato = (ComboBoxItem)cmb_formatos.SelectedItem;

                        switch (Seleccionformato.Content)
                        {
                            case "PNG":
                                formato = ImageFormat.Png;
                                break;
                            case "JPG":
                                formato = ImageFormat.Jpeg;
                                break;
                            case "BMP":
                                formato = ImageFormat.Bmp;
                                break;
                            case "GIF":
                                formato = ImageFormat.Gif;
                                break;
                            case "TIFF":
                                formato = ImageFormat.Tiff;
                                break;
                            default:
                                formato = ImageFormat.Png;
                                break;
                        }

                        string prefijo = txt_prefijo.Text;
                        string cadenaYpunto = seleccion.Substring(0, seleccion.IndexOf(".") +1);
                        string extension = formato.ToString();
                        string nombre = prefijo + cadenaYpunto + extension;

                        string nuevaRuta = ruta.LocalPath.Substring(0, ruta.LocalPath.Length - seleccion.Length);
                        string nuevoArchivo = nuevaRuta + nombre;

                        imagen.Save(nuevoArchivo, formato);
                        imagen.Dispose();
                        break;
                    }
                }
            }
            catch (Exception)
            {


            }

            
            
        }
    }
}
