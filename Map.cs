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
            Platform = 1
        };

        int width = 250;
        int height = 30;

        public TileType [,]grid;

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
                    grid[i, j ] = TileType.Platform;
                }
            }

        }
        public void save(string fileName)
        {
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
                        else if (grid[x, y] == TileType.Platform)
                        {
                            c = 'X';
                        } else
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
                            case 'X':
                                o = TileType.Platform;
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
            v.X = pixelCoords.X / 14;
            v.Y = pixelCoords.Y / 14;
            return v;
        }
        public Vector2 mapCoordsToPixelCoords (int x, int y)
        {
            Vector2 v = new Vector2();
            v.X = x * 14;
            v.Y = y * 14;
            return v;
        }
    }
}
