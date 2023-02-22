using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HangmanGame : MonoBehaviour
{
    [SerializeField] private int hp = 7;

    [FormerlySerializedAs("_textFiedlWord")] [FormerlySerializedAs("_textField")] [SerializeField]
    private TextMeshProUGUI textFiedlWord;

    [FormerlySerializedAs("_textLetters")] [SerializeField] private TextMeshProUGUI wrongLetters;
    [FormerlySerializedAs("_textHp")] [SerializeField] private TextMeshProUGUI textHp;
    [SerializeField] private TextMeshProUGUI _textHints;
    [SerializeField] private GameObject[] hpImage;

    public Restart gameManagerLose;
    [FormerlySerializedAs("gameManegerWin")] public Restart gameManagerWin;
    private readonly List<char> _guessedLetters = new();
    private readonly List<char> _wrongTriedLetter = new();

    private string _initialWord = "";


    private readonly string[] _words =
    {
        "Cat",
        "Dog",
        "Orange",
        "Banana",
        "Apple",
        "Bus"
            
    };

    private readonly string[] _hints =
    {
        "A pet that meows",
        "A pet that barks",
        "Citrus fruit",
        "Yellow fruit",
        "Phone fruit",
        "Passenger transport"
        
    };
    
    private string _wordToGuess = "";
    
    private string _hint = "";

    private KeyCode _lastKeyPressed;

    private void Start()
    {
        int randomIndex = Random.Range(0, _words.Length);

        _wordToGuess = _words[randomIndex];
        _hint = _hints[randomIndex];

        for (int i = 0; i < _wordToGuess.Length; i++)
        {
            _initialWord += " _";
        }

        _textHints.text = _hint;
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
            ChangeImageLowerHp(hp);
            
            if (hp <= 0)
            {
                gameManagerLose.GameOverLose();
                print("Lose");
            }
            else
            {
                wrongLetters.text +=  pressedKeyString + " ";
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
   private void ChangeImageLowerHp(int hpValue)
    {
        foreach (var image in hpImage)
        {
            image.SetActive(hpValue.ToString() == image.name);
        }
    }
}