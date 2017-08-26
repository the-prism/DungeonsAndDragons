using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Entities;
using DragonLib.Types;
using Newtonsoft.Json;

namespace DragonLibUnitTests.Entities
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TestComplexSerialization()
        {
            Player tester = new Player(4, 3, 1);
            Bounds limits = new Bounds(0, 34, 2, 3, 0, 5);
            tester.SetBounds(limits);
            tester.Location = "Bro"
            string json = JsonConvert.SerializeObject(tester);
        }
    }
}
