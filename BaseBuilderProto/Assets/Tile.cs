using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    enum TileType { Empty, Floor };

    TileType type = TileType.Empty;

    LooseObject looseObject;
    InstalledObject installedObject;

    //Tile knows where it is
    World world;
    int x;
    int y;

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }
}
