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
    public partial class frmRegistracija : Form
    {
        int korisnik;
        private int provjeriEmail()
        {
            int id_korisnika = 0;
            var upit = $"SELECT * FROM korisnik WHERE email='{txtREmail.Text}'";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                id_korisnika = int.Parse(dr["id_korisnika"].ToString());
            }
            dr.Close();
            return id_korisnika;
        }

        private int registracijaKorisnika()
        {
            if (String.IsNullOrEmpty(txtIme.Text) || String.IsNullOrEmpty(txtRLozinka.Text) || String.IsNullOrEmpty(txtPonovite.Text) || String.IsNullOrEmpty(txtREmail.Text))
            {
                MessageBox.Show("Upišite sve podatke!");
                return 0;
            }
            else if(txtPonovite.Text != txtRLozinka.Text)
            {
                MessageBox.Show("Unešene lozinke nisu jednake!");
                return 0;
            }
            else if (provjeriEmail() != 0)
            {
                MessageBox.Show("Email već postoji u bazi!");
                return 0;
            }
            else
            {
                try
                {
                    int IDkorisnika = dohvatiIDKorisnika();
                    korisnik = IDkorisnika;
                    var upit = $"INSERT INTO korisnik(id_korisnika, ime, email, lozinka) VALUES ('{IDkorisnika}','{txtIme.Text}','{txtREmail.Text}','{txtRLozinka.Text}')";
                    bpVeza.Instance.IzvrsiUpit(upit);
                    if(dtpDatumZaceca.Enabled == false)
                    {
                        upit = $"INSERT INTO trudnoca(datum_poroda, korisnik_fk) VALUES('{dtpDatumPoroda.Value}',{IDkorisnika})";
                    }
                    else
                    {
                        upit = $"INSERT INTO trudnoca(datum_zaceca, korisnik_fk) VALUES('{dtpDatumZaceca.Value}',{IDkorisnika})";
                    }
                    return bpVeza.Instance.IzvrsiUpit(upit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public frmRegistracija()
        {
            InitializeComponent();
            postaviOgranicenjeDatuma();
        }

        private void postaviOgranicenjeDatuma()
        {
            var currentDate = DateTime.Today;
            dtpDatumPoroda.MaxDate = currentDate.AddMonths(10);
            dtpDatumZaceca.MinDate = currentDate.AddMonths(-10);
        }

        private int dohvatiIDKorisnika()
        {
            var vrijednost = 0;
            var upit = "SELECT nextval(pg_get_serial_sequence('korisnik', 'id_korisnika')) AS novi_id";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                vrijednost = int.Parse(dr["novi_id"].ToString());
            }
            dr.Close();
            return vrijednost;
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            frmPrijava odustani = new frmPrijava();
            this.Hide();
            odustani.ShowDialog();
            this.Close();
        }

        private void btnRRegistracija_Click(object sender, EventArgs e)
        {
            if(registracijaKorisnika() == 1)
            {
                frmGlavna glavnaForma = new frmGlavna(korisnik);
                this.Hide();
                glavnaForma.ShowDialog();
                this.Close();
            }
            
        }

        private void dtpDatumPoroda_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumZaceca.Enabled = false;
        }

        private void dtpDatumZaceca_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumPoroda.Enabled = false;
        }
    }
}
