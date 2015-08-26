﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    /// <summary>
    /// Actor animation class.
    /// This is used for drawing animation sprite.
    /// </summary>
    public class CAnimation : CBaseActor
    {

        /// <summary>
        /// frame index for calculate drawrect.
        /// </summary>
        protected int frameIndex;
        /// <summary>
        /// frame size for calculate drawrect
        /// </summary>
        protected int frameWidthSize;
        /// <summary>
        /// frame count.
        /// </summary>
        protected int frameCount;

        private int timeSinceLastFrame;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="texture">Texture2D resource.It is a image which is consist of sequent frame images.</param>
        /// <param name="vector">Draw postion.</param>
        /// <param name="layerDepth">Layer Depth.</param>
        public CAnimation(string spriteName, Vector2 centerPosition, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {
            this.frameCount = Global.MILLISECONDS_PER_FRAME;
            this.frameWidthSize = Global.STANDARD_ANIMATION_SIZE;
        }

        /// <summary>
        /// Set animation frame number.
        /// If the paramater is less than 1,then the frame number will be setted with the default value.
        /// </summary>
        /// <param name="newFrameCount">new frame count.Bigger,then slow.</param>
        public void SetFrame(int newFrameCount)
        {
            if (newFrameCount <= 0)
            {
                newFrameCount = Global.MILLISECONDS_PER_FRAME;
            }
            this.frameCount = newFrameCount;
        }

        /// <summary>
        /// Set animation frame count.The frame size is texture.width / count;
        /// If the frame count is less than 1,then it will be setted with the default value.
        /// </summary>
        /// <param name="splitCount"></param>
        public void SetFrameSplitCount(int splitCount)
        {
            if (splitCount <= 0)
            {
                this.frameWidthSize = Global.STANDARD_ANIMATION_SIZE;
            }
            else
            {
                this.frameWidthSize = sprite.Width / splitCount;
            }
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
                if (frameIndex >= sprite.Width / frameWidthSize)
                    frameIndex = 0;
            }
            spriteDrawRect = new Rectangle(frameIndex * frameWidthSize, 0, frameWidthSize, sprite.Height);
        }
    }
}
