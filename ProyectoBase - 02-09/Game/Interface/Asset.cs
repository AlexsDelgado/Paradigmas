
namespace Game
{
    class Asset : IRender
    {
        public string texture { get => texture; set => texture = value; }
        public TransformData transform { get => transform; set => transform = value; }
        public float scaleX { get => scaleX; set => scaleX = value; }
        public float scaleY { get => scaleY; set => scaleY = value; }


        public Asset(string _texture, TransformData _transform, float _scalex, float _scaley)
        {
            texture = _texture;
            transform = _transform;
            scaleX = _scalex;
            scaleY = _scaley;
        }

        public void Draw()
        {
            Engine.Draw(texture, transform.PositionX, transform.PositionY);
        }

       public void Draw(string text, float posX, float posY)
        {
            Engine.Draw(text, posX, posY);
        }

       public void Draw(string text, float posX, float posY, float scaleX, float scaleY)
        {
            Engine.Draw(text, posX, posY, scaleX, scaleY);
        }
    }
}
