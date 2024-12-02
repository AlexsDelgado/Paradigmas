using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LoseLevel : Level
    {
        public LoseLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

        }

        public override void Render()
        {
            Engine.Draw(background);

        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeLevel(LevelType.Menu);

            }
        }
    }
}
