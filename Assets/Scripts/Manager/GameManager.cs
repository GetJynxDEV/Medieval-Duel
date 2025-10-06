using UnityEngine;

public class GameManager : MonoBehaviour
{
    //hasCharacterSelected is true if player has selected a character
    public bool hasCharacterSelected = false;

    //selectedCharacter is the Class of the selected character
    public string selectedCharacter;

    //enemySelectedChacter is the Class of the selected enemy character
    public string enemySelectedCharacter;

    //isGameOver is true if the game is over or player has died
    public bool isGameOver = false;

    //hasGameStarted is true if the game has started
    public bool hasGameStarted = false;

    //If both Player and Enemy has ended their turn, this will be true
    public bool endTurn = false;

    //Singleton instance
    public static GameManager Instance;

    private void Awake()
    {

        //Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Call this when Game starts;
        gameRestart();
    }

    private void gameRestart()
    {
        //Only call this if you change character or restart the game

        isGameOver = false;
        hasCharacterSelected = false;
        selectedCharacter = "";
    }
}
