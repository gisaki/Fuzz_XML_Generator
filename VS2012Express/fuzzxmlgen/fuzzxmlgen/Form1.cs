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
        private int depth_ = 0;
        private string ParseXML(string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            return findAllNodes(xmlDocument);
        }
        private string findAllNodes(XmlNode node)
        {
            string ret = "";
            this.depth_++;

            Console.WriteLine("node.NodeType = [" + node.NodeType + "]");
            Console.WriteLine("node.Name = [" + node.Name + "]");
            Console.WriteLine("node.Value = [" + node.Value + "]");

            ret += printNodeTagStart(node);
            foreach (XmlNode n in node.ChildNodes)
            {
                ret += findAllNodes(n);
            }
            ret += printNodeTagEnd(node);
            this.depth_--;
            return ret;
        }
        private string printNodeTagStart(XmlNode node)
        {
            string ret = "";
            // 開始タグ
            switch (node.NodeType)
            {
                case XmlNodeType.Document:
                    /* nop */
                    break;
                case XmlNodeType.XmlDeclaration:
                    ret += "<?" + node.Name + " " + node.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    ret += "\r\n";
                    ret += new string(' ', this.depth_ * 4);
                    ret += "<" + node.Name;
                    if (node.Attributes != null)
                    {
                        foreach (XmlNode attr in node.Attributes)
                        {
                            Console.WriteLine("attr.Name = [" + attr.Name + "]");
                            Console.WriteLine("attr.Value = [" + attr.Value + "]");
                            ret += " " + attr.Name;
                            ret += "=" + "\"" + attr.Value + "\"";
                        }
                    }
                    ret += ">";
                    break;
                case XmlNodeType.Text:
                    ret += node.Value;
                    break;
                default:
                    break;
            }
            return ret;
        }
        private string printNodeTagEnd(XmlNode node)
        {
            string ret = "";
            // 終了タグ
            switch (node.NodeType)
            {
                case XmlNodeType.Element:
                    /* nop */
                    ret += "</" + node.Name;
                    ret += ">";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
