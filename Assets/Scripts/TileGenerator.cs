using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

	public GameObject Wall;
	public GameObject Floor;

	public enum tileType
	{
		Empty, Wall, Floor, Turret
	}

	public string seed;

	public int height;
	public int width;

	public float tileSize;
	public float tileOffset;

	[Range (0f, 0.3f)]
	public float wallsPercent;
	public int turrentsAmount;

	public tileType[,] tileArray;
	public Tile[,] tiles;

	// Use this for initialization
	void Start () {
		tileArray = new tileType[width, height];
		//tiles = new Tile[width, height];

		GetRandomTiles ();
		CreateTilesFromArray (tileArray);
		print("created");
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void GetRandomTiles(){
		System.Random random = new System.Random (seed.GetHashCode());

		for(int i = 0; i < width; i++){
			for (int j = 0; j < height; j++) {
				if (random.NextDouble() < wallsPercent) {
					tileArray [i, j] = tileType.Wall;
				} else {
					tileArray [i, j] = tileType.Floor;
				}
			}
		}
	}

	public void CreateTilesFromArray(tileType[,] tileArray){
		int x = tileArray.GetLength (0);
		int y = tileArray.GetLength (1);

		tiles = new Tile[x, y];

		Vector3 beginningPosition = new Vector3 (tileSize * -width / 2 + tileSize / 2, 0, tileSize * -height / 2 + tileSize / 2);

		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
					
				Vector3 position = beginningPosition + Vector3.right * tileSize * i + Vector3.forward * tileSize * j;
				GameObject tile = GameObject.Instantiate(Floor, position, transform.rotation) as GameObject;
				tile.transform.localScale = new Vector3(tileSize - tileOffset, 1, tileSize - tileOffset) ;
			}
		}
	}
}
