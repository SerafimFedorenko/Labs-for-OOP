using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormulaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaLibrary.Tests
{
    [TestClass()]
    public class ParsingTests
    {
        [DataTestMethod()]
        [DataRow("f(x)=sin(x)+cos(x)", true)]
        [DataRow("f(x)=sin(x)+cos(y)", false)]
        [DataRow("f(x)=sin(x)+cs(x))", false)]
        [DataRow("f(x)=sin(x)+cs(x))", false)]
        [DataRow("f(x)=sn(x)+cos(x)", false)]
        [DataRow("f(y)=ctg(y)+tg(y)", true)]
        public void CheckCorrectnessTest(string formula, bool expResult)
        {
            Parsing parsing = new Parsing();
            Assert.AreEqual(expResult, parsing.CheckCorrectness(formula));
        }

        [DataTestMethod()]
        [DataRow("f(x)=sin(x)+cos(x)", "sin", "cos")]
        [DataRow("f(x)=ctg(x)+tg(x)", "ctg", "tg")]
        [DataRow("f(y)=ctg(y)+tg(y)", "ctg", "tg")]
        public void GetFunctionsTest(string formula, string expFunc1, string expFunc2)
        {
            Parsing parsing = new Parsing();
            Assert.AreEqual(expFunc1, parsing.GetFunctions(formula)[0]);
            Assert.AreEqual(expFunc2, parsing.GetFunctions(formula)[1]);
        }

        [DataTestMethod()]
        [DataRow("f(x)=sin(x)+cos(x)", 5, -0.67526209)]
        [DataRow("f(x)=tg(x)+ctg(x)", -1, -2.1995)]
        public void CalcFunctionTest(string formula, double point, double expResult)
        {
            Parsing parsing = new Parsing();
            Assert.AreEqual(expResult, parsing.CalcFunction(formula, point), 0.01);
        }
    }
}