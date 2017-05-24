using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\errorlog\\log.xml");


            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                // first node is the url ... have to go to nexted loc node 
                foreach (XmlNode logNode in node)
                {
                    // thereare a couple child nodes here so only take data from node named loc 

                    if (logNode.Name == "Texto")
                    {
                        foreach (XmlNode hijonodo in logNode.ChildNodes)
                        {
                            if (hijonodo.Name == "Parrafo")
                            {
                                hijonodo.InnerText = "josechapinx2.blogspot.com";

                            }
                        }
                        // get the content of the loc node 
                        string loc = logNode.InnerText;

                        // write it to the console so you can see its working 
                        System.Windows.Forms.MessageBox.Show(loc);
                        if (logNode.Attributes.Count > 0)
                        {
                            foreach (XmlAttribute attr in logNode.Attributes)
                            {
                                if (attr.Name == "Leido")
                                {
                                    attr.Value = attr.Value + ", " + DateTime.Now.ToShortTimeString();
                                }
                            }
                        }
                        else
                        {
                            XmlAttribute attr = doc.CreateAttribute("Leido");
                            attr.Value = DateTime.Now.ToShortTimeString();
                            logNode.Attributes.Append(attr);
                        }
                        doc.Save("c:\\errorlog\\log.xml");
                    }
                }
            }

        }
    }
}
