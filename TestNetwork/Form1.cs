using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*ListenHook hook = new ListenHook();
            hook.ConnectAsync();*/
        }

        private void тестConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestConnectionForm testConnection = new TestConnectionForm();
            testConnection.MdiParent = this;
            testConnection.Show();
        }
    }
}
