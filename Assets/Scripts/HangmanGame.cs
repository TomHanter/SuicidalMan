using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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
<<<<<<< HEAD
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private TextMeshProUGUI _textHp;
        [SerializeField] private TextMeshProUGUI _textLetters;
        private string initialWord = "";
        private char[] Letters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
        
        [SerializeField] private int hp = 7;
=======
        "Cat",
        "Dog"
    };
>>>>>>> parent of fe29ece (Fix)

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
<<<<<<< HEAD
            "Cat",
            "Dog",
            "Orange",
            "Banana"
        };
=======
            // Debug.Log("Detected key code: " + e.keyCode);
>>>>>>> parent of fe29ece (Fix)


<<<<<<< HEAD
        private KeyCode lastKeyPressed;

        private void Start()
        {
            var randomIndex = Random.Range(0, words.Length);

            wordToGuess = words[randomIndex];
            
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                initialWord += " _";
            }
            _textField.text = initialWord;
            _textHp.text = "Hp left = " + hp.ToString();
        }

        void OnGUI()
        {
            Event e = Event.current; // событие нажатия клавиши
            if (e.isKey)
            {
                // Debug.Log("Detected key code: " + e.keyCode);

                if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode) // была нажата и не отпущена и не равно той, которая была на прошлой попытке
                {
                    ProcessKey(e.keyCode); // выводим обработку

                    lastKeyPressed = e.keyCode; // буферим нажатую клавишу в прошлый раз
                }
=======
            if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode)
            {
                ProcessKey(e.keyCode);
                
                lastKeyPressed = e.keyCode;
>>>>>>> parent of fe29ece (Fix)
            }

            if (e.isKey)
            {
                
            }
        }
<<<<<<< HEAD

        private void ProcessKey(KeyCode key) // передается клавиша параметром onGUI
        {

            print("Key Pressed:" + key); // выводим клавишу которую нажали

            char pressedKeyString = key.ToString()[0];

            string wordUppercase = wordToGuess.ToUpper(); // переводит в заглав буквы

            bool wordContainsPressedKey =
                wordUppercase.Contains(
                    pressedKeyString); // содерж ли загад слова кнопке, Cont проходит по каждой букве в строке и сравн которую передали
            bool letterWasGuessed = guessedLetters.Contains(pressedKeyString); // провер была ли угадана буква ранее

            if (!wordContainsPressedKey && !wrongTriedLetter.Contains(pressedKeyString))
            {
                wrongTriedLetter.Add(pressedKeyString);
                hp -= 1;
                _textHp.text = "Hp left = " + hp.ToString();
            }

            if (wordContainsPressedKey && !letterWasGuessed)
            {
                guessedLetters.Add(pressedKeyString);
                
                if (hp <= 0)
                {
                    print("You Lost");
                }
            }

            string stringToPrint = ""; // формир строку которуб хотим вывести и что было угадана
            for (int i = 0; i < wordUppercase.Length; i++) // проходим по всем буквам занад слова
            {
                char letterInWord = wordUppercase[i];

                if (guessedLetters.Contains(letterInWord)) // если угад буква
                {
                    stringToPrint += letterInWord;
                }
                else // если не угад
                {
                    stringToPrint += " _";
                    
                }
            }

            if (wordUppercase == stringToPrint) // если угадали все слово
            {
                print("You Win");
            }

            // print(guessedLetters); - так не выводится
            // print(string.Join(",", guessedLetters)); // выводит строчкой 4,5,6,7,8
            print(stringToPrint);
            
            _textField.text = stringToPrint;
        }
    } 
=======
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
>>>>>>> parent of fe29ece (Fix)
}


