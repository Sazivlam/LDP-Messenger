using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\purple.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var stringChars = new char[24];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = st[random.Next(st.Length)];
            }

            var finalString = new String(stringChars);

            textBox2.Text = finalString.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("+"))
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("phone number and password are not correct or are empty !...", "Error!");
                }
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

            using (var writer = new StreamWriter(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofphonenumbers.txt", true))
            {
                writer.WriteLine(textBox1.Text);
            }
            using (var writer2 = new StreamWriter(@"C:\Users\Ivan\Desktop\Lietišķo datorsistēmu programmatūra\baseofpasswords.txt", true))
            {
                writer2.WriteLine(MD5(textBox2.Text).ToLower());
            }

            if (textBox1.Text.Contains("+"))
            {
                MessageBox.Show("Registration has successfully completed", "Attention!");
            }
            Form1 f1 = new Form1();
            f1.Show();
            Hide();
        }
    }
}
