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
        Sprite2D player;
        public DemoGame() : base(new Vector2(615, 515), "Space Invaders") { }

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            //player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "shape test");
            player = new Sprite2D(new Vector2(10, 10), new Vector2(10, 10), "Players/Player Green/playerGreen_swim2", "shape test");
        }

        public override void OnDraw()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}
