using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieMeter.WebHarvester.Interpreters;

namespace MovieMeter.Test
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void TMNInterpreter_GivenNull_RetunsEmptyList()
        {
            var interpreter = new TMNInterpreter();

            var result = interpreter.Interpret(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TMNInterpreter_GivenEmptyString_RetunsEmptyList()
        {
            var interpreter = new TMNInterpreter();

            var result = interpreter.Interpret("");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
