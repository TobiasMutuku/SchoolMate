using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace School_Software
{


    class Connectionstring
    {

        public string DBCon;
        public string ReadfromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            DBCon = root.Attributes.Item(0).Value;
            return DBCon;
        }

        //public string DBCon = @"Data Source=.;Initial Catalog=ERPS_DB;Integrated Security=True";
        //This is your direct connection below..
        //public string ReadfromXML() = @"Data Source=.;Initial Catalog=ERPS_DB;Integrated Security=True";
         //public string ReadfromXML() = @"Data Source=.;Initial Catalog=SERP;Persist Security Info=True;User ID=sa;Password=net@123@";
        //public string ReadCS()
        //{
        //    using (StreamReader sr = new StreamReader(Application.StartupPath + @"\SQLSettings.dat"))
        //    {
        //        Connection = sr.ReadLine();
        //    }
        //    return Connection;
        //}

    }
}
