using UnityEngine;

public class CharacterProvider : MonoBehaviour
{
	public CharacterSettings SelectedCharacter { get; private set; }

	[SerializeField] private Balance balance;
	private static string prefsCharacterKey = "character";

	// Start is called before the first frame update
	void Awake()
	{
		int i = PlayerPrefs.GetInt(prefsCharacterKey, -1);
		SelectCharacter(i != -1 ? i : 0);
	}

	public void SelectCharacter(int index)
	{
		SelectedCharacter = balance.Characters[index];
		PlayerPrefs.SetInt(prefsCharacterKey, index);
		Debug.Log($"Character selected: {SelectedCharacter.Name}");
	}
}
