using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Empty, Floor };

    private TileType _type = TileType.Empty;

    Action<Tile> cbTileTypeChanged;

    public TileType Type { 
        get { return _type; } 
        set 
        {
            TileType oldType = _type;
            _type = value; 

            //Call callback if tile has been changed
            if (cbTileTypeChanged != null && oldType != Type) 
                cbTileTypeChanged(this); 
        } 
    }

    LooseObject looseObject;
    InstalledObject installedObject;

    //Tile knows where it is
    World world;
    public int x { get; private set; }
    public int y { get; private set; }

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void RegisterTileTypeChangedCallBack(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }

    public void UnregisterTileTypeChangedCallBack(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }
}
