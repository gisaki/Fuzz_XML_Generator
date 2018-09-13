using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class IndentXMLNodeDecorator : BaseXMLNodeDecorator
    {
        public enum IndentType { space, tab, other };

        private IndentXMLNodeDecorator() { }
        public IndentXMLNodeDecorator(IXMLNodeDecorator dec, IndentType indent_type, int indent_num)
            : this()
        {
            this.dec_ = dec;
            this.indent_type_ = indent_type;
            this.indent_num_ = indent_num;
        }

        private int depth_ = 0;
        private IndentType indent_type_ = IndentType.space;
        private int indent_num_ = 0;
        override public string beforeStartElement() 
        {
            depth_++; // for indent

            string ret = "";
            ret += "\r\n";
            switch (this.indent_type_)
            {
                case IndentType.space:
                    ret += new string(' ', this.depth_ * this.indent_num_);
                    break;
                case IndentType.tab:
                    ret += new string('\t', this.depth_ * this.indent_num_);
                    break;
                case IndentType.other:
                default:
                    ret += new string('-', this.depth_ * this.indent_num_);
                    break;
            }
            return ret + this.dec_.beforeStartElement(); // innner Decorator;
        }
        override public string afterEndElement() {
            depth_--; // for indent

            return this.dec_.afterEndElement(); // innner Decorator
        }
    }
}
