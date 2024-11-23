using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyController
    {
        private Enemy enemy;

        public EnemyController(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public Enemy GetEnemy()
        {
            return enemy;
        }
    }
}
