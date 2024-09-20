namespace Game
{
    public class Character : Entity
    {
        public Character(string name, string texture, float hp, float str, float spd, float xPos, float yPos) : base(name, texture, hp, str, spd, xPos, yPos)
        {
            base.name = name;
            base.texture = texture;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.xPos = xPos;
            base.yPos = yPos;
        }

        public void Movement(float newXPos, float newYPos)
        {
            xPos = newXPos;
            yPos = newYPos;
        }

        private void PlayerDefeat()
        {
                GameManager.Instance.ChangeLevel(LevelType.LoseScene);
        }

    }
}