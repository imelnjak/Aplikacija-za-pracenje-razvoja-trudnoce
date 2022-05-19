using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql;

namespace Aplikacija_za_pracenje_razvoja_trudnoce_Iva_Melnjak
{
    public partial class frmGlavna : Form
    {
        private int trenutniKorisnik;
        private int trajanjeTrudnoceUTjednimaTrenutnogKorisnika;
        private int tjedanTrudnoce = 0;

        private void azuriranjeTjednaTrudnoce()
        {
            var upit = $@"SELECT TRUNC(DATE_PART('day', NOW() - (t.datum_zaceca))/7) AS tjedan
                        FROM trudnoca t where t.korisnik_fk = '{trenutniKorisnik}'";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                trajanjeTrudnoceUTjednimaTrenutnogKorisnika = int.Parse(dr["tjedan"].ToString());

            }
            dr.Close();
            upit = $@"UPDATE trudnoca SET razvoj_fk='{trajanjeTrudnoceUTjednimaTrenutnogKorisnika}' WHERE korisnik_fk='{trenutniKorisnik}'";
            bpVeza.Instance.IzvrsiUpit(upit);
        }

        private void dohvatiPodatkeOTrudnoci()
        {
            azuriranjeTjednaTrudnoce();
            var upit = $@"SELECT t.id_trudnoce,t.datum_poroda,t.razvoj_fk FROM trudnoca t WHERE t.korisnik_fk='{trenutniKorisnik}'";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                lblDatumPoroda.Text = DateTime.Parse(dr["datum_poroda"].ToString()).ToString("dd/MM/yyyy");
                lblTrenutniTjedan.Text = dr["razvoj_fk"].ToString() + ". tjedan";
                tjedanTrudnoce = int.Parse(dr["razvoj_fk"].ToString());
                lblPreostaloDana.Text = (280 - (int.Parse(dr["razvoj_fk"].ToString()) * 7)).ToString() + " dana do poroda";
            }
            dr.Close();
            dohvatiPodatkeORazvoju();
        }

        private void dohvatiPodatkeORazvoju()
        {
            var upit = $@"SELECT * FROM razvoj_trudnoce WHERE id_razvoja='{tjedanTrudnoce}'";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                rtbVelicina.Text = dr["velicina_bebe"].ToString();
                rtbBeba.Text = dr["razvoj_bebe"].ToString();
                rtbMajka.Text = dr["majka"].ToString();
            }
            dr.Close();
        }
        private void unesiZapis()
        {
            var upit = $"INSERT INTO zapis(biljeska, korisnik_fk) VALUES('{rtbBiljeska.Text}','{trenutniKorisnik}')";
            try
            {
                bpVeza.Instance.IzvrsiUpit(upit);
            }
            catch (Exception ex) { }
        }
        private void prikaziZapis()
        {
            List<UnosBiljeske> lista = new List<UnosBiljeske>();
            var upit = $"SELECT * FROM zapis WHERE korisnik_fk='{trenutniKorisnik}' AND biljeska IS NOT NULL";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            try
            {
                int i = 1;
                while (dr.Read())
                {
                    lista.Add(new UnosBiljeske { 
                        id = int.Parse(dr["id_zapisa"].ToString()),
                        redniBroj= i,
                        biljeska = dr["biljeska"].ToString()
                    });
                    i++;
                }
            }
            catch (Exception ex)
            {
                dr.Close();
            }
            dr.Close();
            if (lista.Count > 0)
            {
                dgvBiljeske.DataSource = lista;
                dgvBiljeske.Columns[0].Visible = false;
                dgvBiljeske.Columns[1].HeaderText = "Redni broj";
                dgvBiljeske.Columns[2].HeaderText = "Bilješke";
                dgvBiljeske.Refresh();
            }
        }

        public frmGlavna(int id)
        {
            InitializeComponent();
            trenutniKorisnik = id;
            dohvatiPodatkeOTrudnoci();
            prikaziZapis();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            frmPrijava odjava = new frmPrijava();
            this.Hide();
            odjava.ShowDialog();
            this.Close();
        }

        private void btnOstaliTjedni_Click(object sender, EventArgs e)
        {
            frmOstaliTjedni ostalo = new frmOstaliTjedni(tjedanTrudnoce,trenutniKorisnik);
            this.Hide();
            ostalo.ShowDialog();
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbBiljeska.Text))
            {
                unesiZapis();
                prikaziZapis();
                rtbBiljeska.Text = "";
            }
            else
            {
                MessageBox.Show("Niste ništa unijeli!");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
