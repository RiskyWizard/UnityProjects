using UnityEngine;
using UnityEngine.Tilemaps;

/* 
 * seeing if I can create a tilemap entirely through script.
 * turns out I can, but it's probably easier in editor.
 */

public class MapGenerator : MonoBehaviour {

    GameObject GridObject;
    Grid grid;
    GameObject FloorObject,WallObject;
    Tilemap floor,wall;
    public Tile floorTile, N,S,E,W,NE,NW,SE,SW;

    int width = 17;
    int height = 11;

    void Start() {
        GridObject = new GameObject("Grid");
        grid = GridObject.AddComponent<Grid>();
        grid.cellSize = new Vector3(1,1,0); 

        FloorObject = new GameObject("Floor");
        WallObject = new GameObject("Wall");
        floor = FloorObject.AddComponent<Tilemap>();
        FloorObject.AddComponent<TilemapRenderer>();
        FloorObject.transform.parent = GridObject.transform;
        wall = WallObject.AddComponent<Tilemap>();
        WallObject.AddComponent<TilemapRenderer>();
        WallObject.AddComponent<TilemapCollider2D>();
        WallObject.transform.parent = GridObject.transform;
        
        /*
         * this is a hella messy way to do it.  I don't like it.
         * I think creating maps via TileMaps is probably better to do 
         * in the Unity Editor, than with scripting.
         * although, for platformer style games, it'd be much easier
         * in script than topdown view.
         *
         */
        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                if(i == 0 && j == 0) {
                    wall.SetTile(new Vector3Int(i,j,0),SW);
                }
                else if(i == width-1 && j == 0)
                {
                    wall.SetTile(new Vector3Int(i,j,0),SE);
                }
                else if(i == 0 && j == height-1)
                {
                    wall.SetTile(new Vector3Int(i,j,0),NW);
                }
                else if(i == width-1 && j == height-1)
                {
                    wall.SetTile(new Vector3Int(i,j,0),NE);
                }
                else if(i == 0) {
                    wall.SetTile(new Vector3Int(i,j,0),W);
                }
                else if(i == width-1) {
                    wall.SetTile(new Vector3Int(i,j,0),E);
                }
                else if(j == 0) {
                    wall.SetTile(new Vector3Int(i,j,0),S);
                }
                else if(j == height-1) {
                    wall.SetTile(new Vector3Int(i,j,0),N);
                }
                else {
                    floor.SetTile(new Vector3Int(i,j,0),floorTile);
                }
            }
        }

        GameObject.FindWithTag("Player").transform.position = new Vector3(width/2,height/2,0);
    }

    void Update() {
    }

}
