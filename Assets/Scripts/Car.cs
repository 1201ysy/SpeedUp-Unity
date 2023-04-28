using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;

    private CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }



            if (transform.rotation.z < 0)
            {
                transform.Rotate(0, 0, 0.01f);
            }
            else if (transform.rotation.z > 0)
            {
                transform.Rotate(0, 0, -0.01f);
            }

            if (transform.position.y < -3.5f)
            {
                transform.position += Vector3.up * Time.deltaTime;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (cameraShake != null)
            {
                cameraShake.StartShake();
            }
            //Debug.Log("Ouch");


            Life.instance.GetHit();

            if (GameManager.instance.life == 0)
            {
                GameManager.instance.SetGameOver();
            }
        }

    }
}
