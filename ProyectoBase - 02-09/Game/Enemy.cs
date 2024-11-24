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
            base.name = name;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.transform = new TransformData(_transform.PositionX, _transform.PositionY);
            base.renderer = new RendererComponent();


        }

        public void CreateEnemy(TransformData _transform, string _texture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionX = _transform.PositionY;
            xPos = transform.PositionX;
            yPos = transform.PositionY;
            renderer.Texture = _texture;
            renderer.ScaleX = 1;
            renderer.ScaleY = 1;
            texture = renderer.Texture;
        }
        public void EnemyDraw()
        {
            renderer.Transform = transform;
            renderer.Texture = texture;
            renderer.Draw();
        }


        //  base.transform = new TransformData(transform.PositionX,transform.PositionY);
        //base.renderer = new RendererComponent();
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