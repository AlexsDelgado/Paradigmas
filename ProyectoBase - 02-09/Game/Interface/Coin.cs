using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    class Coin : Asset, IInteractable
    {
        public int _cost {get;set;}


        public Coin(string _texture, TransformData _transform, float _scalex, float _scaley) : base(_texture, _transform, _scalex, _scaley)
        {
            texture = _texture;
            renderer = new RendererComponent();
            renderer.ScaleX= _scalex;
            renderer.ScaleY = _scaley;
            transform = new TransformData(_transform.PositionX, _transform.PositionY);
            
        }

        

        public void Interact()
        {
            GameManager.Instance.coins+=_cost;
            transform.PositionX = 1000;
            transform.PositionX = 1000;
            Console.WriteLine(GameManager.Instance.coins);
        }
        public void SetCost(int cost)
        {
            _cost = cost;
        }
    }
}
