using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HangmanGame : MonoBehaviour
{
    [SerializeField] private int hp = 7;

    [FormerlySerializedAs("_textFiedlWord")] [FormerlySerializedAs("_textField")] [SerializeField]
    private TextMeshProUGUI textFiedlWord;

    [FormerlySerializedAs("_textLetters")] [SerializeField] private TextMeshProUGUI textLetters;
    [FormerlySerializedAs("_textHp")] [SerializeField] private TextMeshProUGUI textHp;

    public Restart gameManagerLose;
    [FormerlySerializedAs("gameManegerWin")] public Restart gameManagerWin;
    private readonly List<char> _guessedLetters = new();
    private readonly List<char> _wrongTriedLetter = new();

    private string _initialWord = "";

    private char[] _letters =
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    private readonly string[] _words =
    {
        "Cat",
        "Dog",
        "Orange",
        "Banana"
    };

    private string _wordToGuess = "";

    private KeyCode _lastKeyPressed;

    private void Start()
    {
        int randomIndex = Random.Range(0, _words.Length);

        _wordToGuess = _words[randomIndex];

        for (int i = 0; i < _wordToGuess.Length; i++)
        {
            _initialWord += " _";
        }

        textFiedlWord.text = _initialWord;
        textHp.text = "Hp left = " + hp.ToString();
    }


    private void OnGUI()
    {
        var e = Event.current;
        if (!e.isKey) return;
        // Debug.Log("Detected key code: " + e.keyCode);

        if (e.keyCode == KeyCode.None || _lastKeyPressed == e.keyCode) return;
        ProcessKey(e.keyCode);

        _lastKeyPressed = e.keyCode;
        
       /*  то же самое что и выше
        Event e = Event.current;
        if (e.isKey)
        {
            // Debug.Log("Detected key code: " + e.keyCode);

            if (e.keyCode != KeyCode.None && _lastKeyPressed != e.keyCode)
            {
                ProcessKey(e.keyCode);

                _lastKeyPressed = e.keyCode;
            }
        }
        */
    }

    private void ProcessKey(KeyCode key)
    {
        print("Key Pressed: " + key);

        char pressedKeyString = key.ToString()[0];

        string wordUppercase = _wordToGuess.ToUpper();

        bool wordContainsPressedKey = wordUppercase.Contains(pressedKeyString);
        bool letterWasGuessed = _guessedLetters.Contains(pressedKeyString);

        if (!wordContainsPressedKey && !_wrongTriedLetter.Contains(pressedKeyString))
        {
            _wrongTriedLetter.Add(pressedKeyString);
            hp -= 1;

            if (hp <= 0)
            {
                gameManagerLose.GameOverLose();
                print("Lose");
            }
            else
            {
                textHp.text = "Hp left = " + hp.ToString();
            }
        }

        if (wordContainsPressedKey && !letterWasGuessed)
        {
            _guessedLetters.Add(pressedKeyString);
        }

        string stringToPrint = "";
        foreach (var letterInWord in wordUppercase)
        {
            if (_guessedLetters.Contains(letterInWord))
            {
                stringToPrint += letterInWord;
            }
            else
            {
                stringToPrint += " _";
            }
        }
        /* место foreach
         for (int i = 0; i < wordUppercase.Length; i++)
        {
            char letterInWord = wordUppercase[i];

            if (_guessedLetters.Contains(letterInWord))
            {
                stringToPrint += letterInWord;
            }
            else
            {
                stringToPrint += " _";
            }
        }
         */

        if (wordUppercase == stringToPrint)
        {
            gameManagerWin.GameOverWin();
            print("Win");
        }

        // print(string.Join(", ", guessedLetters));
        print(stringToPrint);
        textFiedlWord.text = stringToPrint;
    }
}