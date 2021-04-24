﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders.ExpressedEngine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Image Sprite = null;

        public Sprite2D(Vector2 Position, Vector2 Scale, string Directory, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Log.Info($"[SPRITE2D]({Tag}) - Has been registered.");
            ExpressedEngine.RegisterSprite(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[SPRITE2D]({Tag}) - Has been destroyed.");
            ExpressedEngine.UnRegisterSprite(this);
        }
    }
}
