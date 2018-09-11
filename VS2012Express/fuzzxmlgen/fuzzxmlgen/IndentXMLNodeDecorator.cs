using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class IndentXMLNodeDecorator : IXMLNodeDecorator
    {
        private int depth_ = 0;
        public string beforeStartElement() 
        {
            depth_++; // for indent

            string ret = "";
            ret += "\r\n";
            ret += new string(' ', this.depth_ * 4);
            ret += "<";
            return ret;
        }
        public string afterStartElement() { return ">"; }

        public string beforeAttributeName() { return " "; }
        public string afterAttributeName() { return ""; }

        public string beforeAttributeValue() { return ""; }
        public string afterAttributeValue() { return ""; }

        public string beforeEndElement() { return "</"; }
        public string afterEndElement() {
            depth_--; // for indent

            return ">"; 
        }
    }
}
