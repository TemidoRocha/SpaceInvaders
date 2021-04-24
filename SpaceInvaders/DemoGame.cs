using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceInvaders.ExpressedEngine;

namespace SpaceInvaders
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        // Shape2D player;
        Sprite2D player;

        bool left;
        bool right;
        bool down;
        bool up;
        string[,] Map =
        {
            {"g","g","g","g","g","g","g" },
            {"g",".",".",".",".",".","g" },
            {"g",".",".",".",".",".","g" },
            {"g",".",".","g",".",".","g" },
            {"g",".","g","g",".",".","g" },
            {"g",".",".","g",".",".","g" },
            {"g",".",".","g",".",".","g" },
            {"g",".",".","g",".",".","g" },
            {"g","g","g","g","g","g","g" },
        };
        public DemoGame() : base(new Vector2(615, 515), "Space Invaders") { }

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;
            CameraPosition.X = 100;

            // player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "shape test");
            // player = new Sprite2D(new Vector2(10, 10), new Vector2(36, 45), "Players/Player Green/playerGreen_swim2", "shape test");
            for (int i = 0; i<Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if(Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i*50, j*50), new Vector2(50, 50), "Tiles/Blue tiles/tileBlue_03", "Ground");

                    }

                }
            }

            player = new Sprite2D(new Vector2(30, 30), new Vector2(30, 40), "Players/Player Green/playerGreen_walk1", "shape test");
        }

        public override void OnDraw()
        {

        }

        public override void OnUpdate()
        {
            if (up)
            {
                player.Position.Y -= 1f;
            }
            if (down)
            {
                player.Position.Y += 1f;
            }
            if (left)
            {
                player.Position.X -= 1f;
            }
            if (right)
            {
                player.Position.X += 1f;
            }
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; };
            if (e.KeyCode == Keys.S) { down = true; };
            if (e.KeyCode == Keys.A) { left = true; };
            if (e.KeyCode == Keys.D) { right = true; };

        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; };
            if (e.KeyCode == Keys.S) { down = false; };
            if (e.KeyCode == Keys.A) { left = false; };
            if (e.KeyCode == Keys.D) { right = false; };
        }
    }
}
