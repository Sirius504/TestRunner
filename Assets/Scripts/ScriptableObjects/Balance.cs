using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Balance", menuName = "Balance/Main")]
class Balance : ScriptableObject
{
	public List<CharacterSettings> Characters => characters;
	public GlobalSpeedSettings GlobalSpeedSettings => globalSpeedSettings;

	[SerializeField] private List<CharacterSettings> characters;
	[SerializeField] private GlobalSpeedSettings globalSpeedSettings;
}

