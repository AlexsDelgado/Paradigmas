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
        private Asset guideNPC;
        private Items cartel;
        private Asset cartelOk;
        private TransformData spawnCartel;
        private TransformData spawnNPC;
        private TransformData spawnPoint;
        private TimeManager timeManager;

        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            spawnPoint = new TransformData();
            spawnCartel = new TransformData();

            spawnPoint.SetPosition(50, 50);
            spawnCartel.SetPosition(200, 150);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            Character player = new Character("Hero", 100, 10, 5, spawnPoint,"GameAssets/movimiento1.png");
            //player.CreateCharacter(spawnPoint, "GameAssets/Movimiento1.png");
            playerController = new PlayerController(player);
            //john = new npc("John", "GameAssets/movimiento1.png", 50, 1, 1, 400, 200);
            john = new npc("Jhony",50,10,5,spawnNPC, "GameAssets/movimiento1.png");
            guideNPC = new Asset("GameAssets/movimiento1.png", spawnNPC, 1.5f, 1.5f);
            //cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);
            cartelOk = new Asset("GameAssets/Assets/cartel.png",spawnCartel,2,2);
            timeManager = new TimeManager();
        }

        public override void Update()
        {
            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartelOk.transform.PositionX, cartelOk.transform.PositionY), new Vector2(50, 50)))
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
            player.CharacterDraw();
            //Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
            
            Engine.Draw(john.GetTexture(), john.GetXPos(), john.GetYPos());
            //Engine.Draw(cartelOk.texture, cartelOK., cartel.GetYPos());
            cartelOk.Draw();

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(john.GetXPos(), john.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), john.GetXPos(), john.GetYPos() - 20);
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartelOk.transform.PositionX, cartelOk.transform.PositionY), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartelOk.transform.PositionX, cartelOk.transform.PositionY - 20);
            }
        }
    }
}
