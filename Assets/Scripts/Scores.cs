using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Scores : MonoBehaviour
{
    public TextMeshProUGUI player1Score,player2Score,totalScore, p1HighScore, p2HighScore, player1Win,player2Win, tied;
    public TextMeshProUGUI player1Pert, player2Pert;
    int score;
    void Start()
    {
        player1Score.text = "PlayerOneScore :" + PlayerPrefs.GetInt("OneScore").ToString();
        player2Score.text = "PlayerTwoScore :" + PlayerPrefs.GetInt("TwoScore").ToString();
        totalScore.text = "TotalScore :" + PlayerPrefs.GetInt("totalScore").ToString();
        player1Pert.text = "PlayerOne % :" + PlayerPrefs.GetFloat("playerOnepert").ToString() + "%";
        player2Pert.text = "PlayerTwo % :" + PlayerPrefs.GetFloat("playerTwopert").ToString() + "%";
        p1HighScore.text = "P1HighScore :" + PlayerPrefs.GetInt("P1HighScore").ToString();
        p2HighScore.text = "P2HighScore :" + PlayerPrefs.GetInt("P2HighScore").ToString();

        if(PlayerPrefs.GetInt("OneScore") > PlayerPrefs.GetInt("TwoScore"))
        {
            Debug.Log("Player1Wins");
            player1Win.gameObject.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("OneScore") < PlayerPrefs.GetInt("TwoScore"))
        {
            Debug.Log("Player2Wins");
            player2Win.gameObject.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("OneScore") == PlayerPrefs.GetInt("TwoScore"))
        {
            Debug.Log("MatchTied");
            tied.gameObject.SetActive(true);
        }
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void AppQuit()
    {
        Application.Quit();
    }
}
