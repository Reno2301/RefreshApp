using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public void StartMath()
    {
        AchievementUpdate();
        SceneManager.LoadScene("Math");
    }

    public void GoToMainMenu()
    {
        AchievementUpdate();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenMathAchievements()
    {
        AchievementUpdate();
        SceneManager.LoadScene("Math1");
    }
    
    private void AchievementUpdate()
    {
    }
}
