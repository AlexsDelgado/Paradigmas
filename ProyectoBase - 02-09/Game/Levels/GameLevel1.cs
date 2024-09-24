using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel1 : Level
    {
        private PlayerController playerController;
        private npc john;
        private Items cartel;
        private TimeManager timeManager;

        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            playerController = new PlayerController(player);
            john = new npc("John", "GameAssets/movimiento1.png", 50, 1, 1, 400, 200);
            cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);
            timeManager = new TimeManager();
        }

        public override void Update()
        {
            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(john.GetXPos(), john.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    Engine.Debug("Ir al cartel");
                }
            }
        }

        public override void Render()
        {
            Engine.Draw(background);
            Character player = playerController.GetPlayer();
            Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
            Engine.Draw(john.GetTexture(), john.GetXPos(), john.GetYPos());
            Engine.Draw(cartel.GetTexture(), cartel.GetXPos(), cartel.GetYPos());

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(john.GetXPos(), john.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), john.GetXPos(), john.GetYPos() - 20);
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartel.GetXPos(), cartel.GetYPos() - 20);
            }
        }
    }
}
