#region License
/*
Copyright © Property of Amdocs Quality Engineering 
*/
#endregion

using System.Collections.Generic;
using System.Xml.Linq;

namespace GingerCoreNET.ALMLib.DataContract
{
    public class QCTestCaseStep
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string StepOrder { get; set; }

        public Dictionary<string, object> ElementsField { set; get; }

        public QCTestCaseStep()
        {
            ElementsField = new Dictionary<string, object>();
        }

        public QCTestCaseStep ParseXML(XElement fields)
        {
            var fieldsElements = QCRestHelper.GetFieldsElements(fields);
            foreach (var field in fieldsElements)
            {
                string name = field.Attribute("Name").Value;
                if (name.Equals("id"))
                {
                    this.Id = field.Element("Value").Value;
                }
                else if (name.Equals("parent-id"))
                {
                    this.TestId = field.Element("Value").Value;
                }
                else if (name.Equals("description"))
                {
                    this.Description = field.Element("Value").Value;
                }
                else if (name.Equals("step-order"))
                {
                    this.StepOrder = field.Element("Value").Value;
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

        public QCTestCaseStep FromXML(IEnumerable<XElement> fields)
        {
            foreach (var field in fields)
            {
                string name = field.Attribute("Name").Value;
                if (name.Equals("id"))
                {
                    this.Id = field.Element("Value").Value;
                }
                else if (name.Equals("parent-id"))
                {
                    this.TestId = field.Element("Value").Value;
                }
                else if (name.Equals("description"))
                {
                    this.Description = field.Element("Value").Value;
                }
                else if (name.Equals("step-order"))
                {
                    this.StepOrder = field.Element("Value").Value;
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

    public class QCTestCaseStepsColl : List<QCTestCaseStep>
    {
        public QCTestCaseStepsColl ParseXML(IEnumerable<XElement> steps)
        {
            foreach (var step in steps)
            {
                if (step.HasElements)
                    this.Add(new QCTestCaseStep().ParseXML(step));
            }

            return this;
        }
    }
}
