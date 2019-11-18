using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeluClienteWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConectorAPI.InicializarCliente();

        }

        private async Task CargarDatos(int Id = 0)
        {

            var cliente = await ProcesarClientes.TraerCliente(Id);

            textBox1.Text = cliente.nombre;
            

        }

        private async void btn_traer_Click(object sender, RoutedEventArgs e)
        {
            int numero = Convert.ToInt32(txt_Id.Text);
            if (numero < 0)
            {
                textBox1.Text = "Mal";
            }else
            {
                await CargarDatos(numero);
            }

        }
    }

   
}
