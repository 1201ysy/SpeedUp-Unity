using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Life : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    public static Life instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        scoreText.text = "LIFE " + GameManager.instance.life;
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);

    }

    public void GetHit()
    {
        GameManager.instance.life -= 1;

        scoreText.text = "LIFE " + GameManager.instance.life;

        if (GameManager.instance.life == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
        }
        else if (GameManager.instance.life == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        }

    }
}
