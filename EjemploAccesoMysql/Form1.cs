using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace EjemploAccesoMysql
{
    public partial class Form1 : Form
    {
        private MySqlConnection conexion;
        private static MySqlCommand comando;
        private String consulta;
        private MySqlDataReader resultado;
        private DataTable datos = new DataTable();

        public Form1()
        {
            InitializeComponent();
            //nota: si tu servidor MySQL es externo (no localhost), tienes que  habilitar el acceso desde fuera
            
            //en la consola de mysql o en phpmyadmin o en mysql workbench pones:
            //grant all privileges on *.* to 'root'@'%' 
            //si tiene contraseña pones además  identified by password''
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = almacen; Uid = root; Pwd = root; Port = 3306");
            conexion.Open();

            comando = new MySqlCommand("Select * from articulos", conexion);
            resultado = comando.ExecuteReader();

            datos.Load(resultado);
            dataGridView1.DataSource = datos;
        }
    }
}
