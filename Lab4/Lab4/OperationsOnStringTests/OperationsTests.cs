using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationsOnString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnString.Tests
{
    [TestClass()]
    public class OperationsTests
    {
        [DataTestMethod()]
        [DataRow("Ботинок", "кот", true)]
        [DataRow("Ботинок", "Кот", true)]
        [DataRow("Ботинок", "Бот", true)]
        [DataRow("Ботинок", "бот", true)]
        [DataRow("Ботинок", "ботинок", true)]
        [DataRow("Ботинок", "Биток", true)]
        [DataRow("Ботинок", "Ботинки", false)]
        [DataRow("Ботинок", "Самосвал", false)]
        [DataRow("Ботинок", "Тапочек", false)]
        [DataRow("Ботинок", "Туфелька", false)]
        [DataRow("Ботинок", "Кино", true)]
        [DataRow("Ботинок", "кино", true)]
        public void IsCanCreateWordTest(string word1, string word2, bool expResult)
        {
            Operations operations = new Operations();
            operations.CanCreateWord(word1, word2);
            Assert.AreEqual(expResult, operations.CanCreateWord(word1, word2));
        }

        [DataTestMethod()]
        [DataRow("djsfbak234sda324234dsjb", true)]
        [DataRow("djsfbakdsjb3123", true)]
        [DataRow("134djsfbakdsjb", true)]
        [DataRow("13133", false)]
        [DataRow("djsfbakdsjb", false)]
        [DataRow("/./././..///", false)]
        [DataRow("", false)]
        [DataRow("        ", false)]
        [DataRow("\\````~~~~)(*&(^!%@^", false)]
        [DataRow("\\````~~sdf134gfsighakdsjlf321sdf4sdf~~)(*&(^!%@^", true)]
        [DataRow("\\````~~dff 3~~)(*&(^!%@^", true)]
        [DataRow("\\````~~ 3~~)(321   ==q*&(^!344@^", true)]
        public void IsIncludeLetAndNumTest(string sentence, bool expResult)
        {
            Operations operations = new Operations();
            Assert.AreEqual(expResult, operations.IsIncludeLetAndNum(sentence));
        }

        [DataTestMethod()]
        [DataRow("dhua4iak3f13r4gt323", 347)]
        [DataRow("134134reraefafe111", 134245)]
        [DataRow("134rera12qe111", 257)]
        [DataRow("r12erу34к23a12q100e", 181)]
        public void CalcSumOfNumInSentenceTest(string sentence, int expResult)
        {
            Operations operations = new Operations();
            Assert.AreEqual(expResult, operations.CalcSumOfNumInSentence(sentence));
        }

        [DataTestMethod()]
        [DataRow("f32ff1faf ///// ~~~~ dasasda2~~~~~```+dasa2dd2++++++", 39)]
        [DataRow("+++++++++++rer31-------------f32ff1faf ///// ~~~~ dasasda2~~~~~```+dasa2dd2++++++", 70)]
        public void CalcSumOfNumInTextTest(string text, int expSum)
        {
            Operations operations = new Operations();
            int sum = operations.CalcSumOfNumInText(text);
            Assert.AreEqual(expSum, sum);
        }
    }
}