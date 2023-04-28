using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    //[SerializeField] private float moveSpeed = 5f;
    private float posY = 7.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * GameManager.instance.moveSpeed * Time.deltaTime;
        if (transform.position.y <= -posY)
        {
            transform.position += new Vector3(0, posY * 2, 0);
        }
    }

}
