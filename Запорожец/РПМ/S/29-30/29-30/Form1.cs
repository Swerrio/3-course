using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _29_30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateXml_Click(object sender, EventArgs e)
        {
            string path = "StudentData.xml";

            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            writer.WriteStartDocument();

            writer.WriteStartElement("LabWork");

            writer.WriteStartElement("Student");

            writer.WriteElementString("FullName", "Нестеренко Никита Александрович");
            writer.WriteElementString("Variant", "15");
            writer.WriteElementString("BirthYear", "2008");
            writer.WriteElementString("Age", "18");
            writer.WriteElementString("LabName", "Работа с XML-документами");

            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();

            MessageBox.Show("XML-файл успешно создан!");
        }
    }
}