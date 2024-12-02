namespace Game
{
    public interface IRender
    {
  

        void Draw();
        void Draw(string text,float posX,float posY);
        void Draw(string text, float posX, float posY, float scaleX, float scaleY);
        void Draw(float scalex, float scaley);

    }
}
