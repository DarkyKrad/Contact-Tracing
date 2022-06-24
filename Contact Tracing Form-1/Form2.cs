using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Tracing_Form_1
{
    public partial class Form2 : Form
    {
        public Form1 originalform;
        List<string> records = new List<string>();
        List<ListViewItem> items = new List<ListViewItem>();
        List<DateOnly> recorddates = new List<DateOnly>();
        public Form2()
        {
            InitializeComponent();
        }


        private void form2_closing(object sender, FormClosingEventArgs e)
        {
            originalform.Show();

        }

        private void listview_indexchange(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
             ListViewItem item = listView1.SelectedItems[0];
                int index = (int)item.Tag;
                lblDetail.Text = records[index];
            }
        }
        private void btnDF_Click(object sender, EventArgs e)
        {
            DateOnly duringDate = DateOnly.FromDateTime(dtpDOV2.Value);
            listView1.Items.Clear();
            for (int i = 0; i < recorddates.Count; i++)
            {
                if(duringDate.CompareTo(recorddates[i]) == 0)
                {
                    listView1.Items.Add(items[i]);
                }
            }

        }

        private void btnRF_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Items.AddRange(items.ToArray());
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            records.Clear();
            items.Clear();
            recorddates.Clear();
            StreamReader file = new StreamReader(@"C:\Users\Public\Desktop\test.txt");
            while (file.EndOfStream == false)
            {
                string details = "";
                string fullname = file.ReadLine();
                DateTime DOV;
                if (!DateTime.TryParse(file.ReadLine(), out DOV))
                {
                    return;
                }
                string line = file.ReadLine();
                while (line != "")
                {
                    details += line + "\n";
                    line = file.ReadLine();
                }


                records.Add(details);
                recorddates.Add(DateOnly.FromDateTime(DOV));
                ListViewItem item = new ListViewItem(new string[] { fullname, DOV.ToString() });
                item.Tag = items.Count;
                items.Add(item);
            }
            listView1.Items.Clear();
            listView1.Items.AddRange(items.ToArray());

        }


    }
    }

