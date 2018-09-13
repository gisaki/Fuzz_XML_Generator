using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class BaseXMLNodeDecorator : IXMLNodeDecorator
    {
        private class RootDecorator : IXMLNodeDecorator
        {
            public string beforeStartElement() { return "<"; }
            public string afterStartElement() { return ">"; }

            public string beforeAttributeName() { return " "; }
            public string afterAttributeName() { return ""; }

            public string beforeAttributeValue() { return ""; }
            public string afterAttributeValue() { return ""; }
            public string AttributeQuote() { return "\""; }

            public string beforeEndElement() { return "</"; }
            public string afterEndElement() { return ">"; }
        }

        protected IXMLNodeDecorator dec_;
        public BaseXMLNodeDecorator()
        {
            this.dec_ = new RootDecorator();
        }

        // innner Decorator
        public virtual string beforeStartElement() { return this.dec_.beforeStartElement(); }
        public virtual string afterStartElement() { return this.dec_.afterStartElement(); }

        public virtual string beforeAttributeName() { return this.dec_.beforeAttributeName(); }
        public virtual string afterAttributeName() { return this.dec_.afterAttributeName(); }

        public virtual string beforeAttributeValue() { return this.dec_.beforeAttributeValue(); }
        public virtual string afterAttributeValue() { return this.dec_.afterAttributeValue(); }
        public virtual string AttributeQuote() { return this.dec_.AttributeQuote(); }

        public virtual string beforeEndElement() { return this.dec_.beforeEndElement(); }
        public virtual string afterEndElement() { return this.dec_.afterEndElement(); }
    }
}
