using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoffeeShop
{
    class Equipment
    {
        private SpriteBatch sb;
        private string name;
        private Texture2D type;
        private Rectangle pos;

        public Equipment(SpriteBatch sb, Texture2D type, string name, Rectangle pos)
        {
            this.sb = sb;
            this.type = type;
            this.name = name;
            this.pos = pos;
        }

        public Rectangle Pos { get { return pos; } }

        public void Draw(GameTime t)
        {
            sb.Draw(type, pos, Color.White);
        }
    }
}
