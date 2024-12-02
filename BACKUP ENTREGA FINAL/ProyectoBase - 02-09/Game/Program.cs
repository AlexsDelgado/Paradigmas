using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Engine.Initialize();
            TransformData transform = new TransformData(50,50);
            Character player = new Character("Hero", 10, 1, 1, transform);

            npc john = new npc("John", transform);
            Enemy badGuy1 = new Enemy("Mavado", "GameAssets/Personaje/enemy.png", "GameAssets/Personaje/batIcon.png", 5, 2, 2, transform);
            PlayerController playerController = new PlayerController(player);
            NPCController npcController = new NPCController(john);
            EnemyController enemyController = new EnemyController(badGuy1);
            TimeManager timeManager = new TimeManager();
            LevelManager levelManager = new LevelManager(playerController, npcController, enemyController);
            UIManager uiManager = new UIManager(Engine.GetTexture("GameAssets/Assets/barra1.png"), Engine.GetTexture("GameAssets/Assets/barra2.png"));

            while (true)
            {
                //UPDATE
                float deltaTime = timeManager.GetDeltaTime();
                GameManager.Instance.Update();
                playerController.Update(deltaTime);
                levelManager.UpdateLevelCollisions();

                //RENDER
                Engine.Clear();
                GameManager.Instance.Render();
                Engine.Show();
            }
        }
    }
}
