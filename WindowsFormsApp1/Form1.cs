using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string MD5(string s)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            Byte[] bytes4MD5 = Encoding.UTF8.GetBytes(s);
            byte[] checkSum = md5.ComputeHash(bytes4MD5);
            return BitConverter.ToString(checkSum).Replace("-", String.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = new Bitmap(@"C:\Users\Ivan\Desktop\RTU\6.sem\Lietišķo datorsistēmu programmatūra\purple.jpg");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("+"))
            {
                MessageBox.Show("phone number is not corrected!...", "Error!");
            }
            if (textBox1.Text.Contains("+"))
            {
                if (textBox1.Text.Contains(""))
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Password did not entered!...", "Error!");
                    }
                }
            }
            if (label3.Text == "OK" || label5.Text == "OK")
            {
                //Form2 f2 = new Form2();
                //f2.Show();
                //Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string[] baseOfPasswords = File.ReadAllLines(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofpasswords.txt");
            foreach (var lines2 in baseOfPasswords)
            {
                if (lines2.Contains(MD5(textBox2.Text).ToLower()))
                {
                    label5.Text = "OK";
                }
                else
                {
                    label5.Text = "NO";
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string[] baseOfPasswords = File.ReadAllLines(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofpasswords.txt");
            foreach (var lines2 in baseOfPasswords)
            {
                if (lines2.Contains(textBox1.Text))
                {
                    label5.Text = "OK";
                }
                else
                {
                    label5.Text = "NO";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] baseOfPhoneNumbers = File.ReadAllLines(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofphonenumbers.txt");

            foreach (var lines2 in baseOfPhoneNumbers)
            {
                if (lines2.Contains(textBox1.Text))
                {
                    label3.Text = "OK";
                }
                else
                {
                    label3.Text = "NO";
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string[] baseOfPhonePasswords = File.ReadAllLines(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofpasswords.txt");
            foreach (var lines2 in baseOfPhonePasswords)
            {
                if (lines2.Contains(MD5(textBox2.Text).ToLower()))
                {
                    label5.Text = "OK";
                }
                else if (!lines2.Contains(MD5(textBox2.Text).ToLower()))
                {
                    label5.Text = "NO";
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}