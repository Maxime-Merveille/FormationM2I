using System;
using System.Collections.Generic;
using System.Text;
using Bordel;
using NUnit.Framework;

namespace Unittest
{
    internal class CalculTests
    {
        private Calcul calcul = new Calcul();

        [Test]
        public void TestAdd()
        {
            NUnit.Framework.Assert.AreEqual(10, calcul.Add(4,6));
        }

        [Test]
        public void TestAdd2()
        {
            NUnit.Framework.Assert.AreNotEqual(10, calcul.Add(5, 6));
        }

        [Test]
        public void TestMinus()
        {           
            NUnit.Framework.Assert.AreEqual(2, calcul.Minus(6, 4));
        }

        [Test]
        public void TestMinus2()
        {
            NUnit.Framework.Assert.AreNotEqual(5, calcul.Minus(5, 6));
        }
    }
}
