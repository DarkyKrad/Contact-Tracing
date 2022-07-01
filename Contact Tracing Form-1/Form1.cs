using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using System.Linq;
using System.Text.Json;

namespace Contact_Tracing_Form_1
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private Form3 form3;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void qrcodeauto_fill(object sender, QRCodeReadEventArgs e)
        {
            string json = e.Data;
            ContactTracingInfo? data = JsonSerializer.Deserialize<ContactTracingInfo>(json);
            if (data is not null)
            {
                txtFN.Text = data.FullName;
                txtCA.Text = data.CompleteAddress;
                txtPN.Text = data.PhoneNumber;
                txtROV.Text = data.RoV;
                txtTemp.Text = data.Temperature;
                cmbAge.Text = data.Age;
                cmbSex.Text = data.Sex;
                dtpDOV.Value = data.DToV.Date;
                dtpToV.Value = data.DToV;

                rbQ1Y.Checked = data.Question1;
                rbQ2Y.Checked = data.Question2;
                rbQ3Y.Checked = data.Question3;
                rbQ4Y.Checked = data.Question4;

                rbQ1N.Checked = !data.Question1;
                rbQ2N.Checked = !data.Question2;
                rbQ3N.Checked = !data.Question3;
                rbQ4N.Checked = !data.Question4;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            pnlHQ.Visible = true;
            pnlPI.Visible = false;
            btnSubmit.Visible = true;
            btnReturn.Visible = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            pnlHQ.Visible = false;
            pnlPI.Visible = true;
            btnSubmit.Visible = false;
            btnNext.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFN.Text == "" || txtCA.Text == "" || txtPN.Text == "" || txtROV.Text == "" || txtTemp.Text == "" || dtpToV.Text == "" || cmbAge.Text == "" || cmbSex.Text == "" || dtpDOV.Text == "")
            {
                MessageBox.Show("Please fill out the remaining forms");
                return;
            }

            if (!(rbQ1Y.Checked || rbQ1N.Checked) || !(rbQ2Y.Checked || rbQ2N.Checked) || !((rbQ3Y.Checked || rbQ3N.Checked) || !(rbQ4Y.Checked || rbQ4N.Checked)))
            {
                MessageBox.Show("Please fill out the remaining forms");
                return;
            }
            StreamWriter file = new StreamWriter(@"C:\Users\Public\Desktop\test.txt", true);
            file.WriteLine(txtFN.Text);
            file.WriteLine(dtpDOV.Value.ToString("o"));
            file.WriteLine("Fullname: " + txtFN.Text);
            file.WriteLine("Complete Address: " + txtCA.Text);
            file.WriteLine("Phone Number: " + txtPN.Text);
            file.WriteLine("Age: " + cmbAge.Text);
            file.WriteLine("Sex: " + cmbSex.Text);
            file.WriteLine("Temperature: " + txtTemp.Text);
            file.WriteLine("Reason of Visit: " + txtROV.Text);
            file.WriteLine("Time of Visit: " + dtpToV.Text);
            file.WriteLine("Date of Visit: " + dtpDOV.Text);

            string choice = rbQ1Y.Checked ? "Yes" : "No";
            file.WriteLine("Question 1: " + choice);
            choice = rbQ2Y.Checked ? "Yes" : "No";
            file.WriteLine("Question 2: " + choice);
            choice = rbQ3Y.Checked ? "Yes" : "No";
            file.WriteLine("Question 3: " + choice);
            choice = rbQ4Y.Checked ? "Yes" : "No";
            file.WriteLine("Question 4: " + choice);


            file.WriteLine();
            file.Close();

            pnlQRCode.Visible = true;
            pnlHQ.Visible = false;
            pnlPI.Visible = false;
            btnSubmit.Visible = false;
            btnNext.Visible = false;
            
        }
       
        private void pnlQRCODE_visiblechanged(object sender, EventArgs e)
        {
            var data = new ContactTracingInfo
            {
                FullName = txtFN.Text,
                DToV = dtpDOV.Value.Date + dtpToV.Value.TimeOfDay,
                CompleteAddress = txtCA.Text,
                PhoneNumber = txtPN.Text,
                Age = cmbAge.Text,
                Sex = cmbSex.Text,
                Temperature = txtTemp.Text,
                RoV = txtROV.Text,
                Question1 = rbQ1Y.Checked,
                Question2 = rbQ2Y.Checked,
                Question3 = rbQ3Y.Checked,
                Question4 = rbQ4Y.Checked,
            };
                var width = picQRCODE.Width;
                var height = picQRCODE.Height;
                IBarcodeWriter<PixelData> writer = new BarcodeWriterPixelData
                {

                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Height = picQRCODE.Height,
                        Width = picQRCODE.Width
                    },
                };

                var pixelData = writer.Write(JsonSerializer.Serialize(data));
                var Bitmap = new Bitmap(width, height);
                foreach ((byte[] pixel, int index) in pixelData.Pixels.Chunk(4).Zip(Enumerable.Range(0, Width * Height)))
                {

                    var color = Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);
                    var y = index / width;
                    var x = index % width;

                    Bitmap.SetPixel(x, y, color);

                }
                picQRCODE.Image = Bitmap;
            }

        private void btnGotoFilter_Click(object sender, EventArgs e)
        {
            form2 = new Form2(); 
            form2.originalform = this;
            form2.Show();
            this.Hide();
        }

        private void btnQRCR_Click(object sender, EventArgs e)
        {
            if (form3 is null)
            {
                form3 = new Form3();
                form3.QRCodeRead += qrcodeauto_fill;
                form3.FormClosed += (sender, e) => 
                {
                    form3 = null;
                };
                form3.Show();
            }
            
        }
    }
    }


