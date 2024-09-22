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
        private Character player;
        private Enemy enemigo1;
        private Enemy enemigo2;
        private List<Entity> entities;

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
        public FightScene(Texture background, LevelType p_levelType) : base(background, p_levelType)
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