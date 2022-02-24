using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int lives = 3;

    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text bricksText;

    int numOfBricks;

    bool gameOver;

    public GameObject gameOverUI;

    void Awake()
    {
        livesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        bricksText.text = "Bricks: " + numOfBricks.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.anyKey) 
            Restart();
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
            GameOver();
    }

    public void HitBrick()
    {
        numOfBricks--;
        bricksText.text = "Bricks: " + numOfBricks.ToString();

        if (numOfBricks <= 0)
            Invoke("NextLevel", 1f);
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            SceneManager.LoadScene("Level01");
        }
        else
        {
            SceneManager.LoadScene("Level02");
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
    }


}
