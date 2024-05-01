using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player1 : MonoBehaviour
{
    public static Player1 instance;
    [SerializeField] private float moveSpeed;
    Vector2 input;
    Vector2 screenBoundaries;
    float objHeight;
    public int playerOneScore,OneScore, TwoScore,totalScore;
    public float playerOnepert;
    public TextMeshProUGUI percentOne;
    public TextMeshProUGUI percentTwo;

    private void Awake()
    {
        if (instance != null)
        {
           
        }
        instance = this;
    }
    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 1.6f;
        playerOneScore = 0;
    }

    void Update()
    {
        OneScore = playerOneScore;
        TwoScore = Player2.instance.playerTwoScore;

        input = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input.y -= 1;
        }
        input = input.normalized;
        Vector3 moveDir = new Vector3(0, input.y, 0);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (VerticalLeft.death == true)
        {
            totalScore = (OneScore + TwoScore);
            Debug.Log("totalScore" + totalScore);
            playerOnepert = ((float)OneScore / totalScore) * 100f;
            Player2.instance.playerTwopert = ((float)TwoScore / totalScore) * 100f;

            
            StartCoroutine(Scores());
        }

    }
    IEnumerator Scores()
    {
        

        percentOne.text = "playerOnepert " + playerOnepert + " %";
        percentTwo.text = "playerTwopert " + Player2.instance.playerTwopert + " %";
        yield return new WaitForSeconds(2);
        percentOne.text = "";
        percentTwo.text = "";
        PlayerPrefs.SetInt("OneScore", OneScore);

        if(OneScore > PlayerPrefs.GetInt("P1HighScore", 0))
        {
            PlayerPrefs.SetInt("P1HighScore", OneScore);
        }
        PlayerPrefs.SetInt("TwoScore", TwoScore);

        if (TwoScore > PlayerPrefs.GetInt("P2HighScore", 0))
        {
            PlayerPrefs.SetInt("P2HighScore", TwoScore);
        }

        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.SetFloat("playerOnepert", playerOnepert);
        PlayerPrefs.SetFloat("playerTwopert", Player2.instance.playerTwopert);

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
            playerOneScore++;
            Debug.Log("playeronescore" + playerOneScore);
        }
    }
}
