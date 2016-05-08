using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnController : MonoBehaviour {

	[SerializeField]
	private List<Vector3> spawnPoints = new List<Vector3>();

	[SerializeField]
	private GameObject enemy;

	// Use this for initialization
	void Start () {
	
		SetSpawns ();
		SetEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetSpawns()
	{
		
		int mapHeight = MapController.Instance.MapHeight;
		int mapWidth = MapController.Instance.MapWidth;
		List<GameObject> tileList = MapController.Instance.FloorTilesList;

		for (int i = 0; i < tileList.Count; i++) 
		{
			FloorTile tile = tileList [i].transform.GetChild(0).GetComponent<FloorTile>();

			if (tile.XID == mapWidth - 1) {

				spawnPoints.Add(new Vector3(tile.transform.position.x + 1f, tile.transform.position.y, 0));
			}
		}

	}

	void SetEnemy()
	{
		for (int i = 0; i < spawnPoints.Count; i++) 
		{
			GameObject enemyInstance = Instantiate (enemy, spawnPoints [i], Quaternion.identity) as GameObject;
		}
	}


}
