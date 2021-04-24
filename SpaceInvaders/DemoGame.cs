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
            Console.WriteLine("onload works");
            player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "shape test");
        }

        int frame = 0;
        float x = 0.1f;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame}");
            player.Position.X += x;
            frame++;
        }
    }
}
