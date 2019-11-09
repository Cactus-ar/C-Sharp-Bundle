using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperSQL
{
    public partial class Form1 : Form
    {
        List<Persona> Personas = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
            Update();    
        }

        private void Update() {
            lst_personas.DataSource = Personas;
            lst_personas.DisplayMember = "FullInfo";
        }

        private void btn_Busca_Click(object sender, EventArgs e)
        {
            AccesoDatos db = new AccesoDatos();
            Personas = db.GetPersonas(txt_apellido.Text);
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccesoDatos db = new AccesoDatos();
            Personas = db.GetPersonasStProcedure(txt_apellido.Text);
            Update();
        }
    }
}
