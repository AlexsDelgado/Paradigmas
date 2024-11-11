namespace Game
{
    public class Enemy : Entity
    {
        //public Enemy(string name, string texture, float hp, float str, float spd, float xPos, float yPos) : base(name,
        //    texture, hp, str, spd, xPos, yPos)
        //{
        //    base._name = name;
        //    base.texture = texture;
        //    base._hp = hp;
        //    base._str = str;
        //    base._spd = spd;
        //    base._xPos = xPos;
        //    base._yPos = yPos;
        //}
        public Enemy(string _name, string _texture, float _hp, float _str, float _spd, TransformData _transform) : base(_name,_hp, _str, _spd, _transform,_texture)
        {
            //base.name = name;
            //base.texture = texture;
            //base.hp = hp;
            //base.str = str;
            //base.spd = spd;
            //base.transform = _transform;
            base._name = _name;
            base._hp = _hp;
            base._str = _str;
            base._spd = _spd;
            base.transform = transform;


        }
        public void Movement(int x, int y)
        {
            _xPos += x;
            _yPos += y;
        }

        public void Movement(int x)
        {
            _xPos += x;
        }
    }
}