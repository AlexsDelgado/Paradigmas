namespace Game
{
    public class Character : Entity
    {
        
        public Character(string name, float hp, float str, float spd, TransformData transform) : base(name, hp, str, spd, transform)
        {
            base.name = name;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.transform = new TransformData(transform.PositionX,transform.PositionY);
            base.renderer = new RendererComponent();

        }
        public void CreateCharacter(TransformData _transform, string _texture, string _combatTexture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionY = _transform.PositionY;
            xPos = transform.PositionX;
            yPos = transform.PositionY;
            renderer.Texture = _texture;
            renderer.ScaleX = 1;
            renderer.ScaleY = 1;
            texture = renderer.Texture;
            combatTexture = _combatTexture;
        }

        public void Movement(float newXPos, float newYPos)
        {
            xPos = newXPos;
            yPos = newYPos;
            transform.SetPosition(xPos, yPos);

        }

        private void PlayerDefeat()
        {
                GameManager.Instance.ChangeLevel(LevelType.LoseScene);
        }
        
        public void CharacterDraw()
        {
            renderer.Transform = transform;
            renderer.Texture = texture;
            renderer.Draw();
        }
    }
}