using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class AttrSingleQuoteXMLNodeDecorator : BaseXMLNodeDecorator
    {
        private AttrSingleQuoteXMLNodeDecorator() {}
        public AttrSingleQuoteXMLNodeDecorator(IXMLNodeDecorator dec)
            : this()
        {
            this.dec_ = dec;
        }

        override public string AttributeQuote() { return "'"; }
    }
}
