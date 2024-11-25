using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class FightScene : Level
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

        public FightScene(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 2, 10, 400);
            enemy = new Enemy("Mavado", "GameAssets/enemigo1.png", 30,5, 100, 400, 100);
            //enemy = new Enemy("Mavado", "GameAssets/enemigo1.png", 2, 8, 2, 400, 100);

            player.OnDeath += PlayerDefeat;
            enemy.OnDeath += EnemyDefeat;
            enemy.OnDamageReceived += DamageLog;
            attackButton = new Button("Pelear", Engine.GetTexture("Textures/Buttons/Attack/AttackButton.png"), 0, 500);
            fleeButton = new Button("Escapar", Engine.GetTexture("Textures/Buttons/Flee/FleeButton1.png"), 400, 500);
            buttons = new List<Button> { attackButton, fleeButton };
            selectedButtonIndex = 0;
            isPlayerTurn = true;
            firstTurn = true;
            

            List<Texture> enemyIdleFrames = new List<Texture>
        {
            Engine.GetTexture("GameAssets/Animation/frame1.png"),
            Engine.GetTexture("GameAssets/Animation/frame2.png"),
            Engine.GetTexture("GameAssets/Animation/frame3.png"),
            Engine.GetTexture("GameAssets/Animation/frame4.png"),
            Engine.GetTexture("GameAssets/Animation/frame5.png"),
            Engine.GetTexture("GameAssets/Animation/frame6.png"),
            Engine.GetTexture("GameAssets/Animation/frame7.png"),
            Engine.GetTexture("GameAssets/Animation/frame8.png")
        };
            enemyIdleAnimation = new Animation("EnemyIdle", enemyIdleFrames, 1f, true);
        }

        
        

        public override void Update()
        {
            if (firstTurn)
            {
                float enemySpd =0;
                float playerSpd=0;
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
            
            if (isPlayerTurn)
            {
                HandlePlayerTurn();
                //Console.WriteLine(GameManager.Instance.playerArmor);
            }
            else
            {
                HandleEnemyTurn();
            }


            enemyIdleAnimation.Update();
        }

        public override void Render()
        {
            Engine.Draw(background);
            Engine.Draw(enemyIdleAnimation.CurrentFrame, enemy.GetXPos(), enemy.GetYPos());

            foreach (var button in buttons)
            {
                button.Render();
            }

            Engine.Draw(Engine.GetTexture("Textures/Buttons/Play/SelectedButton.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos());
            DrawHealthBar(player, 10, 10);
            DrawHealthBar(enemy, enemy.GetXPos() - 50, enemy.GetYPos() - 30);
        }

        private void HandlePlayerTurn()
        {
            if (Engine.GetKey(Keys.RIGHT)) selectedButtonIndex = Math.Min(selectedButtonIndex + 1, buttons.Count - 1);
            if (Engine.GetKey(Keys.LEFT)) selectedButtonIndex = Math.Max(selectedButtonIndex - 1, 0);
            if (Engine.GetKey(Keys.DOWN))
            {
                GameManager.Instance.playerArmor += 1;
            }

            if (Engine.GetKey(Keys.SPACE))
            {
                if (selectedButtonIndex == 0)
                {
                    float damage = player.GetStr();
                    enemy.GetDamage(damage);
                    isPlayerTurn = false;
                }
                else if (selectedButtonIndex == 1)
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }
            }
        }

        private void HandleEnemyTurn()
        {
            player.GetDamage(enemy.GetStr(),GameManager.Instance.playerArmor);
            Console.WriteLine(GameManager.Instance.playerArmor);
            isPlayerTurn = true;
        }

        private void PlayerDefeat()
        {
            GameManager.Instance.ChangeLevel(LevelType.LoseScene);
        }

        private void EnemyDefeat()
        {
            GameManager.Instance.ChangeLevel(LevelType.Level2);
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
