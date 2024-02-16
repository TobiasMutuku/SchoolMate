using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_Software
{
    class clsTrial
    {
        private string temp = "";
        public void SetNewDate()
        {
            DateTime newDate = DateTime.Now.AddDays(31);
            temp = newDate.ToLongDateString();
            StoreDate(temp);
        }

        /// <summary>
        /// Checks if expire or NOT.
        /// </summary>
        public void Expired()
        {
            string d = "";
            using (Microsoft.Win32.RegistryKey key =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\test3"))
            {
                d = (String)key.GetValue("Date");
            }
            DateTime d1 = DateTime.Parse(d);
            int day = (d1.Subtract(DateTime.Now)).Days;
          
                if (day > 30)
                {

                    MessageBox.Show("Trial expired" + "\n" + "for purchasing the full version of software contact us at +919011074525", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
 
            else if (0 < day && day <= 30)
            {
                string daysLeft = string.Format("{0} days more to expire", d1.Subtract(DateTime.Now).Days);
                MessageBox.Show(daysLeft);
            }
            else if (day <= 0)  
            {
                MessageBox.Show("Trial expired" + "\n" + "for purchasing the full version of software contact us at +919011074525", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Stores the new date value in registry.
        /// </summary>
        /// <param name="value"></param>
        private void StoreDate(string value)
        {
            try
            {
                using (Microsoft.Win32.RegistryKey key =
                    Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\test3"))
                {
                    key.SetValue("Date", value, Microsoft.Win32.RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
