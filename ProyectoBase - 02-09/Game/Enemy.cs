namespace Game
{
    public class Enemy : Entity
    {

        public Enemy(string _name, string _texture, string _combatTexture , float _hp, float _str, float _spd, TransformData _transform) : base(_name,
             _texture, _hp, _str, _spd, _transform)
        {
            base.name = name;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.transform = new TransformData(_transform.PositionX, _transform.PositionY);
            base.renderer = new RendererComponent();
            combatTexture = _combatTexture;


        }

        public void CreateEnemy(TransformData _transform, string _texture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionY = _transform.PositionY;
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

        public void EnemyDrawCombat()
        {
            renderer.Transform = transform;
            renderer.Texture = combatTexture;
            renderer.Draw();

        }

    }
}