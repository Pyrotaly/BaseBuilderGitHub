using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World 
{
    //World has a defined amount of tiles
    Tile[,] tiles;

    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public World(int width = 100, int height = 100)
    {
        Width = width;
        Height = height;

        tiles = new Tile[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }

        Debug.Log($"World created with {width * height} tiles");
    }

    public Tile GetTileAt(int x, int y)
    {
        if (x > Width || x < 0 || y > Height || y < 0)
        {
            Debug.LogError($"Tile {x},{y} is out of range");
            return null; //prob crash in development
        }
        return tiles[x ,y];
    }
}
