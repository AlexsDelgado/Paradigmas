using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel2 : Level
    {
        private PlayerController playerController;
        private Enemy badGuy;
        private TimeManager timeManager;
        private TransformData SpawnPoint;


        public GameLevel2(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            SpawnPoint = new TransformData(0,0);
            SpawnPoint.SetPosition(50, 50);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            //Character player = new Character("Hero", 100, 10, 5, SpawnPoint);
            //player.CreateCharacter(SpawnPoint, "GameAssets/movimiento1.png");
            Character player = GameManager.Instance.currentPlayer;
            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);
            badGuy = new Enemy("Mavado", "GameAssets/enemigo1.png", 50, 5, 2, 400, 300);
            //badGuy = new Enemy("Mavado", "GameAssets/enemigo1.png", 10, 5, 2, SpawnPointEnemy);
            timeManager = new TimeManager();

        }

        public override void Update()
        {
          
            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();
            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(badGuy.GetXPos(), badGuy.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.FightScene);
                }
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                 new Vector2(400, 600), new Vector2(50, 50))
                )
            {
                GameManager.Instance.ChangeLevel(LevelType.Level3);

            }
        }

        public override void Render()
        {
            Engine.Draw(background);
            Character player = playerController.GetPlayer();
            player.CharacterDraw();
            //Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
            Engine.Draw(badGuy.GetTexture(), badGuy.GetXPos(), badGuy.GetYPos());
            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(badGuy.GetXPos(), badGuy.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), badGuy.GetXPos(), badGuy.GetYPos() - 20);
            }
        }
    }
}
