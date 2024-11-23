using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testTransform()
        {
            TransformData transform = new TransformData();
            float x, y;

            x = 5;
            y = 10;
            transform.PositionX = x;
            transform.PositionY = y;

            Assert.AreEqual(transform.PositionX, x);
            Console.Write(transform);

        }
    }
}
