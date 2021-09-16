using UnityEngine;
using UnityEngine.Events;

public class CollisionsController : MonoBehaviour
{
	public UnityEvent OnCollision;

	[SerializeField] private CircleCollider2D playerCollider;
	[SerializeField] private ObstaclesController obstaclesController;

	private float playerLeftSide;
	private float playerRightSide;

	private void Awake()
	{
		playerLeftSide = playerCollider.transform.position.x - playerCollider.radius;
		playerRightSide = playerCollider.transform.position.x + playerCollider.radius;
	}

	// Here we assume that obstacles provided by obstaclesController are
	// sorted by distance from the player. We also assume, that
	// obstacles are moving with same speed, so they will stay ordered
	// after being spawned. If any of this is to change, then new
	// approach (something like KD-Tree structure and nearest
	// neighbour algorithm) will be necessary.	
	private void Update()
	{
		foreach (var obstacle in obstaclesController.Obstacles)
		{
			var collider = obstacle.Collider;

			// cutting off far right colliders; if that's true
			// this collider and all after him are too far
			// right to consider collision
			if (playerRightSide < collider.bounds.min.x)
				break;

			// collider has passed the player
			if (playerLeftSide > collider.bounds.max.x)			
				continue;

			// collider is in player X range
			Bounds bounds = collider.bounds;
			Vector2 playerPosition = playerCollider.transform.position;
			Vector2 colliderPosition = collider.transform.position;
			Vector2 point = playerPosition + (colliderPosition - playerPosition).normalized * playerCollider.radius;
			
			if (bounds.Contains(point))
				OnCollision?.Invoke();
		}
	}
}
