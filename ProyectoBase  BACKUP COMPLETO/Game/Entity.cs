namespace Game
{
    public class Entity
    {
        protected string name;
        protected string texture;
        protected float hp;
        protected float str;
        protected float spd;
        protected float xPos;
        protected float yPos;
        protected TransformData transform;
        protected RendererComponent renderer;
        
        //constructor
        protected Entity(string name,string texture, float hp, float str, float spd, float xPos, float yPos)
        {
            this.name = name;
            this.texture = texture;
            this.hp = hp;
            this.str = str;
            this.spd = spd;
            this.xPos = xPos;
            this.yPos = yPos;
        }
        protected Entity(string _name, float _hp, float _str, float _spd, TransformData _transform)
        {
            this.name = _name;
            this.hp = _hp;
            this.str = _str;
            this.spd = _spd;
            this.transform = _transform;
        }

        public Entity(string name, string texture, float hp, float str, float spd, TransformData transform)
        {
            this.name = name;
            this.texture = texture;
            this.hp = hp;
            this.str = str;
            this.spd = spd;
            this.transform = transform;
        }

        //getters and setter
        public string GetName()
        {
            return name;
        }
        public string GetTexture()
        {
            return texture;
        }
        public void SetTexture(string newTexture)
        {
            texture = newTexture;
        }
        public float GetHp()
        {
            return hp;
        }
        public void SetHp(float newHp)
        {
            hp = newHp;
        }
        public float GetStr()
        {
            return str;
        } 
        public void SetStr(float newStr)
        {
            str = newStr;
        }
        public float GetSpd()
        {
            return spd;
        }
        public void SetSpd(float newSpd)
        {
            spd = newSpd;
        }

        public float GetXPos()
        {
            return xPos;
        }

        public void SetXPos(float newXPos)
        {
            xPos = newXPos;
        }
        public float GetYPos()
        {
            return yPos;
        }
        public void SetYPos(float newYPos)
        {
            yPos = newYPos;
        }
        
        //recibir daño
        public void GetDamage(float dmg)
        {
            hp = hp - dmg;
            Engine.Debug("Recibio "+dmg+" de daño");
            if (hp<=0)
            {
                Kill();
            }
            else
            {
                Engine.Debug("A "+name+" le queda "+hp+" de vida restante");    
            }
        }

        //matar entidad
      
        private void Kill()
        {
            Engine.Debug(name + " no puede continuar el combate");
        }
    }

}