using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        #endregion

        private GameState currState;

        // used to hold game window measurements
        private int width;
        private int height;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            title = this.Content.Load<Texture2D>("CoffeeTitle");
        }

        protected override void Update(GameTime gameTime)
        {
            // switches scenes
            switch (currState)
            {
                case GameState.title:
                    break;
                case GameState.game:
                    break;
                case GameState.menu:
                    break;
                case GameState.pause:
                    break;
                default:
                    break;
            }

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
                    break;
                case GameState.game:
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

        private void ButtonPress(GameState nextState)
        {
            currState = nextState;
        }
    }
}
