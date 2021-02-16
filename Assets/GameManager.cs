using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count = 0;
    public int index = 0;
    public AudioSource m_MyAudioSource;
    public GameObject letter;
    public GameObject letter2;
    public GameObject cen;
    public string wordToGuess = "";
    public string wordToGuess2 = "";
    private int lengthOfWordToGuess;
    char [] lettersToGuess;
    bool [] lettersGuessed;
    public GUISkin layout;
    private string [] wordsToGuess = new string [] {"car", "elephant","Pharaoh","abalone","blowups","chaotic","evicted","hoaxers","kwanzas","beehive","beguile","bitters","bizare","buoyant","klaxons","lurkers","moronic","mortify","scrawny","test" };
    private string [] wordsToGuess2 = new string [] {"rca", "aeplhetn","horPhaa","noalabe","upowbsl","otiacch","dceivte","osexrha","azanswk","ebevhei","ebluegi","esbritt","irzeba","tyonbau","xnsakol","ureskrl","ocmirno","oirtfmy","raynwcs","etts" };
    // Start is called before the first frame update
    void Start()
    {
       m_MyAudioSource = GetComponent<AudioSource>();
       cen = GameObject.Find ("centerOfScreen");
       initGame();
       dispLetters();
       initLetters();
    }
    void OnGUI() {
       GUI.skin = layout;
       if (GUI.Button (new Rect (Screen.width / 2 - 475,1300, 120, 53), "ERASE")) {
          int nbletters = lengthOfWordToGuess;
          for (int i = 0; i < nbletters; i++)
          {
             GameObject go;
             GameObject go1;
             go = GameObject.Find("letter"+(i+1));
             go1 = GameObject.Find("sletter"+(i+1));
             Destroy(go);
             Destroy(go1);
          }
          count = 0;
          index = 0;
          m_MyAudioSource.Play();
          Start();
        }
    }
    // Update is called once per frame
    void Update()
    {
       GameObject.Find("letter"+(index + 1)).GetComponent<UnityEngine.UI.Text>().color = Color.red;
       checkKeyboard2();
       GameObject.Find("letter"+(index)).GetComponent<UnityEngine.UI.Text>().color = Color.white;
    }
    void initLetters()
    {
       int nbletters = lengthOfWordToGuess;;
       for (int i = 0; i < nbletters; i++) 
       {
          Vector3 newPosition;
          newPosition = new Vector3 (cen.transform.position.x + ((i-nbletters/2.0f) *100), cen.transform.position.y, cen.transform.position.z);
          GameObject l = (GameObject)Instantiate (letter, newPosition, Quaternion.identity);
          l.name = "letter" + (i + 1);
          l.transform.SetParent(GameObject.Find ("Canvas").transform);
       }
    }

    void dispLetters()
    {   
       int nbletters = lengthOfWordToGuess;;
       for (int i = 0; i < nbletters; i++) 
       {   
          Vector3 newPosition2;
          newPosition2 = new Vector3 (cen.transform.position.x  + ((i-nbletters/2.0f) *100) , cen.transform.position.y  + 150, cen.transform.position.z);
          GameObject l = (GameObject)Instantiate (letter, newPosition2, Quaternion.identity);
          l.name = "sletter" + (i + 1); 
          l.transform.SetParent(GameObject.Find ("Canvas").transform);
          l.GetComponent<UnityEngine.UI.Text>().text = wordToGuess2[i].ToString();
       }   
    }   



    void initGame()
    {
       
       int randomNumber = Random.Range (0, wordsToGuess.Length - 1);
       wordToGuess = wordsToGuess [randomNumber];
       wordToGuess2 = wordsToGuess2 [randomNumber];
       lengthOfWordToGuess = wordToGuess.Length;
       wordToGuess = wordToGuess.ToUpper ();
       lettersToGuess = new char[lengthOfWordToGuess];
       lettersGuessed = new bool [lengthOfWordToGuess];
       lettersToGuess = wordToGuess.ToCharArray ();
    }
   void checkKeyboard2()
   {
      if (Input.anyKeyDown)
      {
         char letterPressed = Input.inputString.ToCharArray () [0];
         int letterPressedAsInt = System.Convert.ToInt32 (letterPressed);
         if (letterPressedAsInt >= 97 && letterPressed <= 122)
         {
            letterPressed = System.Char.ToUpper (letterPressed);
               if (lettersToGuess [index] == letterPressed)
               {
                     GameObject.Find("letter"+(index + 1)).GetComponent<UnityEngine.UI.Text>().text = letterPressed.ToString();
                     index = index + 1;
               }
         }
      }
    }
}
