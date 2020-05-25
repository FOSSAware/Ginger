﻿#region License
/*
Copyright © 2014-2020 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion
using Amdocs.Ginger.Common.Enums;
using GingerCore;
using GingerCore.Variables;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GingerCoreCommonTest.VariableTests
{
    [TestClass]
    [Level1]
    public class DateTimeVariableTest
    {
        #region Default Class/Test Initialize Methods
        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            //
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // before every test
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //after every test
        }
        #endregion

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestVariableType()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();

            //Act
            string varType = variableDateTime.VariableType;

            //Assert            
            Assert.AreEqual("DateTime", varType, "DateTime Variable Type");
        }

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestVariableUIType()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();

            //Act
            GingerTerminology.TERMINOLOGY_TYPE = eTerminologyType.Default;
            string varType = variableDateTime.VariableUIType;

            //Assert
            Assert.AreEqual("Variable DateTime", varType, "DateTime Variable UI Type");
        }

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestImageType()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();

            //Act
            eImageType eimageType = variableDateTime.Image;

            //Assert
            Assert.AreEqual(eImageType.DatePicker, eimageType, "Image Type");
        }

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestFormulaVal()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();
            variableDateTime.Name = "test";
            variableDateTime.Value = "123";
            variableDateTime.InitialDateTime = "01-Jan-2020";
            //Act
            string formulaStr = variableDateTime.GetFormula();

            //Assert
            Assert.AreEqual(@"Initial DateTime : 01-Jan-2020", formulaStr, "Mismatch with Default Formula String");
            Assert.AreEqual(variableDateTime.InitialDateTime, variableDateTime.Value);
        }

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestResetVal()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();
            variableDateTime.Name = "test";
            variableDateTime.Value = "23/04/2018";

            //Act
            variableDateTime.ResetValue();

            //Assert
            Assert.IsNull(variableDateTime.Value, "Reset Value not null");
        }

        [TestMethod]
        [Timeout(60000)]
        public void DateTimeVar_TestVal()
        {
            //Arrange
            var variableDateTime = new VariableDateTime();
            variableDateTime.Name = "test";
            variableDateTime.Value = "23/04/2018";

            //Act

            //Assert
            Assert.AreEqual("23/04/2018", variableDateTime.Value, "DateTime Value");
        }
    }
}
