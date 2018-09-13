using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public class LineBreakBeforeAttrXMLNodeDecorator : BaseXMLNodeDecorator
    {
        private LineBreakBeforeAttrXMLNodeDecorator() {}
        public LineBreakBeforeAttrXMLNodeDecorator(IXMLNodeDecorator dec, bool cr, bool lf)
            : this()
        {
            this.dec_ = dec;
            this.cr_ = cr;
            this.lf_ = lf;
        }

        private bool cr_;
        private bool lf_;
        override public string beforeAttributeName()
        {
            // S   ::=   ( #x20 | #x9 | #xD | #xA )+
            string ret = "";
            if (this.cr_) { ret += Convert.ToChar(0x0d).ToString(); }
            if (this.lf_) { ret += Convert.ToChar(0x0a).ToString(); }
            return ret + this.dec_.beforeAttributeName(); // innner Decorator
        }
    }
}
