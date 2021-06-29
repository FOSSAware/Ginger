#region License
/*
Copyright © Property of Amdocs Quality Engineering 
*/
#endregion

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GingerCoreCommon.ALM.QC
{
    public class QCTestInstance
    {
        public string Id { get; set; }
        public string CycleId { get; set; }
        public string TestId { get; set; }
        public string TestOrder { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Dictionary<string, object> ElementsField { get; set; }

        public QCTestInstance()
        {
            ElementsField = new Dictionary<string, object>();
        }

        public QCTestInstance ParseXML(XElement fields)
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
                    this.CycleId = field.Element("Value").Value;
                }
                else if (name.Equals("test-id"))
                {
                    this.TestId = field.Element("Value").Value;
                }
                else if (name.Equals("test-order") || name.Equals("order-id"))
                {
                    this.TestOrder = field.Element("Value").Value;
                }
                else if (name.Equals("name"))
                {
                    this.Name = field.Element("Value").Value;
                }
                else if (name.Equals("status"))
                {
                    this.Status = field.Element("Value").Value;
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

    public class QCTestInstanceColl : List<QCTestInstance>
    {
        public QCTestInstanceColl ParseXML(IEnumerable<XElement> testInstances)
        {
            foreach (var testInstance in testInstances)
            {
                if (testInstance.HasElements)
                    this.Add(new QCTestInstance().ParseXML(testInstance));
            }

            return this;
        }
    }

}
