using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class TimeManager
    {
        private DateTime startTime;
        private float lastFrameTime;

        public TimeManager()
        {
            startTime = DateTime.Now;
            lastFrameTime = 0;
        }

        public float GetDeltaTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            float deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
            return deltaTime;
        }
    }

}
