using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleInvoice
{
    public partial class Form2 : Form
    {
        SimpleInvoice.Form1.stockItem item;
        Form1 parent;
        SimpleInvoice.invoiceEntery tempEntery;
        public Form2(Form1 p,SimpleInvoice.Form1.stockItem s)
        {
            parent = p;
            item = s;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(item.ID);
            textBox2.Text = Convert.ToString(item.name);
            richTextBox1.Text = Convert.ToString(item.description);
            textBox4.Text = Convert.ToString(item.costPriceExVAT);
            textBox5.Text = Convert.ToString(item.salePriceExVAT);
            textBox6.Text = Convert.ToString(item.VATrate);
            pictureBox2.Image = item.itemImage;

            double totalEach = (item.salePriceExVAT / 100) * item.VATrate + 100;
            textBox7.Text = Convert.ToString(totalEach);
            textBox8.Text = Convert.ToString((totalEach * Convert.ToDouble(numericUpDown1.Value)) - Convert.ToDouble( textBox3.Text));

            tempEntery = new invoiceEntery();
            tempEntery.StockID = item.ID;
tempEntery.quantity = Convert.ToInt32( numericUpDown1.Value);

       tempEntery.discount_extracharge = Convert.ToInt32(textBox3.Text);






       drawAgain();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            drawAgain();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void Form2_Validated(object sender, EventArgs e)
        {

        }
        private void drawAgain()
        {
            
            
            
            
            
      
            
            
            textBox1.Text = Convert.ToString(item.ID);
            //textBox2.Text = Convert.ToString(item.name);
            //richTextBox1.Text = Convert.ToString(item.description);
            //textBox4.Text = Convert.ToString(item.costPriceExVAT);
           tempEntery.salePriceExVAT = item.salePriceExVAT;
           tempEntery.name = item.name;
            //textBox6.Text = Convert.ToString(item.VATrate);
            pictureBox2.Image = item.itemImage;

            double totalEach = (item.salePriceExVAT / 100) * item.VATrate + 100;
            textBox7.Text = Convert.ToString(totalEach);
            textBox8.Text = Convert.ToString((totalEach * Convert.ToDouble(numericUpDown1.Value)) + Convert.ToDouble(textBox3.Text));
            //SetValues

            tempEntery.quantity = Convert.ToInt32(numericUpDown1.Value);

            tempEntery.discount_extracharge = Convert.ToInt32(textBox3.Text);

            tempEntery.makeImage();
            pictureBox1.Image = tempEntery.invoiceImage;      

            
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            drawAgain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.iEnteries[parent.noEnteries] = tempEntery;
            parent.noEnteries++;
            parent.drawInvoice();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawAgain();
        }

    }
}
