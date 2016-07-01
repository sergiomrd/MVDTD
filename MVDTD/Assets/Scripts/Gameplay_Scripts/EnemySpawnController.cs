using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnController : MonoBehaviour
{

	public static EnemySpawnController Instance { get; private set;}

    private List<GameObject> enemiesPooledList = new List<GameObject>();

	[SerializeField]
	private List<Vector3> spawnPoints = new List<Vector3> ();

	[SerializeField]
	private GameObject enemy;

	[SerializeField]
	private int numberOfEnemies = 10;

	public int NumberOfEnemies {
		get {
			return numberOfEnemies;
		}
		set {
			numberOfEnemies = value;
		}
	}

	[SerializeField]
	private int currentEnemySpawned = 0;

	[SerializeField]
	private int numberOfWaves;

	public int NumberOfWaves {
		get {
			return numberOfWaves;
		}
		set {
			numberOfWaves = value;
		}
	}

	[SerializeField]
	private int currentWaveNumber = 1;

	private float timeBetweenSpawn = 2f;

	void Awake()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
	}

	// Use this for initialization
	void Start ()
	{
        SetSpawns();
        InitSpawn();
        InitEnemiesPool();

	}
	
	// Update is called once per frame
	void Update ()
	{
        /*
		if (currentWaveNumber < numberOfWaves) 
		{
			if (currentEnemySpawned == numberOfEnemies) 
			{
				currentWaveNumber++;
				currentEnemySpawned = 0;
			} 
			else 
			{
				timeBetweenSpawn -= Time.deltaTime;
				if (timeBetweenSpawn <= 0 && currentEnemySpawned < numberOfEnemies) 
				{
					SetEnemyAtRandom (enemy);
					timeBetweenSpawn = 2f;
				}
			}

		}
        */

	}

    void InitEnemiesPool()
    {
        GameObject pool = new GameObject("EnemiesPool");
        pool.transform.SetParent(this.gameObject.transform);

        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyInstance = Instantiate(enemy, gameObject.transform.position, Quaternion.identity) as GameObject;
            enemyInstance.transform.SetParent(pool.transform);
            enemyInstance.SetActive(false);
            enemiesPooledList.Add(enemyInstance);
        }
    }

    public void InitSpawn()
    {
        currentEnemySpawned = 0;
        currentWaveNumber = 0;
    }

    // Set the Spawns of the Enemies 
	void SetSpawns ()
	{
		int mapWidth = MapController.Instance.MapWidth;

		List<GameObject> tileList = MapController.Instance.FloorTilesList;

		for (int i = 0; i < tileList.Count; i++) {
			FloorTile tile = tileList [i].transform.GetChild (0).GetComponent<FloorTile> ();

			if (tile.XID == mapWidth - 1) {

				spawnPoints.Add (new Vector3 (tile.transform.position.x + 1f, tile.transform.position.y, 0));
			}
		}

	}

    // Can set the enemy on a spawn
    // TODO - Set an enemy in a location
	void SetEnemy ()
	{
		for (int i = 0; i < spawnPoints.Count; i++) {
			GameObject enemyInstance = Instantiate (enemy, spawnPoints [i], Quaternion.identity) as GameObject;
			enemyInstance.GetComponent<SpriteRenderer> ().sortingOrder = i;
		}
	}

	void SetEnemyAtRandom(GameObject enemyToInstantiate)
	{
		int random = Random.Range (0, spawnPoints.Count);
		Vector3 spawn = spawnPoints [random];
		GameObject enemyInstance = Instantiate (enemyToInstantiate, spawn, Quaternion.identity) as GameObject;
		enemyInstance.GetComponent<SpriteRenderer> ().sortingOrder = -random;
		currentEnemySpawned++;
	}

    void DestroyAllEnemies()
    {

    }

}
