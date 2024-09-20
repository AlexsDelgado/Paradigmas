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
        public MenuLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
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