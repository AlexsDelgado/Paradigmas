using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class npc  : Entity
    {
        public npc(string name, float hp, float str, float spd, TransformData transform , string texture) : base(name, hp, str, spd, transform, texture)
        {
            base._name = name;
            base._hp = hp;
            base._str = str;
            base._spd = spd;
            base.texture = texture;
        }


    }
}
