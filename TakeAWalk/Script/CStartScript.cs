using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoBo;
using MonoBo.Script;
using MonoBo.Sprite;
using MonoBo.Sprite.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Script
{
    public class CStartScript : IScript
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
            Texture2D backGround = Get2D(@"Images\officebackground");
            CBaseActor backGroundActor = new CBaseActor(backGround, new Vector2(0, 0), Global.WINDOW_WIDTH, Global.WINDOW_HEIGHT, 1);
            stage.HireActor(backGroundActor);

            Texture2D texture = Get2D(@"Images\office");
            CBaseActor actor = new CBaseActor(texture, new Vector2((Global.WINDOW_WIDTH - texture.Width) / 2, (Global.WINDOW_HEIGHT - texture.Height) / 2), 1);
            stage.HireActor(actor);

            Texture2D textureTitle = Get2D(@"Images\title");
            CBaseActor title = new CBaseActor(textureTitle, new Vector2((Global.WINDOW_WIDTH - textureTitle.Width) / 2, 20), 1);
            stage.HireActor(title);


            Texture2D ani = Get2D(@"Sprites\start");
            CAnimationActor actor2 = new CAnimationActor(ani,
                new Microsoft.Xna.Framework.Vector2(Global.WINDOW_WIDTH / 2 - 20, (Global.WINDOW_HEIGHT - ani.Height) / 2 + 10),
                1);
            actor2.SetFrameCount(4);
            actor2.SetFrame(100);
            stage.HireActor(actor2);
        }

        private Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
        }

        public CStage CreateStage()
        {
            return stage;
        }
    }
}
