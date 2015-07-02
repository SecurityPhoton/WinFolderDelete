using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFolderDelete
{
    public partial class Form1 : Form
    {
        public string[] text1;

        public void GetData()
        {
            text1 = new string[textBox2.Lines.Length];
            textBox2.ReadOnly = true;
            string sum = "";


            //System.Windows.Forms.MessageBox.Show(Convert.ToString(textBox2.Lines.Length), "Info",
            //      System.Windows.Forms.MessageBoxButtons.OK,
            //      System.Windows.Forms.MessageBoxIcon.Information);
            if (textBox2.Lines.Length < 1000)
            {
                for (int i = 0; i < textBox2.Lines.Length; i++)
                {
                    text1[i] = textBox2.Lines[i];
                    sum += " " + text1[i];
                }

                string textres = Convert.ToString(textBox2.Lines.Length);
                //System.Windows.Forms.MessageBox.Show("Added " + sum + " strings!", "Info",
                //System.Windows.Forms.MessageBoxButtons.OK,
                //System.Windows.Forms.MessageBoxIcon.Information);

            }
            else System.Windows.Forms.MessageBox.Show("More than we can handle", "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Information);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DelText = "";
            int count = 0;
            GetData();
            try
            {
                progressBar1.Maximum = textBox2.Lines.Length;

                for (int i = 0; i < textBox2.Lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(text1[i]))
                    {
                        DelText = textBox1.Text + "\\" + text1[i];

                        //System.Windows.Forms.MessageBox.Show(DelText, "Error",
                        //System.Windows.Forms.MessageBoxButtons.OK,
                        //System.Windows.Forms.MessageBoxIcon.Information);
                    }

                    if (System.IO.Directory.Exists(DelText) && (textBox1.Text + "\\" != DelText))
                    {
                        try
                        {
                            System.IO.Directory.Delete(DelText, true);
                            count++;
                            progressBar1.Value = i;
                            label1.Text = "Deleting " + DelText + " now!";
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message + " Path:" + DelText, "Error",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Warning);
                            textBox3.AppendText(DelText + "\n");
                        }
                        finally
                        {

                        }

                    }

                }

                label1.Text = "Deleted " + Convert.ToString(count) + " folders of " + Convert.ToString(textBox2.Lines.Length) + "!";
                count = 0;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Path:" + DelText, "Error",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
            }
            progressBar1.Value = 0;
            textBox2.ReadOnly = false;


        }

        private void textBox1_Click(object sender, EventArgs e)
        {


        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == false)
            {
                textBox2.Clear();
            }

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
