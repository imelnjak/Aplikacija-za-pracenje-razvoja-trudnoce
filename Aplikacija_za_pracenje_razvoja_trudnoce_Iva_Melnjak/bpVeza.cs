using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql;
using System.Windows.Forms;

namespace Aplikacija_za_pracenje_razvoja_trudnoce_Iva_Melnjak
{
    class bpVeza
    {
        private static bpVeza instance;

        public static bpVeza Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new bpVeza();
                }
                return instance;
            }
        }
        public string ConnectionString { get; private set; }

        public NpgsqlConnection Connection { get; private set; }

        private bpVeza()
        {
            ConnectionString = "Host=localhost;Username=postgres;Password=tbp;Database=pracenjerazvojatrudnoce";
            Connection = new NpgsqlConnection(ConnectionString);
            Connection.Open();
        }

        public void CloseConnection()
        {
            if(Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
        
        public NpgsqlDataReader DohvatiDataReader(string sqlUpit)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(sqlUpit, Connection);
                return command.ExecuteReader();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public object DohvatiVrijednost(string sqlUpit)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(sqlUpit, Connection);
                return command.ExecuteScalar();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }

        public int IzvrsiUpit(string sqlUpit)
        {
            NpgsqlCommand command = new NpgsqlCommand(sqlUpit, Connection);
            return command.ExecuteNonQuery();
        }
    }
}
