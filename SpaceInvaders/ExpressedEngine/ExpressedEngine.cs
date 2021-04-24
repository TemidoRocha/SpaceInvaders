using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SpaceInvaders.ExpressedEngine
{
    /// <summary>
    /// Canvas is used in order to refresh the canvas. windows forms doesn't do it automatically
    /// </summary>
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class ExpressedEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "New Game";
        private Canvas Window = null;

        public ExpressedEngine(Vector2 ScreenSize, string Title)
        {
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.x, (int)this.ScreenSize.y);
            Window.Text = this.Title;

            Application.Run(Window);
        }
    }
}
