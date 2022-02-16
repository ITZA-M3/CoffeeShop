using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CoffeeShop
{    public enum GameState
    {
        title,
        game,
        pause,
        menu
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        #region Textures
        private Texture2D title;
        private Texture2D storeBase;
        private Texture2D backCounter;
        private Texture2D barista;
        private Texture2D coffeeMakerTxr;
        private Texture2D startBttn;
        #endregion

        private GameState currState;

        // used to hold game window measurements
        private int width;
        private int height;

        private bool interacted;

        private MouseState prevMouse;

        private Rectangle bttn;

        private Equipment coffeeMaker;
        private Barista player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 960;

            width = _graphics.GraphicsDevice.Viewport.Width;
            height = _graphics.GraphicsDevice.Viewport.Height;

            currState = GameState.title;

            interacted = false;

            bttn = new Rectangle(100, 100, 250, 50);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // load textures
            title = this.Content.Load<Texture2D>("CoffeeTitle");
            storeBase = this.Content.Load<Texture2D>("tempBase");
            backCounter = this.Content.Load<Texture2D>("counter");
            barista = this.Content.Load<Texture2D>("tempBarista");
            coffeeMakerTxr = this.Content.Load<Texture2D>("coffeeMaker");
            startBttn = this.Content.Load<Texture2D>("startBttn");

            coffeeMaker = new Equipment(_spriteBatch, coffeeMakerTxr, "Brevilla", new Rectangle(400, 50, 75, 100));
            player = new Barista(_spriteBatch, barista, new Rectangle(150, 200, 75, 185));
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            // switches scenes
            switch (currState)
            {
                case GameState.title:
                    ButtonPress(GameState.game, mouse, bttn);
                    break;
                case GameState.game:
                    if (!interacted)
                    {
                        player.Update(gameTime, mouse, prevMouse);
                    }

                    Interact(mouse, coffeeMaker);
                    break;
                case GameState.menu:
                    break;
                case GameState.pause:
                    break;
                default:
                    break;
            }

            prevMouse = mouse;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            // draws the current scene
            switch (currState)
            {
                case GameState.title:
                    _spriteBatch.Draw(title, new Rectangle(0, 0, width, height), Color.White);
                    _spriteBatch.Draw(startBttn, bttn, Color.White);
                    break;
                case GameState.game:
                    _spriteBatch.Draw(storeBase, new Rectangle(0, 0, width, height), Color.White);
                    _spriteBatch.Draw(backCounter, new Rectangle(300, 125, 550, 100), Color.White);

                    coffeeMaker.Draw(gameTime);
                    player.Draw(gameTime);

                    if (interacted)
                    {
                        _spriteBatch.Draw(coffeeMakerTxr, new Rectangle(100, 0, width - 250, height), Color.White);
                    }
                    break;
                case GameState.menu:
                    break;
                case GameState.pause:
                    break;
                default:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ButtonPress(GameState nextState, MouseState mouse, Rectangle button)
        {
            if (mouse.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed && button.Contains(mouse.Position))
            {
                currState = nextState;
            }
        }

        private void Interact(MouseState mouse, Equipment item)
        {
            
            if (item.Pos.Contains(mouse.Position) && item.Pos.Intersects(player.Pos) && mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
            {
                interacted = !interacted;
            }

        }
    }
}
