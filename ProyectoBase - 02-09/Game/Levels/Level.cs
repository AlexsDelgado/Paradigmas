
namespace Game
{
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
}
