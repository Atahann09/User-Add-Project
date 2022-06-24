using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MusteriEklemeFormu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string Ad = textBox1.Text;
            string Soyad = textBox2.Text;
            string adres = textBox3.Text;
            string CepNo = textBox5.Text;
            string mail = textBox6.Text;
            DateTime Tarih = dateTimePicker1.Value;

            

            Customer Customer1 = new Customer { CustomerId = Guid.NewGuid(),
                Name = Ad,
                SurName = Soyad,
                Adres = adres,
                CepTel = CepNo,
                Email = mail,
                Tarih = Tarih    
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389/api/");

            var jsonDat = JsonConvert.SerializeObject(Customer1);  // newtonsoft json ile customer class'ını json formatına çeviriyoruz ki HTTP Post olarak gönderebilelim.
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(jsonDat, Encoding.UTF8, "application/json");

            // List data response.
            var result = client.PostAsync("Proje/PersonKaydet", content).Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show(result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                MessageBox.Show("Bağlanamadı");
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("C:/Users/ataha/Desktop/CreatePdf.pdf", FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph("Ad : " + textBox1.Text);
            Paragraph p2 = new Paragraph("Soyad : " + textBox2.Text);
            Paragraph p3 = new Paragraph("Adres : " + textBox3.Text);
            Paragraph p4 = new Paragraph("CepNo : " + textBox5.Text);
            Paragraph p5 = new Paragraph("Mail : " + textBox6.Text);
            Paragraph p6 = new Paragraph("Tarih : " + dateTimePicker1.Value);
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(p5);
            doc.Add(p6);
            doc.Close();
            MessageBox.Show("Pdf olustu.");

        }
    }
}
