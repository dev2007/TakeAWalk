using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Sprite.Actor;

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
            if (timeSpan > 4000)
            {
                ReceiveNotice(Notice.ACTION_FINISH);
            }
            else
                base.Update(gameTime);
        }

        protected override void InitActors()
        {
            CActor actor = new CActor(@"Images\headphone",
                new Microsoft.Xna.Framework.Vector2((Global.WINDOW_WIDTH) / 2, (Global.WINDOW_HEIGHT) / 2), Z_Axis.STAGE);
            HireActor(actor);
        }

        protected override void Startup()
        {
            base.Startup();
            PlayMusic(@"Music\Sound_opendoor", false);
        }
    }
}
