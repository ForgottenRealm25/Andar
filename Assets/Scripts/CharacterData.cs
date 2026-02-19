using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string characterName;


    [TextArea(3, 6)]
    public string biography;
    
    public Sprite portrait;
}
