using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed {get; private set; }

    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button homebutton;


    private Player player;
    private Spawner spawner;


    private float score;

     public int Score
    {
        get { return Mathf.FloorToInt(score); }
    }

    public int HighScore
    {
        get { return Mathf.FloorToInt(PlayerPrefs.GetFloat("hiscore", 0)); }
    }

    private void Awake()
    {
            Instance = this;
            DontDestroyOnLoad(gameObject);
    }
     
    private void OnDestroy() 
    {
        if(Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    public void NewGame()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        homebutton.gameObject.SetActive(false);

        UpdateHiscore();

        
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        homebutton.gameObject.SetActive(true);

        UpdateHiscore();

        ShowScoreboard();
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
           hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

       hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

    public void ShowScoreboard()
{
    enabled = false;
}

}
