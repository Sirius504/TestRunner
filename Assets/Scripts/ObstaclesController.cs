using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
	public IEnumerable<Obstacle> Obstacles => obstacles;

	[SerializeField] private Obstacle obstaclePrefab;
	[SerializeField] private float spawnDelay = 0f;
	[SerializeField] private float spawnRate = 1f;
	[SerializeField] private Transform despawnBound;
	[SerializeField] private CharacterProvider characterProvider;

	private GameObjectPool<Obstacle> obstaclePool;
	private Queue<Obstacle> obstacles;

	// Start is called before the first frame update
	void Start()
	{
		obstaclePool = new GameObjectPool<Obstacle>(() => Instantiate(obstaclePrefab), null, 5, 5);
		obstacles = new Queue<Obstacle>();
		InvokeRepeating(nameof(Spawn), spawnDelay, spawnRate);
	}

	// Update is called once per frame
	void Update()
	{
		while (obstacles.Count > 0 && obstacles.Peek().transform.position.x < despawnBound.position.x)
		{
			var obstacleToDelete = obstacles.Dequeue();
			obstaclePool.ReleaseObject(obstacleToDelete);
		}
	}

	private void Spawn()
	{
		var obstacle = obstaclePool.GetObject();
		obstacle.transform.position = transform.position;
		// that breaks SRP (obstaclesController has no buiseness knowing
		// where SpeedProvider comes from) but I'm late on schedule
		// so I'm going to leave it that way
		obstacle.Init(characterProvider.SelectedCharacter.SpeedProvider);
		obstacles.Enqueue(obstacle);
	}
}
