using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool active;
    private static int score;
    private static UIManager ui;

    void Start()
    {
        active = true;
        score = 0;
        ui = GetComponent<UIManager>();
    }

    public static void SetScore (int init_score)
    {
        score = init_score;
        ui.UpdateScoreDisplay();
    }

    public static int GetScore ()
    {
        return score;
    }

    public static void SetActive (bool init_active, bool win)
    {
        active = init_active;
        if (!active)
        {
            if (win)
            {
                ui.ShowWin();
            }
            else
            {
                ui.ShowGameOver();
            }
        }
    }

    public static bool GetActive ()
    {
        return active;
    }
}
