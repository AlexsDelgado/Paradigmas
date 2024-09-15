namespace Game
{
    public class Enemy : Entity
    {
        public Enemy(string name, string texture, float hp, float str, float spd, float xPos, float yPos) : base(name,
            texture, hp, str, spd, xPos, yPos)
        {
            base.name = name;
            base.texture = texture;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.xPos = xPos;
            base.yPos = yPos;
        }

        public void Movement(int x, int y)
        {
            xPos += x;
            yPos += y;
        }

        public void Movement(int x)
        {
            xPos += x;
        }
}
}