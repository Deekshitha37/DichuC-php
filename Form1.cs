using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SqlStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string id= textBox1.Text;
            string name = textBox2.Text;
            string email = textBox3.Text;
            string phone = textBox4.Text;
            
            string URL = "http://localhost/cweb/somescript.php";
            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();
            formData["id"] = id;
            formData["name"] = name;
            formData["email"] = email;
            formData["phone"] = phone;

            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            string responsefromserver = Encoding.UTF8.GetString(responseBytes);

            JObject responseJObject =  JObject.Parse(responsefromserver);

           

            try
            {
                //MessageBox.Show(responsefromserver);
                 MessageBox.Show(responseJObject["status"].ToString());
              //  MessageBox.Show(responseJObject["message"].ToString());

                List<Jsonclass> resultList = JsonConvert.DeserializeObject<List<Jsonclass>>(responseJObject["message"].ToString());

                //for(int i=0;i<resultList.Count;i++)
                //{
                //    MessageBox.Show(resultList[i].id+":\n"
                //        + resultList[i].name + ":\n"
                //        +resultList[i].email + ":\n"
                //        +resultList[i].phone + ":\n");
                //}
                dataGridView1.DataSource = resultList;


            }
            catch (Exception ex)
            {
               MessageBox.Show("i have a problem" + ex.Message.ToString());

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {



           // SQLiteConnection connection = new SQLiteConnection(@"Data Source=F:\c#\SqlStore\customer.db;");
           // connection.Open();
            
           //SQLiteCommand command = new SQLiteCommand();
           // string sql = @"select max(id) as id from record";
           // using (var cmd = connection.CreateCommand())
           // {
           //     cmd.CommandText = sql;
           //     int lastId = Convert.ToInt32(cmd.ExecuteScalar());
           //     int result = lastId + 1;
           //    // MessageBox.Show(result.ToString());
           //     textBox1.Text = result.ToString();
           // }
                
           

            }

        private void button3_Click(object sender, EventArgs e)
        {
            //SQLiteConnection connection = new SQLiteConnection(@"Data Source=F:\c#\SqlStore\customer.db;");
            //connection.Open();

            //SQLiteCommand command = new SQLiteCommand();
            //string sql = @"select max(id) as id from record";
            //using (var cmd = connection.CreateCommand())
            //{
            //    cmd.CommandText = sql;
            //    int lastId = Convert.ToInt32(cmd.ExecuteScalar());
            //    int result = lastId + 1;
            //    // MessageBox.Show(result.ToString());
            //    textBox1.Text = result.ToString();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //    string connectionPath = @"Data Source=F:\c#\SqlStore\customer.db;";

            //    using (SQLiteConnection connection = new SQLiteConnection(connectionPath))
            //    {
            //        SQLiteCommand command = connection.CreateCommand();
            //        connection.Open();
            //        string query = "SELECT  * FROM record";
            //        command.CommandText = query;
            //        command.ExecuteNonQuery();

            //        SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            //        DataSet ds = new DataSet();
            //        da.Fill(ds, "record");
            //        int c = ds.Tables["record"].Rows.Count;
            //        dataGridView1.DataSource = ds.Tables["record"];
            //    }

          
           
        }

      


        





        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
