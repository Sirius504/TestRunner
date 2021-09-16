using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGroupUI : MonoBehaviour
{
    [SerializeField] private Balance balance;
    [SerializeField] private CharacterUI prefab;
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private CharacterProvider characterProvider;

    private List<CharacterUI> characterUIs;

    // Start is called before the first frame update
    void Start()
    {
        characterUIs = new List<CharacterUI>();
        
        for (int i = 0; i < balance.Characters.Count; i++)
        {
            var ui = Instantiate(prefab, transform);
            ui.Refresh(balance.Characters[i]);
            int j = i;
            ui.Toggle.group = toggleGroup;
            ui.Toggle.onValueChanged.AddListener((isOn) => 
            {
                if (!isOn) return;
                characterProvider.SelectCharacter(j);
            } );
            characterUIs.Add(ui);
        }
    }
}
