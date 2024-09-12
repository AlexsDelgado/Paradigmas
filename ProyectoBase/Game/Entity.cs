namespace Game
{
    public class Entity
    {
   

        public string name;
        public string texture;
        public float hp;
        public float str;
        public float spd;
        public float xPos;
        public float yPos;
        
        public Entity(string name,string texture, float hp, float str, float spd, float xPos, float yPos)
        {
            this.name = name;
            this.texture = texture;
            this.hp = hp;
            this.str = str;
            this.spd = spd;
            this.xPos = xPos;
            this.yPos = yPos;
        }
        
        
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

        public void Kill()
        {
            Engine.Debug(name+" no puede continuar el combate");
        }
    }

}