using UnityEngine;

[CreateAssetMenu(fileName = "Character",  menuName = "Balance/Character")]
public class CharacterSettings : ScriptableObject
{
	public string Name => characterName;
	public Color Color => color;
	public SpeedProviderBase SpeedProvider => speedProvider;

	[SerializeField] private Color color;
	[SerializeField] private SpeedProviderBase speedProvider;
	[SerializeField] private string characterName;
}
