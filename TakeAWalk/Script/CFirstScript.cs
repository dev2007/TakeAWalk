using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoBo;
using MonoBo.Script;
using MonoBo.Sprite.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Script
{
    public class CFirstScript : CBaseScript
    {
        public CFirstScript(ContentManager contentManager)
            : base(contentManager)
        {

        }

        protected override void BuildScene()
        {
            Texture2D ani = Get2D(@"Sprites\wait");
            CAnimationActor actor2 = new CAnimationActor(ani,
                new Microsoft.Xna.Framework.Vector2(Global.WINDOW_WIDTH / 2 - 20, (Global.WINDOW_HEIGHT - ani.Height) / 2 + 10),
                1);

            actor2.SetFrameCount(4);
            actor2.SetFrame(100);
            stage.HireActor(actor2);
        }
    }
}
