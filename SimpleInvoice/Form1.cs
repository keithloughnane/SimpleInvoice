using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;


namespace SimpleInvoice
{
    
    public partial class Form1 : Form
    {

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.DataGrid dataGrid3;

        stockItem[] stock;
        Form2 addFrom;
       public invoiceEntery[] iEnteries;
       public OleDbDataAdapter dAdapter;
        public int noEnteries = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            //dAdapter = new OleDbDataAdapter
           


            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();

            this.dataGrid1.CaptionText = "Customers";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(tabPage2.Width, tabPage2.Height/2);
            this.dataGrid1.TabIndex = 6;
            this.Controls.Add(this.dataGrid1);
            this.tabPage4.Controls.Add(this.dataGrid1);

            this.dataGrid2.CaptionText = "Stock";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(0, 0);
            this.dataGrid2.Name = "dataGrid1";
            this.dataGrid2.Size = new System.Drawing.Size(tabPage1.Width, tabPage1.Height/2);
            this.dataGrid2.TabIndex = 6;
            this.Controls.Add(this.dataGrid2);
            this.tabPage1.Controls.Add(this.dataGrid2);

            this.dataGrid3.CaptionText = "Sales";
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(0, 0);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(tabPage1.Width, tabPage1.Height / 2);
            this.dataGrid3.TabIndex = 6;
            this.Controls.Add(this.dataGrid3);
            this.tabPage5.Controls.Add(this.dataGrid3);
            

 	string conString=
  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\table.mdb";
//Initializes a new instance of the OleDbConnection

OleDbConnection con = new OleDbConnection(conString);
// open the database connection with the property settings

// specified by the ConnectionString "conString"
dAdapter = new OleDbDataAdapter("select * from customers", con);


con.Open();

           


    //con.Open();

dAdapter.Fill(dataSet1, "customers");
this.dataGrid1.DataSource = dataSet1.Tables["customers"];

dAdapter.Fill(dataSet2, "stock");
this.dataGrid2.DataSource = dataSet1.Tables["stock"];

dAdapter.Fill(dataSet3, "sales");
this.dataGrid3.DataSource = dataSet1.Tables["sales"];




    con.Close();


/* How to make this into usefull variables
 * 
 * 		this.textboxFirstname.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"FirstName");
		this.textboxLastname.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"LastName");
		this.textboxTitle.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"Title");
		this.textboxCity.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"City");
		this.textboxCountry.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"Country");
 * 
 */





            iEnteries = new invoiceEntery[255] ;
           LoadFromFile();
            pictureBox1.Image = stock[0].itemImage;

            int postion = 0;
            int padding = 20;
            int subtotal = 0;
            noEnteries = 0;
            int total = 0;
            Image bmp = new Bitmap("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\blank.bmp");
            Graphics mapg = Graphics.FromImage(bmp);


            Image header = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\header.bmp");
            mapg.DrawImage(header,0,0);
            Image footer = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\footer.bmp");
            mapg.DrawImage(footer, 0, bmp.Height - footer.Height);
            picMain.Image = bmp;
            picMain.Invalidate();

            //pictureBox1 = stock[0]


            this.textBox1.DataBindings.Add("Text", dataSet1.Tables["customers"], "CompanyName");
            this.textBox3.DataBindings.Add("Text", dataSet1.Tables["customers"], "ContactName");
            this.textBox4.DataBindings.Add("Text", dataSet1.Tables["customers"], "Description");
            this.textBox5.DataBindings.Add("Text", dataSet1.Tables["customers"], "Phone");
            this.textBox6.DataBindings.Add("Text", dataSet1.Tables["customers"], "Phone2");
            this.textBox7.DataBindings.Add("Text", dataSet1.Tables["customers"], "Email");
            this.textBox8.DataBindings.Add("Text", dataSet1.Tables["customers"], "Website");
            this.richTextBox1.DataBindings.Add("Text", dataSet1.Tables["customers"], "Notes"); 
            this.textBox9.DataBindings.Add("Text", dataSet1.Tables["customers"], "PersonID");

            richTextBox2.Text += "Test";
        }
        public void drawInvoice()
        {
            int position = 0;
            int padding = 20;
            int subtotal = 0;
            int total = 0;
            Image bmp = new Bitmap("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\blank.bmp");
            Graphics mapg = Graphics.FromImage(bmp);


            Image header = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\header.bmp");
            mapg.DrawImage(header, 0, 0);
            position = header.Height + padding;
            for (int i = 0; i < noEnteries; i++)
            {
                mapg.DrawImage(iEnteries[i].invoiceImage, 0, position);
                position += iEnteries[i].invoiceImage.Height;
            }
            Image footer = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\footer.bmp");
            mapg.DrawImage(footer, 0, bmp.Height - footer.Height);
            picMain.Image = bmp;
            picMain.Invalidate();
        }
        private void LoadFromFile()
        {
            stock = new stockItem[1];
            stockItem temp;
            temp = new stockItem();
            temp.ID = 1;
            temp.name = "Test Item";
            temp.description = "This item is only a test";
            temp.costPriceExVAT = 80;
            temp.salePriceExVAT = 100;
            temp.VATrate = 21.5;
            temp.itemImage = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\Item1.bmp");
           
            stock[0] = (temp);            
        }

        public class stockItem
        {
            public

            int ID;
            public Image itemImage;
            public string name;
            public string description;
            public double salePriceExVAT;
            public double costPriceExVAT;
            public double VATrate;
            public int[] contains;
            public bool[] addToPrice;
        }

            public void AddToInvoice(int itemID)
            {

            }
   
        public stockItem getItemByID(int getID)
        {
            for (int i = 0; i < stock.Length; i++)
            {
                if (stock[i].ID == getID)
                {
                    return stock[i];
                }
            }
            return null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addFrom = new Form2(this,stock[0]);
            addFrom.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
    public class invoiceEntery
    {

public int StockID;
        public Image itemImage;
        public string name;
        public string description;
        public double salePriceExVAT;
        public double costPriceExVAT;
        public double VATrate;
        public int[] contains;
        public bool[] addToPrice;
        public int quantity;
        public int discount_extracharge;
        public Image invoiceImage;
        public void makeImage()
        {
            invoiceImage = Image.FromFile("D:\\work\\SimpleInvoice\\SimpleInvoice\\bin\\Debug\\pics\\enteryBlank.bmp");

            Graphics g = Graphics.FromImage(invoiceImage);
            Font nameFont = new Font(FontFamily.GenericSansSerif, 30);
            Brush blackBrush = Brushes.Black;
            g.DrawString(Convert.ToString(StockID) + Convert.ToString(name) + Convert.ToString(description) + " @ " + Convert.ToString(salePriceExVAT) + " X " + Convert.ToString(quantity) + " = Total: " + Convert.ToString(salePriceExVAT*quantity), nameFont, blackBrush, 10, 10);

        }
    }
}
