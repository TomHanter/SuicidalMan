using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class HangmanGame : MonoBehaviour
{
    [SerializeField] TextMeshPro 
    [SerializeField] private int hp = 7;
    
    private List<char> guessedLetters = new List<char>();
    private List<char> wrongTriedLetter = new List<char>();

    private string[] words =
    {
        "Cat",
        "Dog"
    };

    private string wordToGuess = "";

    private KeyCode lastKeyPressed;

    private void Start()
    {
        var randomIndex = Random.Range(0, words.Length);

        wordToGuess = words[randomIndex];
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            // Debug.Log("Detected key code: " + e.keyCode);


            if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode)
            {
                ProcessKey(e.keyCode);
                
                lastKeyPressed = e.keyCode;
            }
        }
    }

    private void ProcessKey(KeyCode key)
    {
        string word = "Time";
        
        print("Key Pressed:" + key);

        char pressedKeyString = key.ToString()[0];

        string wordUppercase = word.ToUpper();
        
        bool wordContainsPressedKey = word.Contains(pressedKeyString);
        bool letterWasGuessed = guessedLetters.Contains(pressedKeyString);

        if (!wordContainsPressedKey && wrongTriedLetter.Contains(pressedKeyString))
        {
            wrongTriedLetter.Add(pressedKeyString);
            hp -= 1;
            print("Wrong Letter \n Hp left =" + hp);

            if (hp <= 0)
            {
                print("You Lost");
            }
            else
            {
                print("Wrong letter \n Hp left = " + hp);
            }
        }

        if (wordContainsPressedKey && !letterWasGuessed)
        {
            guessedLetters.Add(pressedKeyString);
        }
        
        string stringToPrint = "";
        for (int i = 0; i < wordUppercase.Length; i++)
        {
            char letterInWord = wordUppercase[i];

            if (guessedLetters.Contains(letterInWord))
            {
                stringToPrint += letterInWord;
            }
            else
            {
                stringToPrint += "_";
            }
        }

        if (wordUppercase == stringToPrint)
        {
            print("You Win");
        }
        
        // print(guessedLetters); - так не выводится
        // print(string.Join(",", guessedLetters)); // выводит строчкой 4,5,6,7,8
        print(stringToPrint);
    }
}
