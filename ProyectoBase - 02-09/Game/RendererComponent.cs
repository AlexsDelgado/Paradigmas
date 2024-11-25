namespace Game
{
    public class RendererComponent
    {
        private string _texture;
        private TransformData _transform;
        private float _scaleBaseX =1;
        private float _scaleBaseY =1;

        public string Texture { get => _texture; set => _texture = value; }
        public TransformData Transform { get => _transform; set => _transform = value; }
        public float ScaleX { get => _scaleBaseX; set => _scaleBaseX = value; }
        public float ScaleY { get => _scaleBaseY; set => _scaleBaseY = value; }

        public void Draw()
        {
            
            Engine.Draw(_texture,_transform.PositionX,_transform.PositionY);
        }
    }
}
