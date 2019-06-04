using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               // pictureBox1.Visible = true;
                GetDataAsync();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private async void GetDataAsync()
        {
            try
            {
                pictureBox1.Visible = true;
                //two way of calling methods
                // int i = await BindDataAsync();
                int i = await Task.Run(() => BindData());
                pictureBox1.Visible = false;
                lblCount.Text = "Count:" + i;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private async Task<int> BindDataAsync()
        {
            try
            {
                return await Task.Run<int>(() =>
                {
                    for (int i = 0; i < 50000; i++)
                    {
                        Invoke(new Action(() =>
                        {
                            dataGridView1.Rows.Add(i.ToString(), "Amit " + i.ToString());
                        }));
                    }
                    return dataGridView1.Rows.Count;
                });
            }
            catch (Exception ex) { throw ex; }
        }

        private int BindData()
        {
            try
            {
                for (int i = 0; i < 50000; i++)
                {
                    Invoke(new Action(() =>
                    {
                        dataGridView1.Rows.Add(i.ToString(), "Amit " + i.ToString());
                    }));
                }
                return dataGridView1.Rows.Count;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
