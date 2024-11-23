namespace Game
{
    public interface IRender
    {
        string texture { get; set; }
        TransformData transform { get; set; }
        float scaleX { get; set; }
        float scaleY { get; set; }


        void Draw();
        void Draw(string text,float posX,float posY);
        void Draw(string text, float posX, float posY, float scaleX, float scaleY);

    }
}
