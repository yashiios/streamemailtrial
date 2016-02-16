using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailService
{
    public partial class Service1 : ServiceBase
    {
        Database db = new Database();
        private Timer timer1 = null;
        public Service1()
        {
            InitializeComponent();
        }
        
        protected override void OnStart(string[] args)
        {
            this.dothis(null, null);
            timer1 = new Timer();
            this.timer1.Interval = 20000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.dothis);
            timer1.Enabled = true;
            Library.WriteErrorLog("Test window service started.");
        }
        public void dothis(object sender, ElapsedEventArgs e)
        {
            Email email = new Email();
            email.sendemail();
            //Library.WriteErrorLog("Timer ticked and some job has been done successfully.");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.WriteErrorLog("Test window service stopped.");
        }
    }
}
