using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using MonoBo;
using MonoBo.Sprite;
using MonoBo.Utils;
using TakeAWalk.Script;

namespace TakeAWalk
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TheGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CDirector director;

        public TheGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Global.WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = Global.WINDOW_HEIGHT;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            TouchPanel.EnabledGestures = GestureType.Flick;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            director = new CGameDirector(new CStartScript(this.Content),this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (TouchPanel.IsGestureAvailable)
            {
                director.Change(TouchPanel.ReadGesture());
            }
            else if (Helper.ContainKey(Keyboard.GetState().GetPressedKeys(), Keys.Up)
                    || Helper.ContainKey(Keyboard.GetState().GetPressedKeys(), Keys.Down)
                    || Helper.ContainKey(Keyboard.GetState().GetPressedKeys(), Keys.Right)
                    || Helper.ContainKey(Keyboard.GetState().GetPressedKeys(), Keys.Left)
                    || Helper.ContainKey(Keyboard.GetState().GetPressedKeys(), Keys.Space))
            {
                director.Change(Keyboard.GetState().GetPressedKeys());
            }
            else
                director.Update(gameTime);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            director.Draw(spriteBatch, gameTime);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
