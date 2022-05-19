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
    public partial class frmOstaliTjedni : Form
    {
        private int odabrani_id;
        private int prijavljeniKorisnik;
        private void popuniComboBox()
        {
            List<OdabirTjedna> naziv = new List<OdabirTjedna>();
            int i = 1;
            var tjedni = $@"SELECT * FROM razvoj_trudnoce";
            NpgsqlDataReader t = bpVeza.Instance.DohvatiDataReader(tjedni);
            while (t.Read())
            {
                string sTjedni = t["id_razvoja"].ToString() + ". tjedan";
                naziv.Add(new OdabirTjedna
                {
                    id = i,
                    tjedan = t["id_razvoja"].ToString() + ". tjedan"
                });
                i++;
            }
            t.Close();
            cmbTjedni.DataSource = naziv;
            cmbTjedni.DisplayMember = "tjedan";
            cmbTjedni.ValueMember = "id";
        }

        public frmOstaliTjedni(int id, int korisnik)
        {
            InitializeComponent();
            odabrani_id = id;
            prijavljeniKorisnik = korisnik;
            popuniComboBox();
            cmbTjedni.SelectedValue = id;
            prikazTjedna();

        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            frmGlavna zatvori = new frmGlavna(prijavljeniKorisnik);
            this.Hide();
            zatvori.ShowDialog();
            this.Close();
        }

        private void cmbTjedni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            odabrani_id = int.Parse(cmbTjedni.SelectedValue.ToString());
            prikazTjedna();

        }

        private void prikazTjedna()
        {
            var upit = $@"SELECT * FROM razvoj_trudnoce WHERE id_razvoja='{odabrani_id}'";
            NpgsqlDataReader dr = bpVeza.Instance.DohvatiDataReader(upit);
            while (dr.Read())
            {
                rtbVelicinaT.Text = dr["velicina_bebe"].ToString();
                rtbBebaT.Text = dr["razvoj_bebe"].ToString();
                rtbMajkaT.Text = dr["majka"].ToString();
            }
            dr.Close();
        }
    }
}
