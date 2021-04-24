using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.ExpressedEngine;

namespace SpaceInvaders
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        public DemoGame() : base(new Vector2(615, 515), "Space Invaders") { }
    }
}
