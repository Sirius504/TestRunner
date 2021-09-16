using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSpeed", menuName = "Balance/GlobalSpeed")]
public class GlobalSpeedSettings : ScriptableObject
{
	public float StartSpeed => startSpeed;
	public float MaxSpeed => maxSpeed;
	public float TimeToReachMaxSpeed => timeToReachMaxSpeed;

	[SerializeField] private float startSpeed = 1f;
	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float timeToReachMaxSpeed = 60f;
}
