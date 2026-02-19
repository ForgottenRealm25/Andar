using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{

    public Animator panelAnimator;

    [Header("UI")]
    public Image portrait;
    public TMP_Text nameText;
    public TMP_Text bioText;
    public Button confirmButton;

    [Header("Characters")]
    public CharacterData[] characters;

    [Header("Painel")]
    public GameObject characterPanel;

    private int selectedId = -1;

    void Start()
    {
        confirmButton.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TelaInicial");
        }
    }

    public void ShowCharacter(int id)
    {
        CharacterData data = characters[id];

        selectedId = id;

        characterPanel.SetActive(true);
        panelAnimator.SetTrigger("Show");

        portrait.sprite = data.portrait;
        nameText.text = data.characterName;
        bioText.text = data.biography;

        confirmButton.gameObject.SetActive(true);
    }
    public void ConfirmCharacter()
    {
        PlayerPrefs.SetInt("PlayerCharacter", selectedId);
        SceneManager.LoadScene("Andar");
    }
}
