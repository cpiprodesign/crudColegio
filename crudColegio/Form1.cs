using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crudColegio
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=CPIPRODESIGN\SQLEXPRESS;Initial Catalog=colegios;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getAlumnos();
        }
        //listar data
        private void getAlumnos()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select*from alumnos ", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.data.DataSource = dt;

            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        //insert alumnos

        private void inserAlumnos()
        {
            try
            {
                string a;
                a = "insert into alumnos values('" + textBox1.Text + "','" + Convert.ToInt32(textBox2.Text) + "','" + (maskedTextBox1.Text) + "')";
                SqlCommand cmd = new SqlCommand(a, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Registro guardado correctamente");
                getAlumnos();
            }
            catch (InvalidCastException ex)
            {
                throw ex;

            }
        }
        //update alumnos
        private void updateAlumnos()
        {
            try
            {
                string update;
                update = "update alumnos set nombres ='" + textBox1.Text + "',edad ='" + textBox2.Text + "', telefono ='" + maskedTextBox1.Text + "' where id ='" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(update, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Registro actualizado correctamente");
              getAlumnos();
            }
            catch (InvalidCastException ex)
            {
                throw ex;

            }
            
        }
        //delete alumnos
        private void deleteAlumnos()
        {
            try
            {
                string delete;
                delete = "delete from  alumnos where id ='" + textBox3.Text + "'";
               SqlCommand cmd = new SqlCommand(delete, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Registro Eleminado correctamente");
                getAlumnos();
            }
            catch (InvalidCastException ex)
            {
                throw ex;

            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            inserAlumnos();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            updateAlumnos();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            deleteAlumnos();
        }
    }
}
