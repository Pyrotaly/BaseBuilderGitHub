using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldController : MonoBehaviour
{
    public Sprite FloorSprite;

    World world;

    // Start is called before the first frame update
    void Start()
    {
        //Create world with empty tiles
        world = new World();
        world.RandomizeTiles();

        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);

                GameObject tile_go = new GameObject();
                tile_go.name = $"Tile_{x},{y}";
                tile_go.transform.position = new Vector3(tile_data.x, tile_data.y, 0);
                tile_go.transform.SetParent(this.transform, true);

                //Adds sprite renderer to all empty tiles
                SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();

                //A function that runs another function that can have both Tile and GameObject in parameter
                tile_data.RegisterTileTypeChangedCallBack( (tile) => { OnTileTypeChanged(tile, tile_go); }  );

                //if(tile_data.Type == Tile.TileType.Floor)
                //{
                //    //tile_sr.sprite = floorSprite
                //}
            }
        }

        world.RandomizeTiles();
    }

    void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {
        if (tile_data.Type == Tile.TileType.Floor)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = FloorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged - Unrecognized tile type");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
