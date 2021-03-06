using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Drawing;using System.Windows.Forms;using System.Threading;namespace SpaceInvaders.ExpressedEngine{    /// <summary>    /// Canvas is used in order to refresh the canvas. windows forms doesn't do it automatically    /// </summary>    class Canvas : Form    {        public Canvas()        {            this.DoubleBuffered = true;        }    }    public abstract class ExpressedEngine    {        private Vector2 ScreenSize = new Vector2(512, 512);        private string Title = "New Game";        private Canvas Window = null;        private Thread GameLoopThread = null;        public static List<Shape2D> AllShapes = new List<Shape2D>();        public static List<Sprite2D> AllSprites = new List<Sprite2D>();        public Color BackgroundColor;        public Vector2 CameraPosition = Vector2.Zero();        public float CameraAngle = 0f;        public Vector2 CameraZoom = new Vector2(1, 1);        public ExpressedEngine(Vector2 ScreenSize, string Title)        {            Log.Info("Game is starting...");            this.ScreenSize = ScreenSize;            this.Title = Title;            Window = new Canvas();            Window.Size = new Size((int)ScreenSize.X, (int)this.ScreenSize.Y);            Window.Text = this.Title;            Window.Paint += Renderer;            Window.KeyDown += Window_KeyDown;            Window.KeyUp += Window_KeyUp;            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;            Window.FormClosing += Window_FormClosing;            GameLoopThread = new Thread(GameLoop);            GameLoopThread.Start();            Application.Run(Window);        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)        {            AllShapes.Add(shape);        }        public static void UnRegisterShape(Shape2D shape)        {            AllShapes.Remove(shape);        }        public static void RegisterSprite(Sprite2D sprite)        {            AllSprites.Add(sprite);        }        public static void UnRegisterSprite(Sprite2D sprite)        {            AllSprites.Remove(sprite);        }        void GameLoop()        {            OnLoad();            while (GameLoopThread.IsAlive)            {                try
                {
                    OnDraw();                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });                    OnUpdate();                    // this delay is needed in order for the windows to refresh,                    // otherwise willl refresh on the top of the previous state                    Thread.Sleep(1);
                }                catch
                {
                    Log.Error("[ERROR] - Game has not been found.");
                }            }        }        private void Renderer(object sender, PaintEventArgs e)        {            Graphics g = e.Graphics;            // this will be our backgroud color and the first thing to draw            g.Clear(BackgroundColor);            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);            g.RotateTransform(CameraAngle);            g.ScaleTransform(CameraZoom.X, CameraZoom.Y);            try
            {
                foreach (Shape2D shape in AllShapes)                {                    g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);                }                foreach(Sprite2D sprite in AllSprites)
                {
                    g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
                }
            }            catch
            {
                Log.Error("[ERROR] - Shapes and sprites are not being loaded.");
            }        }        /// <summary>        /// here we load everything we need before the game starts        /// (sprites....)        /// </summary>        public abstract void OnLoad();        /// <summary>        /// anything regarding drawing should enter here        /// </summary>        public abstract void OnDraw();        /// <summary>        /// anything regarding movements, phisics should enter here        /// </summary>        public abstract void OnUpdate();        public abstract void GetKeyDown(KeyEventArgs e);        public abstract void GetKeyUp(KeyEventArgs e);    }}