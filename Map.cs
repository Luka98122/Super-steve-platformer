using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Super_steve_platformer
{
    public class Map
    {
        public enum TileType
        {
            Empty = 0,
            Grass = 1,
            Dirt = 2,
            LeftEdge = 3,
            RightEdge = 4,
            TopLeftEdge = 5,
            TopRightEdge = 6,
            BottomLeftEdge = 7,
            BottomRightEdge = 8,
            BottomMiddle = 9
        };

        public int width = 250;
        public int height = 30;
        public int tileSize = 16;

        public TileType [,]grid;

        public bool onPlatform(Vector2 v2)
        {

            v2.X = Convert.ToInt32(Game1.playerX);
            v2.Y = Convert.ToInt32(Game1.playerY);
            v2 = pixelCoordsToMapCoords(v2);
            if (grid[Convert.ToInt32(v2.X), Convert.ToInt32(v2.Y) + 1] != Map.TileType.Empty)
            {
                return true;
            }
            return false;
        }

        public Map()
        {
            System.Diagnostics.Debug.WriteLine("Map created");
        }

        public void initialize()
        {
            grid = new TileType[width, height];
            grid[0, 0] = TileType.Empty;
            for (int i = 0; i < width;i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = TileType.Empty;
                }
            }
            for ( int i = 0;i<width;i++)
            {
                for (int j = height-4; j < height; j++)
                {
                    grid[i, j ] = TileType.Grass;
                }
            }

        }
        public void save(string fileName)
        {
            throw new Exception("Not updated to handle new tile types");
            using(StreamWriter writeText = new StreamWriter(fileName))
            {
                for(int y = 0; y < height;y++)
                {
                    for(int x = 0;x<width;x++)
                    {
                        char c;
                        if (grid[x, y] == TileType.Empty)
                        {
                            c = '.';
                        }
                        else if (grid[x, y] == TileType.Grass)
                        {
                            c = 'X';
                        }
                        
                        else
                            throw new Exception("unknown tile type");
                        writeText.Write(c);
                    }
                    writeText.WriteLine("");
                }
                //writeText.WriteLine(grid);
            }
        }
        public void load(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {
                        int c;
                        c = streamReader.Read();
                        TileType o;
                        switch(c)
                        {
                            case '.':
                                o = TileType.Empty;
                                break;
                            case 'T':
                                o = TileType.Grass;
                                break;
                            case 'X':
                                o = TileType.Dirt;
                                break;
                            case 'Q':
                                o = TileType.LeftEdge;
                                break;
                            case 'E':
                                o = TileType.RightEdge;
                                break;
                            case 'A':
                                o = TileType.TopLeftEdge;
                                break;
                            case 'D':
                                o = TileType.TopRightEdge;
                                break;
                            case 'Z':
                                o = TileType.BottomLeftEdge;
                                break;
                            case 'C':
                                o = TileType.BottomRightEdge;
                                break;
                            case 'O':
                                o = TileType.BottomMiddle;
                                break;
                            default:
                                throw new Exception("Unkown character in file " + c);

                        }

                        grid[x, y] = o;
                    }
                    streamReader.Read();
                    streamReader.Read();
                }
            }
        }
        public Vector2 pixelCoordsToMapCoords (Vector2 pixelCoords)
        {
            Vector2 v = new Vector2();
            v.X = pixelCoords.X / tileSize;
            v.Y = pixelCoords.Y / tileSize;
            return v;
        }
        public Vector2 mapCoordsToPixelCoords (int x, int y)
        {
            Vector2 v = new Vector2();
            v.X = x * tileSize;
            v.Y = y * tileSize;
            return v;
        }
    }
}