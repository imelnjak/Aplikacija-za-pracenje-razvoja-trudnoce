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
using Npgsql;

namespace Aplikacija_za_pracenje_razvoja_trudnoce_Iva_Melnjak
{
    public partial class frmPrijava : Form
    {
        private int provjeriPostojiLiKorisnik()
        {
            var upit = $"SELECT id_korisnika FROM korisnik WHERE email='{txtEmail.Text}' AND lozinka='{txtLozinka.Text}'";
            int id_korisnika = Convert.ToInt32(bpVeza.Instance.DohvatiVrijednost(upit));
            return id_korisnika;
        }
        public frmPrijava()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            frmRegistracija registracija = new frmRegistracija();
            this.Hide();
            registracija.ShowDialog();
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if(!(String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtLozinka.Text)))
            {
                int korisnik = provjeriPostojiLiKorisnik();
                if(korisnik != 0)
                {
                    frmGlavna glavnaForma = new frmGlavna(korisnik);
                    this.Hide();
                    glavnaForma.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji!");
                }
            }
            else
            {
                MessageBox.Show("Niste ispunili sva polja!");
            }
        }
    }
}
