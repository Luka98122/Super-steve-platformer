using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super_steve_platformer
{
    public class SpriteSheetBlockPicker
    {
        public void draw(Vector2 v2, Texture2D spriteSheet, SpriteBatch spriteBatch, int tileX, int tileY, int pixelOffSet)
        {
            Rectangle rectLocation = new Rectangle();
            rectLocation.X = Convert.ToInt32(v2.X)*Game1.map.tileSize;
            rectLocation.Y = Convert.ToInt32(v2.Y)*Game1.map.tileSize;
            rectLocation.Width = Game1.map.tileSize;
            rectLocation.Height = Game1.map.tileSize;

            Rectangle rectSource = new Rectangle();
            rectSource.X = tileX * 17;
            rectSource.Y = tileY * 17;
            rectSource.Width = 16;
            rectSource.Height = 16;
            spriteBatch.Draw(spriteSheet, rectLocation, rectSource, Color.White);
        }

    }
}
