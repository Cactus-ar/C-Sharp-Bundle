using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityTestTwo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLista();
            

        }

        public void CargarLista()
        {
            listView1.Items.Clear(); //borrar la data actual

            //cargar Lista
            using (var db = new ContextoDeDatos())
            {
                var query = from t in db.Tareas orderby t.Titulo select t;

                foreach (Tarea item in query)
                {
                    listView1.Items.Add(item.Titulo);
                }

            }
        }

        public void AgregarDato()
        {
            using (var db = new ContextoDeDatos())
            {
                var nuevaTarea = new Tarea
                {
                    Titulo = textBox1.Text,
                    Fecha = dateTimePicker1.Value,
                    Descripcion = textBox2.Text,
                };

                db.Tareas.Add(nuevaTarea);
                db.SaveChanges();

            }
        }

        public class ContextoDeDatos: DbContext
        {
            public DbSet<Tarea> Tareas { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarDato();
            CargarLista();
        }


    }
}
