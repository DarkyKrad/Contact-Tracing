namespace Contact_Tracing_Form_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            StreamWriter file = new StreamWriter(@"C:\Users\Public\Desktop\test.txt", true);
            file.WriteLine("Fullname: " + txtFN.Text);
            file.WriteLine("Complete Address: " + txtCA.Text);
            file.WriteLine("Phone Number: " + txtPN.Text);
            file.WriteLine("Age: " + cmbAge.Text);
            file.WriteLine("Sex: " + cmbSex.Text);
            file.WriteLine("Temperature: " + txtTemp.Text);
            file.WriteLine("Reason of Visit: " + txtROV.Text);
            file.WriteLine("Time of Visit: " + txtTOV.Text);
            file.WriteLine("Date of Visit: " + dtpDOV.Text);

            if (rbQ1Y.Checked)
            {
                file.WriteLine("Question 1: Yes");
            }
            else if(rbQ1N.Checked)
            {
                file.WriteLine("Question 1: No");
            }
            if (rbQ2Y.Checked)
            {
                file.WriteLine("Question 2: Yes");
            }    
            else if(rbQ2N.Checked)
            {
                file.WriteLine("Question 2: No");
            }
            if (rbQ3Y.Checked)
            {
                file.WriteLine("Question 3: Yes");
            }    
            else if(rbQ3N.Checked)
            {
                file.WriteLine("Question 3: No");
            }    
            if (rbQ4Y.Checked)
            {
                file.WriteLine("Question 4: Yes");
            }
            else if(rbQ4N.Checked)
            {
                file.WriteLine("Question 4: No");
            }

            file.WriteLine();
            file.Close();
            MessageBox.Show("Thank you for your time!");
            this.Close();
        }

    }
}