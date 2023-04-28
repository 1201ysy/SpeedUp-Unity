using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreater : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles;

    [SerializeField] private float obstacleInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCreating();
    }


    private void StartCreating()
    {
        StartCoroutine("CreateObstacleRoutine");
    }

    public void StopCreating()
    {
        StopCoroutine("CreateObstacleRoutine");
    }

    IEnumerator CreateObstacleRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            CreateObstacle();
            yield return new WaitForSeconds(obstacleInterval);
        }
    }

    private void CreateObstacle()
    {
        Vector3 position = new Vector3(0, 0, 0);
        int index = Random.Range(0, obstacles.Length);

        if (index == 0) // Obstacle 1
        {
            position = new Vector3(-2.2f, 15f, 0);
        }
        else if (index == 1) // Obstacle 2
        {
            position = new Vector3(0, 15f, 0);
        }
        else if (index == 2) // Obstacle 3
        {
            position = new Vector3(-0.7f + Random.Range(-1, 3) * 1.44f, 15f, 0);
        }
        else if (index == 3) // Obstacle 4
        {
            position = new Vector3(2.1f, 15f, 0);
        }
        else if (index == 4) // Obstacle 5
        {
            position = new Vector3(-0.7f + (Random.Range(-1, 3) * 1.44f), 15f, 0);
        }

        Instantiate(obstacles[index], position, Quaternion.identity);
    }

    public void DecreaseObstacleInterval()
    {
        obstacleInterval -= 0.2f;
        if (obstacleInterval <= 1f)
        {
            obstacleInterval = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*


        if (index == 0) // Obstacle 1
        {
            position = new Vector3(-1.5f, 15f, 0);
        }
        else if (index == 1) // Obstacle 2
        {
            position = new Vector3(0.6f, 15f, 0);
        }
        else if (index == 2) // Obstacle 3
        {
            position = new Vector3(Random.Range(-1, 2) * 1.5f, 15f, 0);
        }
        else if (index == 3) // Obstacle 4
        {
            position = new Vector3(2.73f, 15f, 0);
        }
        else if (index == 4) // Obstacle 5
        {
            position = new Vector3(-0.1f + (Random.Range(-1, 2) * 1.44f), 15f, 0);
        }
        */