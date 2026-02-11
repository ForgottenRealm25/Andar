using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
 [Header("Visual")]
 public SpriteRenderer spriteRenderer;
 public Animator animator;

 [Header("Personagem 1")]
 public Sprite character1Sprite;
 public RuntimeAnimatorController character1Animator;

 [Header("Personagem 2")]
 public Sprite character2Sprite;
 public RuntimeAnimatorController character2Animator;

 void Start()
 {
    int id = PlayerPrefs.GetInt("PlayerCharacter", 0);

    if(id==0)
      {
         spriteRenderer.sprite = character1Sprite;
         animator.runtimeAnimatorController = character1Animator;
      }
      else if(id==1)
      {
         spriteRenderer.sprite = character2Sprite;
         animator.runtimeAnimatorController = character2Animator;
      }
 }

}
