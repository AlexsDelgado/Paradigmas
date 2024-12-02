using System;

namespace Game
{
    public class Coin : Asset, IInteractable
    {
        public int _cost { get; set; }

        public Coin() : base()
        {
            
        }

        public Coin(string _texture, TransformData _transform, float _scalex, float _scaley)
            : base(_texture, _transform, _scalex, _scaley)
        {
            Initialize(_texture, _transform, _scalex, _scaley);
        }

        public void Initialize(string _texture, TransformData _transform, float _scalex, float _scaley)
        {
            texture = _texture;
            renderer = new RendererComponent();
            renderer.Texture = texture;
            renderer.ScaleX = _scalex;
            renderer.ScaleY = _scaley;
            transform = new TransformData(_transform.PositionX, _transform.PositionY);
        }

        public void Interact()
        {
            GameManager.Instance.coins += _cost;
            Console.WriteLine("MONEDAS SUMADAS: ", _cost);
            Console.WriteLine(GameManager.Instance.coins);
            GameManager.Instance.coinPool.ReturnObject(this);
        //    Coin nextCoin = GameManager.Instance.coinPool.GetObject(); 
          
        //    Random random = new Random();
        //    int randomX = random.Next(0, 750);
        //    int randomY = random.Next(0, 535);
        //    nextCoin.transform.PositionX = randomX;
        //    nextCoin.transform.PositionY = randomY;
        }

        public void SetCost(int cost)
        {
            _cost = cost;
        }

        public void Reset()
        {
            transform.PositionX = 1000;
            transform.PositionY = 1000;
        }

        
    }
}













