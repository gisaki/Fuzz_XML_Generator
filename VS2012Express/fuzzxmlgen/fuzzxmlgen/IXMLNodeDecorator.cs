using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzxmlgen
{
    public interface IXMLNodeDecorator
    {
        string beforeStartElement();
        string afterStartElement();

        string beforeAttributeName();
        string afterAttributeName();
        string beforeAttributeValue();
        string afterAttributeValue();

        string beforeEndElement();
        string afterEndElement();
    }
}
