#region License
/*
Copyright © Property of Amdocs Quality Engineering 
*/
#endregion

using System.Collections.Generic;
using System.Xml.Linq;

namespace GingerCoreNET.ALMLib.DataContract
{
    public class QCRun
    {
        public string Id { get; set; }
        public string TestSetId { get; set; }
        public string TestCaseId { get; set; }
        public string TestInstanceId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }

        public Dictionary<string, object> ElementsField { set; get; }

        public QCRun()
        {
            ElementsField = new Dictionary<string, object>();
        }

        public QCRun ParseXML(XElement fields)
        {
            var fieldsElements = QCRestHelper.GetFieldsElements(fields);
            foreach (var field in fieldsElements)
            {
                string name = field.Attribute("Name").Value;
                if (name.Equals("id"))
                {
                    this.Id = field.Element("Value").Value;
                }
                else if (name.Equals("cycle-id"))
                {
                    this.TestSetId = field.Element("Value").Value;
                }
                else if (name.Equals("test-id"))
                {
                    this.TestCaseId = field.Element("Value").Value;
                }
                else if (name.Equals("testcycl-id"))
                {
                    this.TestInstanceId = field.Element("Value").Value;
                }
                else if (name.Equals("name"))
                {
                    this.Name = field.Element("Value").Value;
                }
                else if (name.Equals("status"))
                {
                    this.Status = field.Element("Value").Value;
                }
                else if (name.Equals("owner"))
                {
                    this.Owner = field.Element("Value").Value;
                }
                else
                {
                    var curName = field.Attribute("Name").Value;
                    var curValue = field.Element("Value");

                    if (curValue == null)
                    {
                        continue;
                    }
                    var value = curValue.Value;
                    this.ElementsField.Add(curName, value);
                }

            }

            return this;
        }
    }

    public class QCRunColl : List<QCRun>
    {
        public QCRunColl ParseXML(IEnumerable<XElement> runs)
        {
            foreach (var run in runs)
            {
                if (run.HasElements)
                    this.Add(new QCRun().ParseXML(run));
            }

            return this;
        }
    }
}
