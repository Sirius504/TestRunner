using UnityEngine;

class JumpController : MonoBehaviour
{
	[SerializeField] private float jumpHeight;
	[SerializeField] private float gravity = 9.80665f;

	private float groundLevel;
	private float jumpStartTime;
	private float jumpInitialSpeed;
	private bool isJumping = false;
	private float timeToJump;

	private void Awake()
	{		
		jumpInitialSpeed = Mathf.Sqrt(-2 * jumpHeight * gravity);
		timeToJump = 2 * jumpInitialSpeed / -gravity;
		groundLevel = transform.position.y;
	}

	private void Update()
	{
#if UNITY_ANDROID && !UNITY_EDITOR
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isJumping)
#else
		if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
#endif
		{
			jumpStartTime = Time.time;
			isJumping = true;
		}

		if (isJumping) HandleJump();
	}

	private void HandleJump()
	{
		if (!isJumping)
			return;
		
		Vector3 newPosition = transform.position;
		float jumpTime = Time.time - jumpStartTime;
		isJumping = jumpTime < timeToJump;
		newPosition.y = isJumping
			? groundLevel + GetJumpDisplacement(jumpTime)
			: groundLevel;
		
		transform.position = newPosition;
	}

	private float GetJumpDisplacement(float time)
	{
		return jumpInitialSpeed * time + gravity * time * time / 2;
	}
}

