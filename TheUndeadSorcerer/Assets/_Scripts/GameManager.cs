using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemiesKilledCount = 0;
    private int enemiesKilledGoal = 10;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject levelCompletedCanvas;
    [SerializeField] TextMeshProUGUI enemiesKilledCounterTxt;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemiesKilledCounterTxt.text = "Enemies Killed: " + enemiesKilledCount.ToString() + "/" + enemiesKilledGoal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        enemiesKilledCount++;
        enemiesKilledCounterTxt.text = "Enemies Killed: " + enemiesKilledCount.ToString() + "/" + enemiesKilledGoal.ToString();

        if(enemiesKilledCount == enemiesKilledGoal)
        {
            LevelCompleted();
        }
    }

    public void LevelCompleted()
    {
        levelCompletedCanvas.SetActive(true);
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
