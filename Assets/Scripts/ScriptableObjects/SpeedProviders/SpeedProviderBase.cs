using UnityEngine;

public abstract class SpeedProviderBase : ScriptableObject
{
	[SerializeField] protected GlobalSpeedSettings globalSpeedSettings;

	public abstract float GetSpeed(float time);
}

