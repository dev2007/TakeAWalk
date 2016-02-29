using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
    public class CStartScript : CBaseScript
    {
        public CStartScript(ContentManager contentManager)
            : base(contentManager)
        {
        }

        protected override void BuildScene()
        {
            Texture2D backGround = Get2D(@"Images\officebackground");
            CBaseActor backGroundActor = new CBaseActor(backGround, new Vector2(0, 0), Global.WINDOW_WIDTH, Global.WINDOW_HEIGHT, 0.5f);
            stage.HireActor(backGroundActor);


            Texture2D texture = Get2D(@"Images\office");
            CBaseActor actor = new CBaseActor(texture, new Vector2((Global.WINDOW_WIDTH - texture.Width) / 2, (Global.WINDOW_HEIGHT - texture.Height) / 2), 0.5f);
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

            stage.PlayMusic(GetSong(@"Music\Sound_keyboard"));
        }
    }
}
