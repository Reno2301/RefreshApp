using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMathAchievements : MonoBehaviour
{
    public TMP_Text correct, wrong;

    // Start is called before the first frame update
    void Start()
    {
        SetAchievements();
    }

    public void DeleteAchievements()
    {
        PlayerPrefs.SetInt("mathcorrect", 0);
        PlayerPrefs.SetInt("mathwrong", 0);
    }

    public void SetAchievements()
    {
        correct.text = PlayerPrefs.GetInt("mathcorrect").ToString();
        wrong.text = PlayerPrefs.GetInt("mathwrong").ToString();
    }
}
