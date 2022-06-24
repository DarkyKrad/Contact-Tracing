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
            if (txtFN.Text == "" || txtCA.Text == "" || txtPN.Text == "" || txtROV.Text == "" || txtTemp.Text == "" || txtTOV.Text == "" || cmbAge.Text == "" || cmbSex.Text == "" || dtpDOV.Text == "")
            {
                MessageBox.Show("Please fill out the remaining forms");
                return;
            }

            if (!(rbQ1Y.Checked || rbQ1N.Checked)  || !(rbQ2Y.Checked || rbQ2N.Checked) || !((rbQ3Y.Checked || rbQ3N.Checked) || !(rbQ4Y.Checked || rbQ4N.Checked)))
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
            file.WriteLine("Time of Visit: " + txtTOV.Text);
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
            MessageBox.Show("Thank you for your time!");
            
            Form2 form2 = new Form2();
            form2.originalform = this;
            form2.Show();
            this.Hide();


        }

    }
}