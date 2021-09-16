using UnityEngine;

public class Obstacle : MonoBehaviour, IPoolable
{
    public BoxCollider2D Collider => collider;

    [SerializeField] private BoxCollider2D collider;

	private SpeedProviderBase speedProvider;

	public void Init(SpeedProviderBase speedProvider)
	{
		this.speedProvider = speedProvider;
	}

	// Update is called once per frame
	private void Update()
    {
		float speed = speedProvider.GetSpeed(Time.timeSinceLevelLoad);
		transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

	public void PoolReset() 
	{
		speedProvider = null;
	}
}
