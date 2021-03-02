using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Net.Mime;
using System.Text;

namespace Super_steve_platformer
{
    public class MapRenderer
    {
        public float cameraX = 5f;
        public float cameraY = 0f;
        public float cameraWidth = 57f;
        public float cameraHeight = 30f;

        Texture2D platform;
        public void Initialize (ContentManager content)

        {
            platform = content.Load<Texture2D>("FloatingPlatformTake2");
            cameraWidth = Game1.game.graphics.PreferredBackBufferWidth/Game1.map.tileSize;
            cameraHeight = Game1.game.graphics.PreferredBackBufferWidth / Game1.map.tileSize;
        }

        public void update()
        {

        }



        public void draw(Map map, SpriteBatch spriteBatch, SpriteSheetBlockPicker sheetBlockPicker, Texture2D spritesheet)
        {
            int drawX = 0;
            for(float y = cameraY; y < cameraY+cameraHeight && y<map.height; y++)
            {
                for(float x = cameraX;x < cameraX + cameraWidth; x++)
                {
                    if ( map.grid[Convert.ToInt32(x),Convert.ToInt32(y)] == Map.TileType.Grass)
                    {
                        
                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 1, 0);
                        
                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.Dirt)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 1, 1);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.LeftEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 0, 1);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.RightEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 2, 1);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.TopLeftEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 0, 0);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.TopRightEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 2, 0);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.BottomLeftEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 0, 2);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.BottomRightEdge)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 2, 2);

                    }

                    if (map.grid[Convert.ToInt32(x), Convert.ToInt32(y)] == Map.TileType.BottomMiddle)
                    {

                        Vector2 v2 = new Vector2(drawX, Convert.ToInt32(y));
                        //v2 = map.mapCoordsToPixelCoords(drawX, Convert.ToInt32(y));
                        //spriteBatch.Draw(platform, v2, Color.White);
                        sheetBlockPicker.draw(v2, spritesheet, spriteBatch, 1, 2);

                    }
                    drawX++;
                }
                drawX = 0;
            }
        }


    }
}
