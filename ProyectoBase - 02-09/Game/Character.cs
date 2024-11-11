namespace Game
{
    public class Character : Entity
    {
        //public Character(string name, string texture, float hp, float str, float spd, float xPos, float yPos) : base(name, texture, hp, str, spd, xPos, yPos)
        //{
        //    base.name = name;
        //    base.texture = texture;
        //    base.hp = hp;
        //    base.str = str;
        //    base.spd = spd;
        //    base.xPos = xPos;
        //    base.yPos = yPos;
        //}

        public Character(string name, float hp, float str, float spd, TransformData transform, string texture) : base(name, hp, str, spd, transform, texture)
        {
            base._name = name;
            base._hp = hp;
            base._str = str;
            base._spd = spd;
            base.transform = transform;
            base.renderComp.texture = texture;

        }
        public void CreateCharacter(TransformData _transform,string _texture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionX = _transform.PositionY;
            renderComp.texture = _texture;
        }

        public void Movement(float newXPos, float newYPos)
        {
            _xPos = newXPos;
            _yPos = newYPos;
            transform.SetPosition(_xPos, _yPos);

        }

        private void PlayerDefeat()
        {
                GameManager.Instance.ChangeLevel(LevelType.LoseScene);
        }
        
        public void CharacterDraw()
        {
            renderComp.transform = transform;
            renderComp.texture = texture;
            renderComp.Draw(renderComp.texture,transform.PositionX,transform.PositionY);
        }

    }
}