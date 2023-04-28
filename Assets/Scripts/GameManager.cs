using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject gameOverPanel;

    public float moveSpeed = 5f;

    private int difficulty = 0;
    public int life = 3;



    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDifficulty()
    {
        difficulty += 1;

        if (difficulty % 10 == 0)
        {
            ObstacleCreater creater = FindObjectOfType<ObstacleCreater>();
            if (creater != null)
            {
                creater.DecreaseObstacleInterval();
                //Debug.Log("PoopInterval decreased");
            }

            moveSpeed += 1f;
            if (moveSpeed >= 10f)
            {
                moveSpeed = 10f;
            }
        }
    }


    public void SetGameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;

            ObstacleCreater creater = FindObjectOfType<ObstacleCreater>();
            if (creater != null)
            {
                creater.StopCreating();
                //Debug.Log("PoopInterval decreased");
            }

            moveSpeed = 0f;

            StartCoroutine("ShowGamePanel");
        }

    }

    IEnumerator ShowGamePanel()
    {
        yield return new WaitForSeconds(1f);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        life = 3;
        SceneManager.LoadScene("GameScene");
    }

    public void returnHome()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
