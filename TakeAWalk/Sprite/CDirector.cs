using System.Collections.Generic;
using TakeAWalk.Sprite;
using TakeAWalk.Stage;

namespace TakeAWalk
{
    /// <summary>
    /// class Director.
    /// It draw the stage which is created by one story script.
    /// </summary>
    public class CDirector : ISprite, INotice
    {
        /// <summary>
        /// Game object.
        /// </summary>
        private MyGame _game;
        /// <summary>
        /// Current stage object.
        /// </summary>
        private CStage currentStage;
        /// <summary>
        /// Script list.
        /// </summary>
        private IList<CStage> stageList;
        /// <summary>
        /// Script indexer.
        /// </summary>
        private int stageIndex;

        public CDirector(MyGame game)
        {
            _game = game;
            this.stageList = new List<CStage>();
            this.stageIndex = -1;
        }

        public CDirector(IList<CStage> scriptList)
        {
            this.stageList = scriptList;
            this.stageIndex = -1;
        }

        /// <summary>
        /// add script for director.
        /// </summary>
        /// <param name="storyScript"></param>
        public void AddScript(CStage storyScript)
        {
            stageList.Add(storyScript);
        }

        /// <summary>
        /// First run must call it or NextScript.
        /// After that, it's same to the NextScript().
        /// </summary>
        public void Action()
        {
            NextScript();
        }

        /// <summary>
        /// Switch to next script.
        /// </summary>
        /// <returns>True.switch ok. False.no more script.</returns>
        public bool NextScript()
        {
            if (currentStage != null)
                currentStage.UnRegisterDirector();

            if (stageIndex == stageList.Count - 1)
            {
                return false;
            }

            stageIndex++;
            currentStage = stageList[stageIndex];
            currentStage.RegisterDirector(this);
            _game.Notice(currentStage.RoleVelocity);
            return true;
        }

        /// <summary>
        /// Receive notice.
        /// </summary>
        /// <param name="notice"></param>
        public void ReceiveNotice(Notice notice)
        {
            switch (notice)
            {
                case Notice.NOTHING:
                    break;
                case Notice.ACTION_FINISH:
                    if (!NextScript())
                    {
                        currentStage = null;
                        //TODO:all scene finish.
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Script list's count.
        /// </summary>
        /// <returns></returns>
        private int ScriptSize()
        {
            return stageList.Count;
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (currentStage == null)
                return;
            currentStage.Update(gameTime);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (currentStage == null)
                return;
            currentStage.Draw(spriteBatch, gameTime);
        }


    }
}
