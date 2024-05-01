using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class VerticalLeft : MonoBehaviour
{
    public GameObject ball;
    public int player1Deaths;
    public static bool death;
    public GameObject circle;
    public static int round;
    public TextMeshProUGUI roundText;

    [SerializeField] private Slider slider;
    float maxHealth = 100;
    float health;
    private void Start()
    {
        round = 1;
        health = maxHealth;
        death = false;
        player1Deaths = 0;
        StartCoroutine(Round());
        
    }
    

    private void Update()
    {
        if (death == true && round < 4)
        {
            Debug.Log("spawn");
            StartCoroutine(Round());
            death = false;
            return;
        }
        if (slider.value != health)
        {
            slider.value = Mathf.Lerp(slider.value, health, Time.deltaTime * 3f);
        }

        if (player1Deaths >= 3)
        {
            Debug.Log("Player2Wins");
            SceneManager.LoadScene(2);
        }
        if (round > 3)
        {
            StartCoroutine(GameOver());
        }


    }
    IEnumerator GameOver()
    {
        Debug.Log("GameOver");
        roundText.text = "GameOver";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    IEnumerator Round()
    {
        roundText.text = "Round" + round;
        yield return new WaitForSeconds(2);
        roundText.text = "";

        Debug.Log("round" + round);
        yield return new WaitForSeconds(2f);
        Instantiate(ball, circle.transform.position, transform.rotation);
        //round++;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Player2.instance.playerTwoScore += 5;
            Debug.Log("Dead"); player1Deaths++; Debug.Log("" + player1Deaths);
            death = true; Debug.Log("" + death);
            takeDamage(33);
            round++;

        }

    }
    void takeDamage(float damage)
    {
        health = (health - damage);
    }
    
}
