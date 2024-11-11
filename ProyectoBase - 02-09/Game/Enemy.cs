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
        public Enemy(string _name, string _texture, float _hp, float _str, float _spd, TransformData _transform) : base(_name,
             _texture, _hp, _str, _spd, _transform)
        {
            //base.name = name;
            //base.texture = texture;
            //base.hp = hp;
            //base.str = str;
            //base.spd = spd;
            //base.transform = _transform;
            base.name = name;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.transform = transform;


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