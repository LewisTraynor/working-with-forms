using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LewisTraynor_SDPF_LO
{
    public partial class Form1 : Form
    {
        
        new List<int> userInputs = new List<int>();
        new List<int> fileSizeInputs = new List<int>();
        new List<double> Time = new List<double>();
        int listoffiles =0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            

            
            if (string.IsNullOrEmpty(txtFileSize.Text))
            {
                
                MessageBox.Show("Please Enter a File Size");
                txtFileSize.Clear();

            }
            else
            {
               
                int input = 0;
                bool parseSuccess = int.TryParse(txtFileSize.Text, out input);

                
                if (parseSuccess)
                {
                    
                    userInputs.Add(int.Parse(txtFileSize.Text));
                   
                    listoffiles = int.Parse(txtFileSize.Text);
                    lblNumbersEnterd.Text += listoffiles + ", ";

                    txtFileSize.Clear();
                }
                else
                {

                   
                    MessageBox.Show("Please Enter a valid File Size");
                    
                    txtFileSize.Clear();
                }
            }
           
            
           

        }

        private void btnShowLargest_Click(object sender, EventArgs e)
        {
            
            
            if (string.IsNullOrEmpty(lblNumbersEnterd.Text))
            {
                MessageBox.Show("Please enter some file Sizes");
            }
            else
            {
                int input = 0;
                bool parseSuccess = int.TryParse(txtFileSize.Text, out input);

                if (parseSuccess || listoffiles > 0)
                {

                    int largestInput = userInputs[0];

                    for (int i = 0; i < userInputs.Count; i++)
                    {
                        if (userInputs[i] > largestInput)
                        {
                            largestInput = userInputs[i];
                        }
                    }

                    lblLargestInput.Text = largestInput.ToString() + " MB";


                    txtFileSize.Clear();
                }
               
            } 
        }


        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtSecondName.Text))
            {

                MessageBox.Show("Please Enter your first and last name");


            }
            else
            { 
                        char[] whiteSpace = { ' ' };
                        string firstname = txtFirstName.Text;
                        string surname = txtSecondName.Text;
                        string username = "";

                        username = firstname.Trim(whiteSpace).Substring(0, 1) + surname.Trim(whiteSpace);

                        lblUsername.Text = username;

                        txtSecondName.Clear();
                        txtFirstName.Clear();
                

            }
        }

        private void btnAddFiles_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileMemoryAvrage.Text))
            {
                MessageBox.Show("Please Enter File Memory Size");
            }
            else
            {
                int input = 0;
                bool parseSuccess = int.TryParse(txtFileMemoryAvrage.Text, out input);

                if (parseSuccess)
                {

                    fileSizeInputs.Add(int.Parse(txtFileMemoryAvrage.Text));
                    lstAvrage.Items.Add(int.Parse(txtFileMemoryAvrage.Text));
                }
                else
                {
                    MessageBox.Show("Please Enrer a valid input");
                    
                }
                 txtFileMemoryAvrage.Clear();
            }
        }

        private void btnShowDetails_Click_1(object sender, EventArgs e)
        {
            if(lstAvrage.Items.Count == 0)
            {
                MessageBox.Show("Please Enter File Memory Size befor finding detials");
            }
            else
            {

                int maxSpace = 0;
                int avrageSpace = 0;
                int totalfiles = 0;

                foreach (int space in fileSizeInputs)
                {
                    maxSpace += space;
                    totalfiles++;
                }

                avrageSpace = maxSpace / fileSizeInputs.Count;
                lstAvrage.Items.Clear();
                lstAvrage.Items.Add("Avrage space: "+avrageSpace+" MB");
                lstAvrage.Items.Add("total amount of files: " + totalfiles);
                lstAvrage.Items.Add("total space: " + maxSpace+ "MB");
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimeInput.Text))
            {
                MessageBox.Show("Please Add Time");

            }

            else

            {
                double input = 0;
                bool parseSuccess = double.TryParse(txtTimeInput.Text, out input);

                if (parseSuccess)
                {
                    Time.Add(double.Parse(txtTimeInput.Text));
                    double timeInputs = double.Parse(txtTimeInput.Text);
                    lblListSort.Text += timeInputs + "ms, ";
                    txtTimeInput.Clear();
                }
                else
                {
                    MessageBox.Show("Please Add The correct input");
                }
            }
           

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblListSort.Text))
            {
                MessageBox.Show("Please enter Times");
            }
            else
            {
                Time.Sort();
                lblListSort.Text = String.Join("ms, " ,Time) + "ms";
            }

       

        }
    }
}
