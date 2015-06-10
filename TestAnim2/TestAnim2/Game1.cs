using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestAnim2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Texture2D _childwalk, currentAnim;


        Rectangle rectangleDestination2;
        Rectangle rectangleSource2;

        Vector2 position = new Vector2();



        KeyboardState _keyboardstate;
        KeyboardState _keyboardstatehold;


        int a;
        int frames2;
        float delay2 = 200f;  // à partir du moment ou 2 délais sont différents, il faut 2 variables.
        float elapsed2;

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

            rectangleDestination2 = new Rectangle(0, 0, (192/6), (256/4));
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _childwalk = Content.Load<Texture2D>("Sprite_male_child_walk");
        }


        protected override void UnloadContent()
        {

        }

        private void animate(GameTime gametime)
        {
            if (elapsed2 >= delay2)
            {
                if (frames2 >= 5)
                {
                    frames2 = 1; // on commence à 1 car la premiere image est en double
                }
                else
                {
                    frames2++;
                }
                elapsed2 = 0;
            }
            
        }


        protected override void Update(GameTime gameTime)
        {
            rectangleSource2 = new Rectangle(0, 0, (192 / 6), (256 / 4));
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            _keyboardstate = Keyboard.GetState();
            elapsed2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_keyboardstate.IsKeyDown(Keys.Right))
            {
                a = 1;
                position.X += 2f;
                animate(gameTime);
                rectangleSource2 = new Rectangle(32 * frames2, 64*3, (192 / 6), (256 / 4));
            }
            else if (_keyboardstate.IsKeyDown(Keys.Left) )
            {
                a = 2;
                position.X -= 2f;
                animate(gameTime);
                rectangleSource2 = new Rectangle(32 * frames2, 64 * 2, (192 / 6), (256 / 4));
            }
            else if (_keyboardstate.IsKeyDown(Keys.Up))
            {
                a = 3;
                position.Y -= 2f;
                animate(gameTime);
                rectangleSource2 = new Rectangle(32 * frames2, 64 * 1, (192 / 6), (256 / 4));
            }
            else if (_keyboardstate.IsKeyDown(Keys.Down))
            {
                a = 4;
                position.Y += 2f;
                animate(gameTime);
                rectangleSource2 = new Rectangle(32 * frames2, 0, (192 / 6), (256 / 4));
            }         
            else if(a == 1)
            {
                rectangleSource2 = new Rectangle(32, 64 * 3, (192/6), 256/4);
            }
            else if (a == 2)
            {
                rectangleSource2 = new Rectangle(32, 64 * 2, (192 / 6), 256 / 4);
            }
            else if (a == 3)
            {
                rectangleSource2 = new Rectangle(32, 64 * 1, (192 / 6), 256 / 4);
            }
            else if (a == 4)
            {
                rectangleSource2 = new Rectangle(32, 0, (192 / 6), 256 / 4);
            }

            rectangleDestination2 = new Rectangle((int)position.X, (int)position.Y, (192 / 6), (256 / 4)); // permet de bouger le rectangle contenant le perso


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(_childwalk, rectangleDestination2, rectangleSource2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
