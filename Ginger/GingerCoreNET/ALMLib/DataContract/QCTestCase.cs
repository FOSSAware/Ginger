#region License
/*
Copyright © Property of Amdocs Quality Engineering 
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GingerCoreNET.ALMLib.DataContract
{
    public class QCTestCase
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public string TestSetId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string PlanName { set; get; }

        public Dictionary<string, object> ElementsField { set; get; }

        public QCTestCase()
        {
            ElementsField = new Dictionary<string, object>();
        }

        public QCTestCase FromXML(IEnumerable<XElement> fields)
        {
            foreach (var field in fields)
            {
                string name = field.Attribute("Name").Value;
                if (name.Equals("id"))
                {
                    this.Id = field.Element("Value").Value;
                }
                else if (name.Equals("test-id"))
                {
                    this.TestId = field.Element("Value").Value;
                }
                else if (name.Equals("cycle-id"))
                {
                    this.TestSetId = field.Element("Value").Value;
                }
                else if (name.Equals("status"))
                {
                    this.Status = field.Element("Value").Value;
                }
                else if (name.Equals("name"))
                {
                    this.Name = field.Element("Value").Value;
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

    public class QCTestCaseColl : List<QCTestCase> { }
}
