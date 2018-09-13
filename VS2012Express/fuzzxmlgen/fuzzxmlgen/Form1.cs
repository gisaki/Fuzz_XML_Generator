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

            // Generate Nested Decorator, then parse
            return findAllNodes(GenNestedDecorator(), xmlDocument);
        }
        private IXMLNodeDecorator GenNestedDecorator()
        {
            IXMLNodeDecorator base_dec = new BaseXMLNodeDecorator();

            IXMLNodeDecorator inner_dec = base_dec;
            IXMLNodeDecorator ret_dec = inner_dec;

            // Generate Nested Decorator
            if (this.checkBox_AttrSingleQuote.Checked)
            {
                // wrap
                inner_dec = new AttrSingleQuoteXMLNodeDecorator(inner_dec);
                ret_dec = inner_dec;
            }
            if (this.checkBox_Indent.Checked)
            {
                // wrap
                IndentXMLNodeDecorator.IndentType indent_type;
                int indent_num;
                if (this.radioButton_Indent_space.Checked) {
                    indent_type = IndentXMLNodeDecorator.IndentType.space;
                    indent_num = 4; // todo
                } else if (this.radioButton_Indent_tab.Checked){
                    indent_type = IndentXMLNodeDecorator.IndentType.tab;
                    indent_num = 1; // todo
                } else {
                    indent_type = IndentXMLNodeDecorator.IndentType.other;
                    indent_num = 2; // todo
                }

                inner_dec = new IndentXMLNodeDecorator(inner_dec, indent_type, indent_num);
                ret_dec = inner_dec;
            }
            if (this.checkBox_LineBreakBeforeAttr.Checked)
            {
                // wrap
                bool cr = this.checkBox_LineBreakBeforeAttr_CR.Checked;
                bool lf = this.checkBox_LineBreakBeforeAttr_LF.Checked;
                inner_dec = new LineBreakBeforeAttrXMLNodeDecorator(inner_dec, cr, lf);
                ret_dec = inner_dec;
            }

            return ret_dec;
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
                            ret += dec.AttributeQuote();
                            ret += attr.Value;
                            ret += dec.AttributeQuote();
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
