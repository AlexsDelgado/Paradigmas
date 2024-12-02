using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NPCController
    {
        private npc john;

        public NPCController(npc john)
        {
            this.john = john;
        }

        public npc GetNPC()
        {
            return john;
        }
    }

}
