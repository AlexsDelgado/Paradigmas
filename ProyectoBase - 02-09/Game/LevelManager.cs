using System;
using System.Collections.Generic;

namespace Game
{
    public class LevelManager
    {
        private PlayerController playerController;
        private NPCController npcController;
        private EnemyController enemyController;

        public LevelManager(PlayerController playerController, NPCController npcController, EnemyController enemyController)
        {
            this.playerController = playerController;
            this.npcController = npcController;
            this.enemyController = enemyController;
        }

        public void UpdateLevelCollisions()
        {
            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(playerController.GetPlayer().GetXPos(), playerController.GetPlayer().GetYPos()),
                new Vector2(20, 20),
                new Vector2(npcController.GetNPC().GetXPos(), npcController.GetNPC().GetYPos()),
                new Vector2(50, 50)))
            {
                Engine.Debug("Cerca de John. Presiona E para interactuar.");
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(playerController.GetPlayer().GetXPos(), playerController.GetPlayer().GetYPos()),
                new Vector2(20, 20),
                new Vector2(enemyController.GetEnemy().GetXPos(), enemyController.GetEnemy().GetYPos()),
                new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.FightScene);
                }
            }
        }
    }
}