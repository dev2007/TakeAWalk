using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;
using TakeAWalk.Stage;

namespace TakeAWalk.Script
{
    /// <summary>
    /// Start scene.
    /// </summary>
    public class CStartScript:CBaseScript
    {
        public CStartScript(ContentManager contentManager):base(contentManager)
        {
        }

        protected override void CreateStage()
        {
            Texture2D back = Get2D(@"Images\officebackground");
            CActor actorBack = new CActor(back, new Vector2(0, 0), Z_Axis.BACKGROUND);
            actorBack.SetDrawRect(Global.WINDOW_WIDTH, Global.WINDOW_HEIGHT);
            stage.HireActor(actorBack);

            Texture2D title = Get2D(@"Images\title");
            CActor actorTitle = new CActor(title, new Vector2((Global.WINDOW_WIDTH - title.Width) / 2 + 10, 20), Z_Axis.STAGE);
            stage.HireActor(actorTitle);

            Texture2D office = Get2D(@"Images\office");
            CActor actorOffice = new CActor(office, 
                new Vector2((Global.WINDOW_WIDTH - office.Width) / 2, (Global.WINDOW_HEIGHT - office.Height) / 2), Z_Axis.STAGE);
            stage.HireActor(actorOffice);

            Texture2D man = Get2D(@"Sprites\start");
            CAnimation actorMan = new CAnimation(man,
                new Microsoft.Xna.Framework.Vector2(Global.WINDOW_WIDTH / 2 - 20, (Global.WINDOW_HEIGHT - man.Height) / 2 + 10),
                Z_Axis.ZERO);
            actorMan.SetFrameSplitCount(4);
            actorMan.SetFrame(100);
            stage.HireActor(actorMan);

            Song song = GetSong(@"Music\Sound_keyboard");
            stage.PlayMusic(song);
        }
    }
}
