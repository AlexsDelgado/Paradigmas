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


        public void Interact()
        {
            Console.WriteLine("Selecciona tu compra");
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

      
    }
}
