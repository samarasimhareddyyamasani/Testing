using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VerticalRight : MonoBehaviour
{
    public GameObject ball;
    public int player2Deaths;
    public GameObject circle;

    [SerializeField] private Slider slider;
    float maxHealth = 100;
    float health;
    private void Start()
    {
        player2Deaths = 0; health = maxHealth;
    }

    private void Update()
    {
        
        if (player2Deaths >= 3)
        {
            Debug.Log("Player1Wins");
            SceneManager.LoadScene(2);
        }
        if (slider.value != health)
        {
            slider.value = Mathf.Lerp(slider.value, health, Time.deltaTime * 3f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Player1.instance.playerOneScore += 5;
            Debug.Log("Dead"); player2Deaths++; Debug.Log("" + player2Deaths);
            VerticalLeft.death = true; Debug.Log("" + VerticalLeft.death);
            takeDamage(33);
            VerticalLeft.round++;
        }

    }
    void takeDamage(float damage)
    {
        health =(health - damage);
    }
    
}
