using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
 public SpriteRenderer spriteRenderer;
 public Animator animator;

 public Sprite character1Sprite;
 public Sprite character2Sprite;

 void Start()
 {
    int id = PlayerPrefs.GetInt("PlayerCharacter", 0);

 }

}
