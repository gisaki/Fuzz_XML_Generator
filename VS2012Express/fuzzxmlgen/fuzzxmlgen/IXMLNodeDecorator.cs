using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    // 
    // https://www.w3.org/TR/xml/
    // 

    public interface IXMLNodeDecorator
    {
        string beforeStartElement();
        string afterStartElement();

        string beforeAttributeName();
        string afterAttributeName();
        string beforeAttributeValue();
        string afterAttributeValue();
        string AttributeQuote();

        string beforeEndElement();
        string afterEndElement();
    }
}
