using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Score;
    [SerializeField]
    public TextMeshProUGUI winMessage;

    public static int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        SetScore();
    }
   
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MovingPlatform"))
        {
            gameObject.transform.SetParent(transform, true);
        }
        if (collision.gameObject.CompareTag("Point"))
        {
            Destroy(collision.gameObject);
            score++;
        }
        if (collision.gameObject.tag == ("LevelOneOver"))
        {
            winMessage.SetText("Well Done !");
            SceneManager.LoadScene("GameScene");
            Debug.Log("GG");
        }
    }

    private void SetScore()
    {
        Score.text = score.ToString();
    }
}
