using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //[TestMethod]
        //public void TestRenderComp()
        //{
        //    TransformData SpawnTest = new TransformData();
        //    SpawnTest.SetPosition(500, 500);
        //    string path = "GameAssets/movimiento1.png";
        //    // Entity test = new Entity("pepe", 10, 10, 10, SpawnTest, "GameAssets/movimiento1.png");
        //    Entity test1;
        //    test1 = new Entity(SpawnTest, "GameAssets/movimiento1.png");
        //    string texturaOK = test1.texture;
        //    Assert.AreEqual(path, texturaOK);
        //    Console.Write("\n");
        //    Console.Write(test1.texture);
        //}



        [TestMethod]
        //PRUEBA DE POSICION, METODO SETPOSITION
        public void TestTransform()
        {
            TransformData transform = new TransformData();
            float x, y;
            x = 5;
            y = 10;

            transform.SetPosition(x, y);

            Assert.AreEqual(x, transform.PositionX);
            Console.Write(transform);
            Console.Write("\n");
            Console.Write(transform.PositionX);
        }


        [TestMethod]
        //PRUEBA DE FORMULA DE DAÑO
        public void TestArmorCalc()
        {
            float armor;
            float dmg=10;
            float hp =60;

            float dmgFinal;

            for (int i = 0; i<6; i++)
            {
                armor = GameManager.Instance.playerArmor;
                dmgFinal = dmg - armor;
                if (dmgFinal < 0) dmgFinal = 0;
                hp = hp - dmgFinal;
                Console.WriteLine($"recibió {dmgFinal} de daño. Vida restante: {hp}");
                GameManager.Instance.playerArmor += 2;
                Console.WriteLine($"Armadura actual {armor}");
            }
           
        }





    }



}
