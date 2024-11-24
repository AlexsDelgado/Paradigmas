using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class npc : Entity, IInteractable
    {
        public int _cost { get; set ; }

        public npc(string name, string texture, float hp, float str, float spd, float xPos, float yPos) : base(name,
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

        public npc(string _name, TransformData _transform)
        {
            name = _name;
            transform = new TransformData(_transform.PositionX,_transform.PositionY);
            renderer = new RendererComponent();
            
        }

        public void CharacterDraw()
        {
            renderer.Transform = transform;
            renderer.Texture = texture;
            renderer.Draw();
        }

        public void CreateCharacter(string _texture)
        {
            
            xPos = transform.PositionX;
            yPos = transform.PositionY;
            renderer.Texture = _texture;
            renderer.ScaleX = 1;
            renderer.ScaleY = 1;
            texture = renderer.Texture;
        }

        public void Interact()
        {
            Console.WriteLine("Selecciona tu compra");
        }
    }
}
