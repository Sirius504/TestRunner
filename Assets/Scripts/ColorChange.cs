using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
	[SerializeField] private CharacterProvider characterProvider;

	private void Start()
	{
		renderer.color = characterProvider.SelectedCharacter.Color;
	}
}
