using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        private string text;
        private Texture texture;
        private float xPos;
        private float yPos;

        public Button(string text, Texture texture, float xPos, float yPos)
        {
            this.text = text;
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Render()
        {
            Engine.Draw(texture, xPos, yPos);
            //Engine.Debug(text);
        }

        public float GetXPos() => xPos;
        public float GetYPos() => yPos;
    }
}
