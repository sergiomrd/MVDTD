using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

	public GameObject NormalTilePrefab;

	private int mapWidth = 9;
	private int mapHeight = 5;

	private float yOffset = 0.375f;
	private float xOffset = 0.78f;
	private float newXOffset;

	void Start () {

		CreateMap();

	}

	void Update () {
	
	}

	void CreateMap()
	{
		//TODO: Adapt for more tile types
		for (int x = 0; x < mapWidth; x++) {
			
			newXOffset = 0.375f;

			for (int y = 0; y < mapHeight; y++) {

				if(y != 0)
				{ 
					GameObject normalTile = Instantiate(NormalTilePrefab, new Vector2((x * xOffset) + (newXOffset), y * yOffset), Quaternion.identity) as GameObject;
					newXOffset += xOffset/2;
					normalTile.name = ("Tile" + "_" + x + "_" + y);
				}
				else
				{
					GameObject normalTile = Instantiate(NormalTilePrefab, new Vector2(x * xOffset, y * yOffset), Quaternion.identity) as GameObject;
					normalTile.name = ("Tile" + "_" + x + "_" + y);
				}
					

			}
		}
	}
}
