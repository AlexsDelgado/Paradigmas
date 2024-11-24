using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Asset : IRender
    {
        protected string texture;
        protected TransformData transform;
        protected RendererComponent renderer;
        protected float scaleX;
        protected float scaleY;


        public Asset(string _texture, TransformData _transform, float _scalex, float _scaley)
        {
            transform = new TransformData(_transform.PositionX, _transform.PositionY);
            renderer = new RendererComponent();
            scaleX = _scalex;
            scaleY = _scaley;
            renderer.ScaleX = _scalex;
            renderer.ScaleY = _scaley;

        }
        public Asset()
        {
           

           transform = new TransformData(0,0);
           renderer = new RendererComponent();
            renderer.ScaleX = 1;
            renderer.ScaleY = 1;

        }
        public void CreateAsset(TransformData _transform, string _texture)
        {
            transform.PositionX = _transform.PositionX;
            transform.PositionY = _transform.PositionY;
            texture = _texture;
       
        }

        public TransformData GetTransform()
        {
            return transform;
        }


        public void Draw()
        {
            renderer.Transform = transform;
            renderer.Texture = texture;
            renderer.Draw();

        }
  


        public void Draw(string text, float posX, float posY)
        {
            Engine.Draw(text, posX, posY);
        }

       public void Draw(string text, float posX, float posY, float scaleX, float scaleY)
        {
            Engine.Draw(text, posX, posY, scaleX, scaleY);
        }

        public void Draw(float scaleX, float scaleY)
        {
            
            Engine.Draw(texture, transform.PositionX, transform.PositionY, scaleX, scaleY);
        }

    }
}
