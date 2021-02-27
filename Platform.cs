using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super_steve_platformer
{
    public class Platform 
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public void initialize (int a, int a2, int Width, int Height)
        {
            x = a;
            y = a2;
            width = Width;
            height = Height;
            Rectangle platform = new Rectangle(x, y, width, height);
        }

        

        public void update ()
        {

        }

    }
   
}
