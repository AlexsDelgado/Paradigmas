namespace Game
{
    public class TransformData
    {
        private float positionX;
        private float positionY;
        private float scale;
        private float rotation;
        private Vector2 transform;

        
        public  float PositionX { get => positionX; set => positionX = value; }
        public float PositionY { get => positionY; set => positionY = value; }
        public float Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public TransformData(float x, float y)
        {
            positionX = x;
            positionY = y;
            transform = new Vector2(positionX, positionY);
        }
        public void SetPosition(float x, float y)
        {
            positionX = x;
            positionY = y;
            transform.X = positionX;
            transform.Y = positionY;
        }
   
    }
}
