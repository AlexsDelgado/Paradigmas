using System;
using System.Collections.Generic;

namespace Game
{
    public class LevelManager
    {
        
    }
    
    public enum LevelType 
    {
        Menu,
        Level1,
        Level2,
        FightScene,
        WinScene,
        LoseScene
    }

    public abstract class Level 
    {
        protected Texture background;
        protected LevelType levelType;

        public LevelType LevelType => levelType;


        public Level(Texture background, LevelType levelType)
        {
            this.background = background;
            this.levelType = levelType;  
        }

        public abstract void Update();
        public abstract void Render();
    }

    public class MenuLevel : Level 
    {
        private Button playButton;
        private Button exitButton;
        private int selectedButtonIndex;
        private List<Button> buttons;

        public MenuLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            playButton = new Button("Jugar", Engine.GetTexture("Textures/Buttons/Play/PlayButton1.png"), 0, 200);
            exitButton = new Button("Salir", Engine.GetTexture("Textures/Buttons/Quit/QuitButton1.png"), 300, 400);
            buttons = new List<Button> { playButton, exitButton };
            selectedButtonIndex = 0;
        }

        public override void Render()
        {
            Engine.Draw(background);

            foreach (var button in buttons)
            {
                button.Render();
            }

          
            Engine.Draw(Engine.GetTexture("GameAssets/ship.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos() -50);
        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.RIGHT))
            {
                //selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Count;
                selectedButtonIndex++;
                if (selectedButtonIndex > 1)
                {
                    selectedButtonIndex = 1;
                }
            }
            else if (Engine.GetKey(Keys.LEFT))
            {
                //selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Count) % buttons.Count;
                selectedButtonIndex--;
                if (selectedButtonIndex < 0)
                {
                    selectedButtonIndex = 0;
                }
            }

      
            if (Engine.GetKey(Keys.SPACE))
            {
                if (selectedButtonIndex == 0)
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level1);
                }
                else if (selectedButtonIndex == 1)
                {

                    Engine.Clear();
                }
            }
        }
    }
    public class GameLevel1 : Level 
    {
        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

        }

        public override void Render()
        {
            Engine.Draw(background);
        }

        public override void Update()
        {
        }
    }
    public class GameLevel2 : Level 
    {
        public GameLevel2(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

        }

        public override void Render()
        {
            Engine.Draw(background);

        }

        public override void Update()
        {

        }
    }


    public class FightScene : Level
    {
        private Character player;
        private Enemy enemy;
        private Button attackButton;
        private Button fleeButton;
        private int selectedButtonIndex;
        private List<Button> buttons;
        private bool isPlayerTurn;

        public FightScene(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 2, 100, 400);
            enemy = new Enemy("Mavado", "GameAssets/enemigo1.png", 100, 8, 2, 400, 100);
            attackButton = new Button("Pelear", Engine.GetTexture("Textures/Buttons/Play/PlayButton1.png"), 100, 500);
            fleeButton = new Button("Escapar", Engine.GetTexture("Textures/Buttons/Quit/QuitButton1.png"), 300, 500);
            buttons = new List<Button> { attackButton, fleeButton };
            selectedButtonIndex = 0;
            isPlayerTurn = true;

        }

        public override void Render()
        {
            Engine.Draw(background);

            //Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
            //Engine.Draw(enemy.GetTexture(), enemy.GetXPos(), enemy.GetYPos());

            DrawHealthBar(player, 10, 10); 
            DrawHealthBar(enemy, enemy.GetXPos()-50, enemy.GetYPos()); 
            foreach (var button in buttons)
            {
                button.Render();
            }
            Engine.Draw(Engine.GetTexture("GameAssets/ship.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos() - 50);
        }

        public override void Update()
        {
            if (isPlayerTurn)
            {
                HandlePlayerTurn();
            }
            else
            {
                HandleEnemyTurn(); 
            }
        }

        private void HandlePlayerTurn()
        {
            if (Engine.GetKey(Keys.RIGHT))
            {
                selectedButtonIndex = Math.Min(selectedButtonIndex + 1, buttons.Count - 1);
            }
            else if (Engine.GetKey(Keys.LEFT))
            {
                selectedButtonIndex = Math.Max(selectedButtonIndex - 1, 0);
            }
            if (Engine.GetKey(Keys.SPACE))
            {
                if (selectedButtonIndex == 0) 
                {
                    float damage = player.GetStr();
                    enemy.GetDamage(damage);
                    if (enemy.GetHp() <= 0)
                    {
                        GameManager.Instance.ChangeLevel(LevelType.WinScene);
                    }
                    else
                    {
                        isPlayerTurn = false; 
                    }
                }
                else if (selectedButtonIndex == 1)
                {
                    GameManager.Instance.ChangeLevel(LevelType.LoseScene);
                }
            }
        }

        private void HandleEnemyTurn()
        {
            float damage = enemy.GetStr();
            player.GetDamage(damage);
            if (player.GetHp() <= 0)
            {
                GameManager.Instance.ChangeLevel(LevelType.LoseScene);
            }
            else
            {
                isPlayerTurn = true;
            }
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


    public class LoseLevel : Level
    {
        public LoseLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

        }

        public override void Render()
        {
            Engine.Draw(background);

        }

        public override void Update()
        {

        }
    }

    public class WinLevel : Level
    {
        public WinLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

        }

        public override void Render()
        {
            Engine.Draw(background);

        }

        public override void Update()
        {

        }
    }
}