using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
	[CreateAssetMenu(fileName = "QuadraticSpeed", menuName = "Balance/SpeedProviders/QuadraticSpeed")]
	class QuadraticSpeedProvider : LinearSpeedProvider
	{
		public override float GetSpeed(float time)
		{
			float halfTime = globalSpeedSettings.TimeToReachMaxSpeed / 2f;
			if (time <= halfTime)
				return base.GetSpeed(time);

			float t = (time - halfTime) / halfTime;
			float v0 = base.GetSpeed(halfTime);
			float v1 = globalSpeedSettings.MaxSpeed;
			return Mathf.Clamp(Mathf.Lerp(v0, v1, t * t), v0, v1);
		}
	}
}
