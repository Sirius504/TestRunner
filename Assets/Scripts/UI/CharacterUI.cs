using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
	public Toggle Toggle => toggle;

	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI name;
	[SerializeField] private Toggle toggle;
	public void Refresh(CharacterSettings character)
	{
		image.color = character.Color;
		name.text = character.Name;		
	}
}
