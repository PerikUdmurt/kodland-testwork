using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text gameStatusText;
    [SerializeField] private int totalEnemies;
    [SerializeField] GameObject restart_button;
    private int enemiesKilled = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Killed(string tag)
    {
        switch (tag)
        {
            case "Enemy":
                EnemyKilled();
                break;

            case "Player":
                PlayerDied();
                break;
        }
        
    }

    private void EnemyKilled()
    {
        enemiesKilled++;
        CheckGameStatus();
    }

    void CheckGameStatus()
    {
        if (enemiesKilled >= totalEnemies)
        {
            Victory();
        }
    }

    void Victory()
    {
        ShowEndGamePopup("Victory");
    }

    public void PlayerDied()
    {
        ShowEndGamePopup("You Lose!");
    }

    private void ShowEndGamePopup(string text)
    {
        restart_button.SetActive(true);
        gameStatusText.text = text;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
