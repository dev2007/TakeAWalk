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
            CAnimation actor = new CAnimation(texture, new Microsoft.Xna.Framework.Vector2(0, 0), Z_Axis.STAGE);
            stageList.Add(actor);
            return stageList;
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
