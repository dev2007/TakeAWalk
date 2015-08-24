using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;
using TakeAWalk.Script;
using TakeAWalk.Stage;

namespace TakeAWalk.ActorFactory
{
    public class CCityFactory:IFactory
    {
        private ContentManager contentManager;
        private IList<ISprite> stageList;
        public CCityFactory(ContentManager contentManager)
        {
            this.contentManager = contentManager;                           
            stageList = new List<ISprite>();
        }

        private Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
        }

        public IList<ISprite> StageActor()
        {
            Texture2D texture = Get2D(@"Sprites\wait");
            int actorY = (Global.WINDOW_HEIGHT - texture.Height) / 2;
            CRole actor = new CRole(texture, new Microsoft.Xna.Framework.Vector2((Global.WINDOW_WIDTH-texture.Width )/ 2 , (Global.WINDOW_HEIGHT - texture.Height)/2), Z_Axis.STAGE);
            actor.AddTexture(Get2D(@"Sprites\walk"), RoleDirect.FORWARD);
            actor.AddTexture(Get2D(@"Sprites\jump"), RoleDirect.UP);
            actor.SetFrameCount(100, 140);
            stageList.Add(actor);

            StageBlock(actorY,texture.Height);
            return stageList;
        }

        private void StageBlock(int actorY, int actorHeight)
        {
            Texture2D box = Get2D(@"Blocks\box_2");
            CBlock boxActor = new CBlock(box, new Microsoft.Xna.Framework.Vector2((Global.WINDOW_WIDTH -100) / 2, actorY + actorHeight - box.Height/2 + 6), Z_Axis.STAGE);
            boxActor.SetVelocity(10);
            stageList.Add(boxActor);
        }

        public IList<ISprite> NearStageActor()
        {
            throw new NotImplementedException();
        }

        public IList<ISprite> RemoteStageActor()
        {
            throw new NotImplementedException();
        }

        public List<ISprite> BackgroundActor()
        {
            throw new NotImplementedException();
        }
    }
}
