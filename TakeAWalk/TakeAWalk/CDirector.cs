using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Script;
using TakeAWalk.Stage;

namespace TakeAWalk
{
    /// <summary>
    /// class Director.
    /// It draw the stage which is created by one story script.
    /// </summary>
    public class CDirector  : ISprite,INotice
    {
        /// <summary>
        /// Current stage object.
        /// </summary>
        private CStage currentStage;
        /// <summary>
        /// Script list.
        /// </summary>
        private IList<IScript> scriptList;
        /// <summary>
        /// Script indexer.
        /// </summary>
        private int stageIndex;

        public CDirector()
        {
            this.scriptList = new List<IScript>();
            this.stageIndex = -1;
        }

        public CDirector(IList<IScript> scriptList)
        {
            this.scriptList = scriptList;
            this.stageIndex = -1;
        }

        public void AddScript(IScript storyScript)
        {
            scriptList.Add(storyScript);
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
            if(stageIndex == scriptList.Count -1)
            {
                return false;
            }

            stageIndex++;
            currentStage = scriptList[stageIndex].GetStage();
            currentStage.RegisterDirector(this);
            return true;
        }

        public void ReceiveNotice(Notice notice)
        {
            switch (notice)
            {
                case Notice.NOTHING:
                    break;
                case Notice.ACTION_FINISH:
                    if (!NextScript())
                    {
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
            return scriptList.Count;
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
