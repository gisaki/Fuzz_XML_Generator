using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class XMLNodeDecorator : IXMLNodeDecorator
    {
        public string beforeStartElement() { return "<"; }
        public string afterStartElement() { return ">"; }

        public string beforeAttributeName() { return " "; }
        public string afterAttributeName() { return ""; }

        public string beforeAttributeValue() { return ""; }
        public string afterAttributeValue() { return ""; }

        public string beforeEndElement() { return "</"; }
        public string afterEndElement() { return ">"; }
    }
}
