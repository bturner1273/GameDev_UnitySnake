using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text score_text;
    public Text game_over_text;
    public Text win_text;

    public void UpdateScoreDisplay()
    {
        score_text.text = "Score: " + GameManager.GetScore();   
    }

    public void ShowGameOver ()
    {
        game_over_text.enabled = true;
    }
    
    public void ShowWin ()
    {
        win_text.enabled = true;
    }
}
