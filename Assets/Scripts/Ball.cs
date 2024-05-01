using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int forceX,forceY;
    Rigidbody2D rb;
    public int player1Deaths;
    public int player2Deaths;
    public ParticleSystem particleSystem;
    void Start()
    {
        

        int randomDirection = Random.Range(0, 2);
        if(randomDirection == 0)
        {
            forceX = -4;
        }
        else
        {
            forceX = 4;
        }
        Debug.Log("force" + forceX);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(forceX, forceY);
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.transform.tag == "Player1")
        {
            Instantiate(particleSystem.gameObject, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Player2")
        {

            Instantiate(particleSystem.gameObject, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
