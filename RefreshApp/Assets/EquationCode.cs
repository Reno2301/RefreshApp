using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquationCode : MonoBehaviour
{
    private int aInt;
    private int bInt;
    public int answerInt;

    private string aString;
    private string bString;

    public TMP_Text EquationText;
    public TMP_InputField answerInputField;

    public bool checkBool;

    public Image checkImage;

    // Start is called before the first frame update
    void Start()
    {
        // Returns the last text to nothing so placeholder will be active.
        answerInputField.text = "";

        // Give a random number to 2 separate integers, then get the answer by multiplying them.
        aInt = Random.Range(1, 20);
        bInt = Random.Range(1, 20);
        answerInt = aInt * bInt;

        //Set the strings of the integers to a string to put into the EquationText.
        aString = aInt.ToString();
        bString = bInt.ToString();

        EquationText.text = aString + " x " + bString + " =";
    }

    public void Update()
    {
        // When pressing the Return or Enter key, check the answer
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    public void CheckAnswer()
    {
        // When the answer is right
        if (answerInputField.text == answerInt.ToString())
        {
            StartCoroutine(Correct());
        }
        // When the answer is wrong
        else
        {
            StartCoroutine(Wrong());
        }
    }

    private IEnumerator Correct()
    {
        checkImage.gameObject.SetActive(true);
        checkImage.color = new Color(0, 1, 0, 0.25f);

        yield return new WaitForSeconds(0.4f);

        checkImage.gameObject.SetActive(false);
        checkImage.color = new Color(1, 1, 1, 0.25f);

        Debug.Log("Correct! The answer is: " + answerInt);
        Start();
    }

    private IEnumerator Wrong()
    {
        checkImage.gameObject.SetActive(true);
        checkImage.color = new Color(1, 0, 0, 0.25f);

        yield return new WaitForSeconds(0.4f);

        checkImage.gameObject.SetActive(false);
        checkImage.color = new Color(1, 1, 1, 0.25f);

        Debug.Log("Wrong! Try again :)");
    }
}
