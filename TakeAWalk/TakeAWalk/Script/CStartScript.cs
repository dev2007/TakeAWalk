using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;
using TakeAWalk.Stage;

namespace TakeAWalk.Script
{
    public class CStartScript:IScript
    {
        private CStage stage;
        private ContentManager contentManager;
        public CStartScript(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            stage = new CStage();
            AddActors();
        }

        private void AddActors()
        {
            Texture2D texture = Get2D(@"Images\office");
            CActor actor = new CActor(texture, new Vector2((Global.WINDOW_WIDTH - texture.Width) / 2, (Global.WINDOW_HEIGHT - texture.Height) / 2),1);
            stage.HireActor(actor);
            Texture2D ani = Get2D(@"Sprites\start");
            CAnimation actor2 = new CAnimation(ani,
                new Microsoft.Xna.Framework.Vector2(Global.WINDOW_WIDTH/2 -20, (Global.WINDOW_HEIGHT - ani.Height) / 2 + 10),
                1);
            actor2.SetFrameSplitCount(4);
            actor2.SetFrame(100);
            stage.HireActor(actor2);
        }

        private Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
        }

        public Stage.CStage CreateStage()
        {
            return stage;
        }
    }
}
