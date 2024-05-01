using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player2 : MonoBehaviour
{
    public static Player2 instance;
    [SerializeField] private float moveSpeed;
    Vector2 input;
    Vector2 screenBoundaries;
    float objHeight;
    public int playerTwoScore;
    public float playerTwopert;

    private void Awake()
    {
        if(instance != null)
        {
            
        }
        instance = this;
    }
    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 1.6f;
        playerTwoScore = 0;
    }

    void Update()
    {
        Vector2 input = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            input.y -= 1;
        }
        input = input.normalized;
        Vector3 moveDir = new Vector3(0, input.y, 0);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y * -1 - objHeight, screenBoundaries.y + objHeight);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y * -1 + objHeight, screenBoundaries.y - objHeight);
        transform.position = viewPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Debug.Log("1");
            playerTwoScore += 1;
            Debug.Log("playertwoscore" + playerTwoScore);

        }
    }
}
