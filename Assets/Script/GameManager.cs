using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPopup;
    public GameObject player;
    public GameObject prefabsWin;
    public PlayerController pscript;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public int highScore = 0;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverScoreText;

    public Transform spawnArea;
    [Header("Cài đặt Spawn")]
    public GameObject[] randomPrefabs;
    public float minX, maxX, minY, maxY;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        prefabsWin.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int amountToAdd)
    {
        score += amountToAdd; // Tăng điểm
        UpdateScoreText(); // Cập nhật lại UI hiển thị
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void SpawnRandomPrefab()
    {
        if (randomPrefabs.Length == 0)
        {
            Debug.LogWarning("Danh sách Prefab trong GameManager đang trống!");
            return;
        }

        int randomIndex = Random.Range(0, randomPrefabs.Length);
        GameObject selectedPrefab = randomPrefabs[randomIndex];

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0.2f , Random.Range(minY, maxY));

        Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
    }

    public bool UpdateHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            
            UpdateHighScoreText();
            return true;
        }
        return false;
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void OnEnable()
    {
        DeadWall.OnPlayerDied += ShowOver;
    }

    public void OnDisable()
    {
        DeadWall.OnPlayerDied -= ShowOver;
    }

    public void ShowOver()
    {
        gameOverPopup.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = "Score: " + score;
        bool isNewHighScore = UpdateHighScore(score);
        if (isNewHighScore)
        {
            prefabsWin.SetActive(true);
            AudioManager.Instance.WinSFX();
        }
        else
        {
            AudioManager.Instance.LoseSFX();
        }
        player.transform.localScale = new Vector3(player.transform.localScale.x, 0.01f, player.transform.localScale.z);
        pscript.enabled = false;
        Invoke("PauseGame", 2f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    [ContextMenu("Xóa toàn bộ Data")]
    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Đã xóa sạch PlayerPrefs!");
    }
}
