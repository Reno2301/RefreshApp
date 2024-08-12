using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquationCode : MonoBehaviour
{
    private int aInt;
    private int bInt;
    public float answerFloat;

    private string aString;
    private string bString;

    public TMP_Text EquationText;
    public TMP_InputField answerInputField;

    public bool checkBool;

    public Image checkImage;

    private int equationPicker;
    bool multiply, divide;

    int multiplyCount, divideCount;

    // Start is called before the first frame update
    void Start()
    {
        answerInputField.ActivateInputField();

        // Returns the last text to nothing so placeholder will be active.
        answerInputField.text = "";

        equationPicker = Random.Range(1, 3);

        // Pick if the equation will be dividing or multiplying.
        if (equationPicker == 1)
        {
            multiplyCount += 1;
            multiply = true;
            divide = false;
        }
        else
        {
            divideCount += 1;
            divide = true;
            multiply = false;
        }

        if (multiply)
        {
            // Give a random number to 2 separate integers, then get the answer by multiplying them.
            aInt = Random.Range(2, 20);
            bInt = Random.Range(2, 30);
            answerFloat = aInt * bInt;

            //Set the strings of the integers to a string to put into the EquationText.
            aString = aInt.ToString();
            bString = bInt.ToString();

            EquationText.text = aString + " x " + bString + " =";
        }

        if (divide)
        {
            //Give a random number to 2 integers.
            aInt = Random.Range(3, 400);
            bInt = Random.Range(3, 20);

            //Check if the numbers are divisible without decimals.
            if (!IsDivisible(aInt, bInt))
            {
                DivideAgain();
            }

            //Set the strings of the integers to a string to put into the EquationText.
            aString = aInt.ToString();
            bString = bInt.ToString();

            EquationText.text = aString + " / " + bString + " =";

            answerFloat = aInt / bInt;
        }
    }

    public bool IsDivisible(int x, int n)
    {
        return (x % n) == 0;
    }

    void DivideAgain()
    {
        //Give a random number to 2 integers.
        aInt = Random.Range(3, 400);
        bInt = Random.Range(3, 20);

        //Check if the numbers are divisible without decimals.
        if (!IsDivisible(aInt, bInt))
        {
            DivideAgain();
        }
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
        if (answerInputField.text == answerFloat.ToString())
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

        Debug.Log("Correct! The answer is: " + answerFloat);
        Start();
    }

    private IEnumerator Wrong()
    {
        checkImage.gameObject.SetActive(true);
        checkImage.color = new Color(1, 0, 0, 0.25f);

        yield return new WaitForSeconds(0.4f);

        checkImage.gameObject.SetActive(false);
        checkImage.color = new Color(1, 1, 1, 0.25f);

        Debug.Log("Wrong! Try again");

        answerInputField.ActivateInputField();
    }
}
