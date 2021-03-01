using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace Super_steve_platformer
{
    public class MapRenderer
    {
        public float cameraX = 5f;
        public float cameraY = 0f;
        public float cameraWidth = 50f;
        public float cameraHeight = 30f;

        Texture2D platform;
        public void Initialize (ContentManager content)

        {
            platform = content.Load<Texture2D>("FloatingPlatformTake2");
        }

        public void update()
        {

        }



        public void draw(Map map, SpriteBatch spriteBatch)
        {
            int drawX = 0;
            for(float y = cameraY; y < cameraY+cameraHeight; y++)
            {
                for(float x = cameraX;x < cameraX + cameraWidth; x++)
                {
                    if ( map.grid[Convert.ToInt32(x),Convert.ToInt32(y)] == Map.TileType.Platform)
                    {
                        
                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        spriteBatch.Draw(platform, v2, Color.White);
                        
                    }
                    drawX++;
                }
                drawX = 0;
            }
        }


    }
}
