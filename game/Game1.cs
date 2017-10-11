using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System;
using game.Input;
using game.EventArg;

namespace game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IList<VisibleEntity> __sprites;
        Matrix matrix = Matrix.Identity;
        InputKeyboard inputKeyboard;
        Vector2 spritePosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1920;
            inputKeyboard = new InputKeyboard();
            inputKeyboard.NewInput += InputKeyboard_NewInput;
            Content.RootDirectory = "Content";
            spritePosition = new Vector2(5, 5);
        }

        private void InputKeyboard_NewInput(object sender, NewInputEventArgs e)
        {
            switch (e.GameInput)
            {
                case GameInput.Right:
                    spritePosition.X++;
                    break;
                case GameInput.Left:
                    spritePosition.X--;
                    break;
                case GameInput.Up:
                    spritePosition.Y++;
                    break;
                case GameInput.Down:
                    spritePosition.Y--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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

            __sprites = new List<VisibleEntity>();
            this.IsMouseVisible = true;
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
            //__sprites.Add(CreateBg());
            var textures = LoadZombie();
            (__sprites as List<VisibleEntity>).AddRange(textures);
        }

        private Background CreateBg()
        {
            List<Texture2D> txs = new List<Texture2D>();
            for (int i = 0; i < Config.Instance.LoadUnitTexture("Background").Length; i++)
            {
                txs.Add(this.Content.Load<Texture2D>(Config.Instance.LoadUnitTexture("Background")[i]));
            }
            return new Background(new Unit(txs, 0, 0));
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
            inputKeyboard.Update(gameTime.ElapsedGameTime.Milliseconds);
            for (int i = 0; i < __sprites.Count; i++)
            {
                __sprites[i].Update(gameTime,spritePosition.X,spritePosition.Y);
            }
            matrix = Matrix.CreateScale(new Vector3(0.5f,0.5f,1f));
            base.Update(gameTime);
        }

        Vector2 position = Vector2.Zero;
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, matrix);
            for(int i=0;i<__sprites.Count; i++)
            {
                __sprites[i].Draw(gameTime,spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Zombie[] LoadZombie()
        {
            List<Zombie> l = new List<Zombie>();
            List<Texture2D> txs = new List<Texture2D>();
            for (int i = 0; i < Config.Instance.LoadUnitTexture("ZombieWalk").Length; i++)
            {
                txs.Add(this.Content.Load<Texture2D>(Config.Instance.LoadUnitTexture("ZombieWalk")[i]));
            }
            l.Add(new Zombie(new Unit(txs, 5, 5)));
            return l.ToArray();
        }
        
    }
}
