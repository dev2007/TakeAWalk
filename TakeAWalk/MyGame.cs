using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TakeAWalk.Stage;
using TakeAWalk.Utils;

namespace TakeAWalk
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MyGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CDirector director;

        Matrix _view;
        Vector2 _cameraPosition;
        private Vector2 _screenCenter;
        private float viewMoveVelocity;

        /// <summary>
        /// Constructor. 
        /// </summary>
        public MyGame()
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
            // TODO: Add your initialization logic here
            AppUtils.Manager = this.Content;
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

            // TODO: use this.Content to load your game content here
            _view = Matrix.Identity;
            _cameraPosition = Vector2.Zero;
            _screenCenter = new Vector2(Global.WINDOW_WIDTH / 2f, Global.WINDOW_HEIGHT / 2f);

            ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
            director = new CDirector(this);
            //director.AddScript(new CStartStage());
            //director.AddScript(new CSplashStage());
            director.AddScript(new CCityStage());
            director.Action();
        }

        public void Notice(float stageVelocity)
        {
            viewMoveVelocity = stageVelocity;
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

            // TODO: Add your update logic here
            CameraUpdate();
            PhysicWorld.World.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            director.Update(gameTime);
            base.Update(gameTime);
        }

        private void CameraUpdate()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Left))
                _cameraPosition.X += viewMoveVelocity;

            if (state.IsKeyDown(Keys.Right))
                _cameraPosition.X -= viewMoveVelocity;


            _view = Matrix.CreateTranslation(new Vector3(_cameraPosition - _screenCenter, 0f)) * Matrix.CreateTranslation(new Vector3(_screenCenter, 0f));
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront,null,null,null,null,null,_view);
            
            director.Draw(spriteBatch, gameTime);      
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
