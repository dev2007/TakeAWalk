using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    /// <summary>
    /// Actor class.
    /// This is used for drawing common image.
    /// </summary>
    public class CActor:CBaseActor,ISprite,IActor
    {
        public CActor(Texture2D texture, Vector2 vector, float layerDepth):base(texture,vector,layerDepth)
        {
        }

        public override void StateChange(Microsoft.Xna.Framework.Input.Touch.GestureSample gesture)
        {
            
        }
    }
}
