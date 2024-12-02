﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossFight : Level
    {
        private Character player;
        private Enemy enemy;
        private Button attackButton;
        private Button fleeButton;
        private int selectedButtonIndex;
        private List<Button> buttons;
        private bool isPlayerTurn;
        private Animation enemyIdleAnimation;
        private bool firstTurn;


        private int currentTurn;
        private int lastTurn = 0;

        TransformData playerPosition;
        TransformData enemyPosition;
        TransformData iconPosition;
        TransformData iconPositionEnemy;
        TransformData hpBarPlayer;
        TransformData hpBarEnemy;


        public BossFight(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {


            player = GameManager.Instance.currentPlayer;
           

            playerPosition = new TransformData(100, 200);
            enemyPosition = new TransformData(300, 180);
            iconPosition = new TransformData(10, 70);
            iconPositionEnemy = new TransformData(588, 70);
            hpBarPlayer = new TransformData(10, 10);
            hpBarEnemy = new TransformData(430, 10);
            enemy = GameManager.Instance.currentEnemy;


            player.Movement(playerPosition.PositionX, playerPosition.PositionY);
            enemy.GetTransform().SetPosition(enemyPosition.PositionX, enemyPosition.PositionY);

            player.OnDeath += PlayerDefeat;
            enemy.OnDeath += EnemyDefeat;
            enemy.OnDamageReceived += DamageLog;
            player.OnDamageReceived += DamageLog;

            attackButton = new Button("Pelear", Engine.GetTexture("Textures/Buttons/Attack/AttackButton.png"), 0, 500);
            fleeButton = new Button("Escapar", Engine.GetTexture("Textures/Buttons/Flee/FleeButton1.png"), 400, 500);
            buttons = new List<Button> { attackButton, fleeButton };
            selectedButtonIndex = 0;
            isPlayerTurn = true;
            firstTurn = true;

        }




        public override void Update()
        {
            if (firstTurn)
            {
                float enemySpd = 0;
                float playerSpd = 0;
                playerSpd = player.GetSpd();
                enemySpd = enemy.GetSpd();
                Console.WriteLine(playerSpd);
                Console.WriteLine(enemySpd);
                if (playerSpd < enemySpd)
                {
                    isPlayerTurn = false;
                    Console.WriteLine("empezo enemigo");
                }
                firstTurn = false;

            }

            switch (currentTurn)
            {

                case 0:
                    HandlePlayerTurn();
                    break;
                case 1:

                    HandleEnemyTurn();
                    break;
                case 2:
                    if (Engine.GetKey(Keys.E))
                    {

                        HandleTurns();

                    }
                    break;
            }



        }

        public override void Render()
        {
            Engine.Draw(background);
            player.DrawCombat();
            enemy.EnemyDrawCombat();

            if (currentTurn == 0)
            {
                foreach (var button in buttons)
                {
                    button.Render();
                }
                Engine.Draw(Engine.GetTexture("Textures/Buttons/Play/SelectedButton.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos());
                Engine.Draw(Engine.GetTexture("GameAssets/Personajes/playerIcon.png"), iconPosition.PositionX, iconPosition.PositionY);
            }
            else
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Personajes/bossIcon.png"), 588, iconPositionEnemy.PositionY);

            }

            DrawHealthBar(player, hpBarPlayer.PositionX, hpBarPlayer.PositionY);
            DrawHealthBar(enemy, hpBarEnemy.PositionX, hpBarEnemy.PositionY);
        }
        private void HandleTurns()
        {
            if (Engine.GetKey(Keys.E))
            {
                if (lastTurn == 0)
                {
                    currentTurn = 1;

                }
                else
                {
                    currentTurn = 0;
                }
            }
        }
        private void HandlePlayerTurn()
        {
            if (Engine.GetKey(Keys.RIGHT)) selectedButtonIndex = Math.Min(selectedButtonIndex + 1, buttons.Count - 1);
            if (Engine.GetKey(Keys.LEFT)) selectedButtonIndex = Math.Max(selectedButtonIndex - 1, 0);
            if (Engine.GetKey(Keys.SPACE))
            {
                if (selectedButtonIndex == 0)
                {
                    float damage = player.GetStr();
                    enemy.GetDamage(damage);
                    currentTurn = 2;
                    lastTurn = 0;
                    isPlayerTurn = false;

                }
                else if (selectedButtonIndex == 1)
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }
            }
            else
            {
                isPlayerTurn = false;
            }

        }
        private void HandleEnemyTurn()
        {
            GameManager.Instance.currentPlayer.GetDamage(enemy.GetStr(), GameManager.Instance.playerArmor);
            Console.WriteLine($"armor class { GameManager.Instance.playerArmor}");
            Console.WriteLine($"dmg { enemy.GetStr()}");
            currentTurn = 2;
            lastTurn = 1;

        }

        private void PlayerDefeat()
        {
            GameManager.Instance.ScoreUpdate();
            GameManager.Instance.ChangeLevel(LevelType.LoseScene);
        }

        private void EnemyDefeat()
        {
            //GameManager.Instance.ScoreUpdate();
            GameManager.Instance.ScoreUpdate(8);
            GameManager.Instance.ChangeLevel(LevelType.WinScene);
        }

        private void DamageLog(float damage, string name)
        {

            Engine.Debug($"{name} recibió {damage} de daño.");
        }

        private void DrawHealthBar(Entity entity, float xPos, float yPos)
        {
            float maxHealth = 100;
            float currentHealth = entity.GetHp();
            float healthPercentage = currentHealth / maxHealth;

            float healthBarWidth = 100;
            float healthBarHeight = 20;

            Engine.Draw(Engine.GetTexture("GameAssets/Assets/barra1.png"), xPos, yPos, healthBarWidth / 200, healthBarHeight / 20);
            Engine.Draw(Engine.GetTexture("GameAssets/Assets/barra2.png"), xPos, yPos, (healthBarWidth * healthPercentage) / 200, healthBarHeight / 20);
        }
    }
}
