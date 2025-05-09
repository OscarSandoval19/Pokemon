using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace Pokedex
{
    public partial class Pokedex : Form
    {
        private HttpClient client = new HttpClient();
        public Pokedex()
        {
            InitializeComponent();
        }

        private void llbAltura_Click(object sender, EventArgs e)
        {

        }

        private void Pokedex_Load(object sender, EventArgs e)
        {

        }

        private async void btBuscar_Click(object sender, EventArgs e)
        {
            string pokemonName = txtNombre.Text.ToLower();
            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";

            try
            {
                string response = await client.GetStringAsync(url);
                JObject json = JObject.Parse(response);

                lblPeso.Text = $"Peso: {json["weight"]}";
                lblAltura.Text = $"Altura: {json["height"]}";
                lblTipo.Text = $"Tipo: {json["types"][0]["type"]["name"]}";
                string imagenUrl = json["sprites"]["front_default"]?.ToString();
                pictureBox1.Load(imagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro la informacion del pokemon: " + ex.Message);
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;

            lblPeso.Text = "Peso:";
            lblAltura.Text = "Altura:";
            lblTipo.Text = "Tipo:";

            pictureBox1.Image = null;
        }
    }
}
