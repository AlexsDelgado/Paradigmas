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

        public Character(string name, float hp, float str, float spd, TransformData transform) : base(name, hp, str, spd, transform)
        {
            base.name = name;
            base.hp = hp;
            base.str = str;
            base.spd = spd;
            base.transform = transform;

        }
        public void CreateCharacter(TransformData _transform,string _texture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionX = _transform.PositionY;
            renderer.Texture = _texture;
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