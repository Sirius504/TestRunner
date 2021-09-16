using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
	[CreateAssetMenu(fileName = "LinearSpeed", menuName = "Balance/SpeedProviders/LinearSpeed")]
	class LinearSpeedProvider : SpeedProviderBase
	{
		public override float GetSpeed(float time)
		{
			return Mathf.Lerp(globalSpeedSettings.StartSpeed, globalSpeedSettings.MaxSpeed, time / globalSpeedSettings.TimeToReachMaxSpeed);
		}
	}
}
