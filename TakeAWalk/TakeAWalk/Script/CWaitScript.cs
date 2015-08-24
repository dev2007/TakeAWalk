using Microsoft.Xna.Framework.Audio;
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
    public class CWaitScript:CBaseScript
    {
        public CWaitScript(ContentManager contentManager):base(contentManager)
        {
            stage = new CSplashStage();
        }

        protected override void CreateStage()
        {
            Texture2D texture = Get2D(@"Images\headphone");
            CActor actor = new CActor(texture,
                new Microsoft.Xna.Framework.Vector2((Global.WINDOW_WIDTH - texture.Width) / 2, (Global.WINDOW_HEIGHT - texture.Height) / 2), Z_Axis.STAGE);
            stage.HireActor(actor);
            Song song = GetSong(@"Music\Sound_opendoor");
            stage.PlayMusic(song, false);
        }
    }
}
