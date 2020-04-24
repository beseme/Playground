using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Playground
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D cubodon;
        Texture2D Rocketship;
        Texture2D Asteroid1;
        Texture2D testTexture;

        Model Spaceship;

        float targetX = 128;
        float targetY;

        float AsteroidSpawnRate = 0;
        float StarSpawnRate = 0;
        float AsteroidCooldown = 0;
        float StarCooldown = 0;

        private float _moveVal = .1f;
        private float _rotation = .1f;

        Vector2 scale;
        Vector2 velocity = new Vector2(100,100);
        Vector2 position = new Vector2(0,0);
        Vector2 rotation = new Vector2(0, 0);

        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0)) * Matrix.CreateRotationX(90);
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        bool AsteroidReady = false;
        bool StarReady = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            cubodon = this.Content.Load<Texture2D>("Cubodon");
            Rocketship = this.Content.Load<Texture2D>("rocketship");
            Asteroid1 = this.Content.Load<Texture2D>("Asteroid 1");
            testTexture = this.Content.Load<Texture2D>("Texture");
            Spaceship = this.Content.Load<Model>("flieger");
            scale = new Vector2(targetX / cubodon.Width, targetX / cubodon.Width);
            targetY = cubodon.Height * scale.Y;
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
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Right))
                position.X += _moveVal;
            if (state.IsKeyDown(Keys.Left))
                position.X -= _moveVal;
            if (state.IsKeyDown(Keys.Up))
                position.Y -= _moveVal;
            if (state.IsKeyDown(Keys.Down))
                position.Y += _moveVal;

            if (state.IsKeyDown(Keys.D))
                rotation.X += _moveVal;
            if (state.IsKeyDown(Keys.A))
                rotation.X -= _moveVal;
            if (state.IsKeyDown(Keys.W))
                rotation.Y -= _moveVal;
            if (state.IsKeyDown(Keys.S))
                rotation.Y += _moveVal;

            world = Matrix.CreateTranslation(new Vector3(position.X, position.Y,0)) * Matrix.CreateRotationX(rotation.X) * Matrix.CreateRotationY(rotation.Y);


            if (AsteroidReady)
            {
               // LoadContent
                AsteroidReady = false;
            }
            else
            {
                AsteroidCooldown -= gameTime.ElapsedGameTime.Seconds;
                if(AsteroidCooldown <= 0)
                {
                    AsteroidCooldown = AsteroidSpawnRate;
                    AsteroidReady = true;
                }
            }

            base.Update(gameTime);
        } 

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            //spriteBatch.Draw(Spaceship, position: position, scale: scale);
            spriteBatch.End();

            DrawModel(Spaceship, world, view, projection);

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;

                    effect.Texture = testTexture;
                    effect.TextureEnabled = true;
                }

                mesh.Draw();
            }
        }
    }
}
