using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexC_sharp
{
    public partial class VentanaPrincipal : Form
    {

        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();
        int idActual = 1; //el pokemon que estamos viendo
        

        public VentanaPrincipal()
        {
            InitializeComponent();

            

        }

        private Image convierteBlobImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }

        private void izq_Click(object sender, EventArgs e)
        {
            idActual--;
            if (idActual <= 0) { idActual = 1; }

            //Para conocer los datos del pokemon que seleccione

            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            IDPokemon.Text = misPokemons.Rows[0]["id"].ToString();
            alturapokemon.Text = misPokemons.Rows[0]["altura"].ToString();
            pesopokemon.Text = misPokemons.Rows[0]["peso"].ToString();
            especiepokemon.Text = misPokemons.Rows[0]["especie"].ToString();
            habilidadpokemon.Text = misPokemons.Rows[0]["habilidad"].ToString();
            descripcionpokemon.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobImagen((byte[])misPokemons.Rows[0]["imagen"]);
            
        }

        private void der_Click(object sender, EventArgs e)
        {
            idActual++;
            if (idActual >= 151) { idActual = 151; }

            //para conocer los datos del pokemon que selecione

            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            IDPokemon.Text = misPokemons.Rows[0]["id"].ToString();
            alturapokemon.Text = misPokemons.Rows[0]["altura"].ToString();
            pesopokemon.Text = misPokemons.Rows[0]["peso"].ToString();
            especiepokemon.Text = misPokemons.Rows[0]["especie"].ToString();
            habilidadpokemon.Text = misPokemons.Rows[0]["habilidad"].ToString();
            descripcionpokemon.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobImagen((byte[])misPokemons.Rows[0]["imagen"]);

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            //Este metodo nos permite abrir la base de datos clicando en el boton
            //"BucarPokemon" esto hace que se abra otro form para seleccionar aquel 
            //pokemon del cual queremos saber información.

            VentanaBuscarPokemon eligePokemon = new VentanaBuscarPokemon();
            eligePokemon.ShowDialog();
            idActual = eligePokemon.idSeleccionado;
            //MessageBox.Show(eligePokemon.idSeleccionado.ToString());
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            IDPokemon.Text = misPokemons.Rows[0]["id"].ToString();
            alturapokemon.Text = misPokemons.Rows[0]["altura"].ToString();
            pesopokemon.Text = misPokemons.Rows[0]["peso"].ToString();
            especiepokemon.Text = misPokemons.Rows[0]["especie"].ToString();
            habilidadpokemon.Text = misPokemons.Rows[0]["habilidad"].ToString();
            descripcionpokemon.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobImagen((byte[])misPokemons.Rows[0]["imagen"]);



        }

        
    }
}
