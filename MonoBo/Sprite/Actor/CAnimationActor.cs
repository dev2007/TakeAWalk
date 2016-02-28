using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Sprite.Actor
{
    /// <summary>  
    /// Actor animation class.  
    /// This is used for drawing animation sprite.  
    /// </summary>  
    public class CAnimationActor : CBaseActor
    {
        /// <summary>  
        /// frame index for calculate drawrect.  
        /// </summary>  
        private int frameIndex;
        /// <summary>  
        /// frame size for calculate drawrect  
        /// </summary>  
        private int frameWidthSize;
        /// <summary>  
        /// frame count.  
        /// </summary>  
        private int frameCount;

        /// <summary>  
        /// Constructor.  
        /// </summary>  
        /// <param name="texture">Texture2D resource.It is a image which is consist of sequent frame images.</param>  
        /// <param name="vector">Draw postion.</param>  
        /// <param name="layerDepth">Layer Depth.</param>  
        public CAnimationActor(Texture2D texture, Vector2 vector, float layerDepth)
            : base(texture, vector, layerDepth)
        {
            this.frameCount = Global.MILLISECONDS_PER_FRAME;
            this.frameWidthSize = Global.STANDARD_ANIMATION_SIZE;
            this.frameIndex = 0;
            drawRect = new Rectangle(0, 0, Global.STANDARD_ANIMATION_SIZE, Global.STANDARD_ANIMATION_SIZE);
        }

        /// <summary>  
        /// Set animation frame number.  
        /// If the paramater is less than 1,then the frame number will be setted with the default value.  
        /// </summary>  
        /// <param name="frame"></param>  
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
        /// <param name="frameCount"></param>  
        public void SetFrameCount(int frameCount)
        {
            if (frameCount <= 0)
            {
                this.frameWidthSize = Global.STANDARD_ANIMATION_SIZE;
            }
            else
            {
                this.frameWidthSize = texture.Width / frameCount;
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
                if (frameIndex >= texture.Width / frameWidthSize)
                    frameIndex = 0;
            }
            drawRect = new Rectangle(frameIndex * frameWidthSize, 0, frameWidthSize, texture.Height);
        }

        /// <summary>
        /// Animation draw.
        /// </summary>
        /// <param name="gesture"></param>
        public override void Change(Microsoft.Xna.Framework.Input.Touch.GestureSample gesture)
        {
            if (gesture.GestureType == GestureType.Flick)
            {
                isRunning = !isRunning;
            }
        }
    }
}
