using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class UIManager
    {
        private Texture healthBarBackground;
        private Texture healthBarFill;

        public UIManager(Texture background, Texture fill)
        {
            this.healthBarBackground = background;
            this.healthBarFill = fill;
        }

        public void DrawHealthBar(Character player)
        {
            float maxHealth = 10;
            float currentHealth = player.GetHp();
            float healthPercentage = currentHealth / maxHealth;

            float healthBarX = 10;
            float healthBarY = 10;
            float healthBarWidth = 200;
            float healthBarHeight = 20;

            Engine.Draw(healthBarBackground, healthBarX, healthBarY, healthBarWidth / healthBarBackground.Width, healthBarHeight / healthBarBackground.Height);
            Engine.Draw(healthBarFill, healthBarX, healthBarY, (healthBarWidth * healthPercentage) / healthBarFill.Width, healthBarHeight / healthBarFill.Height);
        }
    }

}
