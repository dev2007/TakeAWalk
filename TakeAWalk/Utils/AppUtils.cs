using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Utils
{
    public class AppUtils
    {
        public static ContentManager Manager { private get; set; }
        public static Texture2D LoadContent(string spriteName)
        {
            if (Manager == null)
                throw new Exception("ex: Manager not be initialized.");

            return Manager.Load<Texture2D>(spriteName);
        }

        public static Song LoadSong(string songName)
        {
            if (Manager == null)
                throw new Exception("ex: Manager not be initialized.");

            return Manager.Load<Song>(songName);
        }

        public static SpriteFont LoadFont(string fontName)
        {
            if (Manager == null)
                throw new Exception("ex: Manager not be initialized.");

            return Manager.Load<SpriteFont>(fontName);
        }
    }
}
