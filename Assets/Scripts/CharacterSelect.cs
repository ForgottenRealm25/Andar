using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TelaInicial");
        }
    }
    public void SelectCharacter(int id)
    {
        PlayerPrefs.SetInt("PlayerCharacter", id);
        SceneManager.LoadScene("Andar");
    }
}
