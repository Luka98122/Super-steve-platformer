using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super_steve_platformer
{
    class SpriteSheetBlockPicker
    {
        public void draw(int x, int y, Texture2D spriteSheet, SpriteBatch spriteBatch, int u, int v)
        {
            Rectangle rect = new Rectangle();
            rect.X = x*14;
            rect.Y = x*14;
            rect.Width = 14;
            rect.Height = 14;

            Rectangle rect2 = new Rectangle();
            rect2.X = u * 17;
            rect2.Y = v * 17;
            rect2.Width = 16;
            rect2.Height = 16;
            spriteBatch.Draw(spriteSheet, rect, rect2, Color.White);
        }
    }
}
