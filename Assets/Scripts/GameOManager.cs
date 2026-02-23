using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI winnerText;
    public static GameOManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void EndGame(string winnerName)
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        winnerText.text = winnerName + " WINS!";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void VoltarSeleção()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CharacterSelect");
    }
}