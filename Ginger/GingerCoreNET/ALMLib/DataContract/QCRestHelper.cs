using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GingerCoreNET.ALMLib.DataContract
{
    public static class QCRestHelper
    {
        public static IEnumerable<XElement> GetFieldsElements(XElement fields)
        {
            var fieldsElements = fields.Elements("Fields").Elements();
            if (fields.Elements("Fields").Elements().Count() == 0)
                fieldsElements = fields.Elements();
            return fieldsElements;
        }
    }
}
