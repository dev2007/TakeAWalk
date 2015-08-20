using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk
{
    interface ISprite
    {
        void StateChange(GestureSample gesture);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch,GameTime gameTime);
    }
}
