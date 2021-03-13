using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super_steve_platformer
{
    public class PlayerAnimator
    {
        public Texture2D spriteSheet;
        int spriteStrideX = 23;
        int spriteSheetGutterX = 16;
        public void initialize (Texture2D texture2D)
        {
            spriteSheet = texture2D;
        }

        public void draw(Vector2 v2, SpriteBatch spriteBatch, int spriteX, int spriteY)
        {
            Rectangle rectLocation = new Rectangle();
            rectLocation.X = Convert.ToInt32(v2.X);
            rectLocation.Y = Convert.ToInt32(v2.Y);
            rectLocation.Width = 36*4;
            rectLocation.Height = 64*4;

            Rectangle rectSource = new Rectangle();
            rectSource.X = (spriteX * spriteStrideX) + spriteSheetGutterX;
            rectSource.Y = spriteY * 20;
            rectSource.Width = 25;
            rectSource.Height = 44;
            System.Threading.Thread.Sleep(30);
            spriteBatch.Draw(spriteSheet, rectLocation, rectSource, Color.White);
        }
    }
}
