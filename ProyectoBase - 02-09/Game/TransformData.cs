namespace Game
{
    public class TransformData
    {
        private float positionX;
        private float positionY;
        private float scale;
        private float rotation;

        
        public  float PositionX { get => positionX; set => positionX = value; }
        public float PositionY { get => positionY; set => positionY = value; }
        public float Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public void SetPosition(float x, float y)
        {
            positionX = x;
            positionY = y;
        }
   
    }
}
