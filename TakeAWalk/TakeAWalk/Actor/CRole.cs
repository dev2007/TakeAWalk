using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    public class CRole:CAnimation
    {
        private Dictionary<RoleDirect, Texture2D> roleTextureList;

        public CRole(Texture2D texture, Vector2 vector, float layerDepth)
            : base(texture, vector, layerDepth)
        {
            roleTextureList = new Dictionary<RoleDirect, Texture2D>();
            roleTextureList.Add(RoleDirect.FORWARD, texture);
        }

        public void AddTexture(Texture2D texture,RoleDirect direct)
        {
            roleTextureList.Add(direct, texture);
        }

        private void SwitchForward()
        {
            this.texture = roleTextureList[RoleDirect.FORWARD];
        }

        private void SwichUp()
        {
            this.texture = roleTextureList[RoleDirect.UP];
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (!isRunning)
            {
                frameIndex = 0;
            }
            else if (timeSinceLastFrame > frameCount)
            {
                timeSinceLastFrame -= frameCount;
                frameIndex++;
                if (frameIndex >= texture.Width / frameWidthSize)
                    frameIndex = 0;
            }
            drawRect = new Rectangle(frameIndex * frameWidthSize, 0, frameWidthSize, texture.Height);
        }
    }

    public enum RoleDirect
    {
        FORWARD = 1,
        UP = 2
    }
}
