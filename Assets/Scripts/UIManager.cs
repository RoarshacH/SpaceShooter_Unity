using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] livesImages;

    [SerializeField]
    private Image playerLivesImage;
    [SerializeField]
    private Text playerScore;

    

    public int score = 0;
    public void updateLives(int currentLives) {
        playerLivesImage.sprite = livesImages[currentLives];

    }

    public void updateScore() {
        score = score + 10;
        playerScore.text = "Score:" + score;

    }

    public void resetScore()
    {
        score = 0;
        playerScore.text = "Score:" + score;

    }


}
