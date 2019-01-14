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
    public delegate void CallBack();

    public partial class Form1 : Form, OnGetMessage
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*ListenHook hook = new ListenHook();
            hook.ConnectAsync();*/
            CallBack callback = new CallBack(onGetMessage);
            new SocketManagement().Execute(callback);
        }

        private void тестConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestConnectionForm testConnection = new TestConnectionForm();
            testConnection.MdiParent = this;
            testConnection.Show();
        }

        public void onGetMessage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate {
                    showFormTest();
                }));
            }
            else
            {
                showFormTest();
            }
        }

        private void showFormTest()
        {
            try
            {
                TestConnectionForm testConnection = new TestConnectionForm();
                testConnection.MdiParent = this;
                testConnection.Show();
            }

            catch (InvalidOperationException exp)
            {
                Console.WriteLine(exp.ToString());
            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }
    }
}
