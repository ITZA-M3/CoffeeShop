using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoffeeShop
{
    class Barista
    {
        private SpriteBatch sb;
        private Texture2D type;
        private Rectangle pos;

        public Barista(SpriteBatch sb, Texture2D type, Rectangle pos)
        {
            this.sb = sb;
            this.type = type;
            this.pos = pos;
        }

        public Rectangle Pos { get { return pos; } }

        public void Update(GameTime t, MouseState mouse, MouseState prevMouse)
        {
            MovePlayer(mouse, prevMouse);
        }

        public void Draw(GameTime t)
        {
            sb.Draw(type, pos, Color.White);
        }

        private void MovePlayer(MouseState mouse, MouseState prevMouse)
        {
            if (mouse.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
            {
                pos.X = mouse.Position.X - (75 / 2); // to get to the center of the sprite
                pos.Y = mouse.Position.Y / 2;
            }
        }
    }
}
