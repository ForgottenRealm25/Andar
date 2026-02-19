using UnityEngine;

public class CharacterBotao : MonoBehaviour
{
    public CharacterSelect characterSelect;
    public int characterId;
    public void OnClick()
    {
        characterSelect.ShowCharacter(characterId);
    }
}
