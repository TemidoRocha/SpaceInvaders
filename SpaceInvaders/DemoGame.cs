using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.ExpressedEngine;

namespace SpaceInvaders
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        Shape2D player;
        public DemoGame() : base(new Vector2(615, 515), "Space Invaders") { }

        public override void OnDraw()
        {
            BackgroundColor = Color.Black;
        }

        public override void OnLoad()
        {
            player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "shape test");
        }

        int time = 0;
        public override void OnUpdate()
        {
            if (time > 400)
            {
                if(player != null)
                {
                    player.DestroySelf();
                    player = null;
                }
            }
            time++;
        }
    }
}
