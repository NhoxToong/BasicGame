using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System;

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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1024;
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

            __sprites = new List<VisibleEntity>();
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
            __sprites.Add(CreateBg());
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
            for (int i = 0; i < __sprites.Count; i++)
            {
                __sprites[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        Vector2 position = Vector2.Zero;
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
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

            float x = 5;
            float y = 10;
            l.Add(new Zombie(new Unit(txs, x, y)));
            return l.ToArray();
        }
    }
}
