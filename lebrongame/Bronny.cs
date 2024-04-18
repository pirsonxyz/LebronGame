using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lebrongame
{
        public class Bronny : Game
        {
            private Texture2D bronTexture;
            private Vector2 bronPosition;
            private float bronSpeed;
            private GraphicsDeviceManager _graphics;
            private SpriteBatch _spriteBatch;

            public Bronny()
            {
                _graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
            }

            protected override void Initialize()
            {
                // TODO: Add your initialization logic here
                this.bronPosition =
                    new Vector2(this._graphics.PreferredBackBufferWidth / 2,
                                this._graphics.PreferredBackBufferHeight / 2);
                this.bronSpeed = 100f;

                base.Initialize();
            }

            protected override void LoadContent()
            {
                _spriteBatch = new SpriteBatch(GraphicsDevice);

                // TODO: use this.Content to load your game content here
                this.bronTexture = Content.Load<Texture2D>("lebron");
            }

            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                    Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here
                var kstate = Keyboard.GetState();
                if (kstate.IsKeyDown(Keys.Up))
                {
                    bronPosition.Y -=
                        bronSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    bronPosition.Y +=
                        bronSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Left))
                {
                    bronPosition.X -=
                        bronSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Right))
                {
                    bronPosition.X +=
                        bronSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (bronPosition.X >
                    _graphics.PreferredBackBufferWidth - bronTexture.Width / 2)
                {
                    bronPosition.X =
                        _graphics.PreferredBackBufferWidth - bronTexture.Width / 2;
                }
                else if (bronPosition.X < bronTexture.Width / 2)
                {
                    bronPosition.X = bronTexture.Width / 2;
                }

                if (bronPosition.Y >
                    _graphics.PreferredBackBufferHeight - bronTexture.Height / 2)
                {
                    bronPosition.Y =
                        _graphics.PreferredBackBufferHeight - bronTexture.Height / 2;
                }
                else if (bronPosition.Y < bronTexture.Height / 2)
                {
                    bronPosition.Y = bronTexture.Height / 2;
                }

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here
                this._spriteBatch.Begin();
                this._spriteBatch.Draw(
                    this.bronTexture, this.bronPosition, null, Color.White, 0f,
                    new Vector2(this.bronTexture.Width / 2, this.bronTexture.Height / 2),
                    Vector2.One, SpriteEffects.None, 0f);
                this._spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }

