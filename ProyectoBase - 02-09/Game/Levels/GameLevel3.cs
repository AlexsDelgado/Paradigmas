using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel3 : Level
    {
        private PlayerController playerController;
        private TimeManager timeManager;
        private TransformData SpawnPoint;


        public GameLevel3(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(50, 50);
            Character player = GameManager.Instance.currentPlayer;
            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);
            timeManager = new TimeManager();
        }

        public override void Update()
        {

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();
        }

        public override void Render()
        {
            Engine.Draw(background);
            Character player = playerController.GetPlayer();
            player.CharacterDraw();
        }
    }
}
