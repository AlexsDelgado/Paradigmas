namespace Game
{
    public class Entity : IRender
    {
        protected string _name;
        //protected string _texture;
        protected float _hp;
        protected float _str;
        protected float _spd;
        protected float _xPos;
        protected float _yPos;
        protected TransformData _transform;
        protected IRender renderComp;

        public string texture { get => texture; set => texture = value; }
        public TransformData transform { get => transform; set => transform = value; }
        public float scaleX { get => scaleX; set => scaleX = value; }
        public float scaleY { get => scaleY; set => scaleY = value; }



        ////constructor
        //protected Entity(string name,string texture, float hp, float str, float spd, float xPos, float yPos)
        //{
        //    this.name = name;
        //    this.texture = texture;
        //    this.hp = hp;
        //    this.str = str;
        //    this.spd = spd;
        //    this.xPos = xPos;
        //    this.yPos = yPos;
        //}
        protected Entity(string _name, float _hp, float _str, float _spd, TransformData _transform, string _texture)
        {
            this._name = _name;
            this._hp = _hp;
            this._str = _str;
            this._spd = _spd;
            this._transform = _transform;
            this.renderComp.texture = _texture;

        }
        public Entity(TransformData transform, string textura)
        {
            _transform = transform;
            texture = textura;
        }

        //public Entity(string name, string texture, float hp, float str, float spd, TransformData transform)
        //{
        //    this.name = name;
        //    this.texture = texture;
        //    this.hp = hp;
        //    this.str = str;
        //    this.spd = spd;
        //    this.transform = transform;
        //}

        //getters and setter
        public string GetName()
        {
            return _name;
        }
        public string GetTexture()
        {
            return texture;
            //return renderComp.texture;
            //return _texture;
        }
        public void SetTexture(string newTexture)
        {
            renderComp.texture = newTexture;
            //_texture = newTexture;
        }
        public float GetHp()
        {
            return _hp;
        }
        public void SetHp(float newHp)
        {
            _hp = newHp;
        }
        public float GetStr()
        {
            return _str;
        } 
        public void SetStr(float newStr)
        {
            _str = newStr;
        }
        public float GetSpd()
        {
            return _spd;
        }
        public void SetSpd(float newSpd)
        {
            _spd = newSpd;
        }

        public float GetXPos()
        {
            return _transform.PositionX;
            //return _xPos;
        }

        public void SetXPos(float newXPos)
        {
            _transform.PositionX = newXPos;
            //xPos = newXPos;
        }
        public float GetYPos()
        {
            return _transform.PositionY;
            //return _yPos;
        }
        public void SetYPos(float newYPos)
        {
            _transform.PositionY= newYPos;
            //_yPos = newYPos;
        }
        
        //recibir daño
        public void GetDamage(float dmg)
        {
            _hp = _hp - dmg;
            Engine.Debug("Recibio "+dmg+" de daño");
            if (_hp<=0)
            {
                Kill();
            }
            else
            {
                Engine.Debug("A "+_name+" le queda "+_hp+" de vida restante");    
            }
        }

        //matar entidad
      
        private void Kill()
        {
            Engine.Debug(_name + " no puede continuar el combate");
        }

        //void Draw()
        //{
        //    Engine.Draw(renderComp.texture, _transform.PositionX, _transform.PositionY);
        //}
        //void Draw(string text, float posX, float posY)
        //{
        //    Engine.Draw(text,posX,posY);
        //}
        //void Draw(string text, float posX, float posY, float scaleX, float scaleY)
        //{
        //    Engine.Draw(text, posX, posY, scaleX, scaleY);
        //}

        void IRender.Draw()
        {
            Engine.Draw(renderComp.texture, _transform.PositionX, _transform.PositionY);
        }

        void IRender.Draw(string text, float posX, float posY)
        {
            Engine.Draw(text,posX,posY);
        }

        void IRender.Draw(string text, float posX, float posY, float scaleX, float scaleY)
        {
            Engine.Draw(text, posX, posY, scaleX, scaleY);
        }
    }

}