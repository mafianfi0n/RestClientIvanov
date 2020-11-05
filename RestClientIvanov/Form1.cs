using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestClientIvanov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.SelectionLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void CmdGO_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = txtRestUrl.Text;

            debugOutput("rest client created");

            string strResponse = string.Empty;
            strResponse = rClient.MakeRequest();

            debugOutput(strResponse);
        }
    }
}
