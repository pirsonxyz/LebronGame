using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lebrongame
{
    
        public class Bronny : Game
        {
            Texture2D ballTexture;
            Vector2 ballPosition;
            float ballSpeed;
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
                this.ballPosition =
                    new Vector2(this._graphics.PreferredBackBufferWidth / 2,
                                this._graphics.PreferredBackBufferHeight / 2);
                this.ballSpeed = 100f;

                base.Initialize();
            }

            protected override void LoadContent()
            {
                _spriteBatch = new SpriteBatch(GraphicsDevice);

                // TODO: use this.Content to load your game content here
                this.ballTexture = Content.Load<Texture2D>("lebron");
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
                    ballPosition.Y -=
                        ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    ballPosition.Y +=
                        ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Left))
                {
                    ballPosition.X -=
                        ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Right))
                {
                    ballPosition.X +=
                        ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (ballPosition.X >
                    _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                {
                    ballPosition.X =
                        _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                }
                else if (ballPosition.X < ballTexture.Width / 2)
                {
                    ballPosition.X = ballTexture.Width / 2;
                }

                if (ballPosition.Y >
                    _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                {
                    ballPosition.Y =
                        _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                }
                else if (ballPosition.Y < ballTexture.Height / 2)
                {
                    ballPosition.Y = ballTexture.Height / 2;
                }

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here
                this._spriteBatch.Begin();
                this._spriteBatch.Draw(
                    this.ballTexture, this.ballPosition, null, Color.White, 0f,
                    new Vector2(this.ballTexture.Width / 2, this.ballTexture.Height / 2),
                    Vector2.One, SpriteEffects.None, 0f);
                this._spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }

