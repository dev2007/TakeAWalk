using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Stage
{
    /// <summary>
    /// Splash screen.
    /// </summary>
    class CSplashStage:CStage
    {
        private int timeSpan = 0;
        public CSplashStage()
            : base()
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            timeSpan += gameTime.ElapsedGameTime.Milliseconds;
            if(timeSpan > 4000)
            {
                ReceiveNotice(Notice.ACTION_FINISH);
            }
            else
                base.Update(gameTime);
        }
    }
}
