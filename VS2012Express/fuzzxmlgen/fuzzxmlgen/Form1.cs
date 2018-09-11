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

namespace fuzzxmlgen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 
        // Drop
        //
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Get the dropped filenames
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // TODO
            // string xmltext = File.ReadAllText(fileNames[0], Encoding.Default);
            // textBox1.Text = xmltext;

            // XML Parse
            textBox1.Text = ParseXML(fileNames[0]);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // check if files or not
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string d in drags)
                {
                    // if not files, reject all
                    if (!System.IO.File.Exists(d))
                    {
                        return;
                    }
                }
                // If all are files and exist, accept them
                e.Effect = DragDropEffects.Copy;
            } 
        }

        // 
        // XML
        // 
        private string ParseXML(string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            return findAllNodes(new IndentXMLNodeDecorator(), xmlDocument);
        }
        private string findAllNodes(IXMLNodeDecorator dec, XmlNode node)
        {
            string ret = "";

            Console.WriteLine("node.NodeType = [" + node.NodeType + "]");
            Console.WriteLine("node.Name = [" + node.Name + "]");
            Console.WriteLine("node.Value = [" + node.Value + "]");

            ret += printNodeTagStart(dec, node);
            foreach (XmlNode n in node.ChildNodes)
            {
                ret += findAllNodes(dec, n);
            }
            ret += printNodeTagEnd(dec, node);

            return ret;
        }
        private string printNodeTagStart(IXMLNodeDecorator dec, XmlNode node)
        {
            string ret = "";
            // start tag or start element
            switch (node.NodeType)
            {
                case XmlNodeType.Document:
                    /* nop */
                    break;
                case XmlNodeType.XmlDeclaration:
                    ret += "<?" + node.Name + " " + node.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    ret += dec.beforeStartElement();
                    ret += node.Name;
                    if (node.Attributes != null)
                    {
                        foreach (XmlNode attr in node.Attributes)
                        {
                            Console.WriteLine("attr.Name = [" + attr.Name + "]");
                            Console.WriteLine("attr.Value = [" + attr.Value + "]");
                            ret += dec.beforeAttributeName();
                            ret += attr.Name;
                            ret += dec.afterAttributeName();
                            ret += "=";
                            ret += dec.beforeAttributeValue();
                            ret += "\"" + attr.Value + "\"";
                            ret += dec.afterAttributeValue();
                        }
                    }
                    ret += dec.afterStartElement();
                    break;
                case XmlNodeType.Text:
                    ret += node.Value;
                    break;
                default:
                    break;
            }
            return ret;
        }
        private string printNodeTagEnd(IXMLNodeDecorator dec, XmlNode node)
        {
            string ret = "";
            // end tag or end element
            switch (node.NodeType)
            {
                case XmlNodeType.Element:
                    ret += dec.beforeEndElement();
                    ret += node.Name;
                    ret += dec.afterEndElement();
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
