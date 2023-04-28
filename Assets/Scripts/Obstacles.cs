using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * GameManager.instance.moveSpeed * Time.deltaTime;
        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
            GameManager.instance.AddDifficulty();
        }
    }



    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         Debug.Log("Ouch");
    //     }

    // }
}
