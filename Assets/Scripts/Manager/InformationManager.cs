using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationManager : MonoBehaviour
{
    //Reference the TMP
    public GameObject[] tmp;

    public TextMeshProUGUI[] playerInformation;
    public TextMeshProUGUI[] enemyInformation;
    
    public string[] player;
    //[0] = Player Attacked the Enemy
    //[0] = Player used Block
    //[0] = Player Used Special Attack
    //[1] = Player Attack Missed || Player Received [amount] DMG
    //[2] = Player Blocked the Attack
    //[3] = Player failed to use Special Attack || Player failed to Block

    public string[] enemy;
    //[0] = Enemy Attacked the Player
    //[0] = Enemy used Block
    //[0] = Enemy Used Special Attack
    //[1] = Enemy Attack Missed || Enemy Received [amount] DMG
    //[2] = Enemy Blocked the Attack
    //[3] = Enemy failed to use Special Attack || Enemy failed to Block

    //Reference the Ability Buttons
    public Button[] Buttons;

    public GameOverviewManager overview;

    private void Start()
    {
        resetData();
    }

    private void Update()
    {
        if (GameManager.Instance.endTurn)
        {
            foreach(GameObject go in tmp)
            {
                go.SetActive(true);
            }

            GameManager.Instance.endTurn = false;

            Invoke("resetData", 3f);
        }
    }

    private void resetData()
    {
        foreach (GameObject go in tmp)
        {
            go.SetActive(false);
        }

        for (int i = 0; i < playerInformation.Length; i++)
        {
            playerInformation[i].text = "";
            enemyInformation[i].text = "";
        }

        OpenAbility();
    }

    public void CloseAbility()
    {
        foreach (Button btn in Buttons)
        {
            btn.interactable = false;
        }
    }

    public void OpenAbility()
    {
        foreach (Button btn in Buttons)
        {
            btn.interactable = true;
        }
    }
}
