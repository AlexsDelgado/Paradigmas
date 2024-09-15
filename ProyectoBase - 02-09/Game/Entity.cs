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
                Engine.Debug("A "+name+"le queda "+hp+" restante");    
            }
        }

        //matar entidad
        private void Kill()
        {
            Engine.Debug(name+" no puede continuar el combate");
        }
    }

}