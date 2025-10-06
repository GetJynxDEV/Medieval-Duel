using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public void CharAssassin()
    {
        //Attach to Assassin Select Button

        //Set character to Assassin
        GameManager.Instance.selectedCharacter = "Assassin";

        //Set character selected to true
        GameManager.Instance.hasCharacterSelected = true;

        Debug.Log($"{GameManager.Instance.selectedCharacter} was selected");
    }

    public void CharHolyKnight()
    {
        //Attach to Knight Select Button

        //Set character to Knight
        GameManager.Instance.selectedCharacter = "HolyKnight";
        //Set character selected to true
        GameManager.Instance.hasCharacterSelected = true;

        Debug.Log($"{GameManager.Instance.selectedCharacter} was selected");
    }

    public void CharMage()
    {
        //Attach to Mage Select Button

        //Set character to Mage
        GameManager.Instance.selectedCharacter = "Mage";
        //Set character selected to true
        GameManager.Instance.hasCharacterSelected = true;

        Debug.Log($"{GameManager.Instance.selectedCharacter} was selected");
    }

    public void CharDeSelect()
    {
        //Attach to Deselect Button

        //Deselect character
        GameManager.Instance.selectedCharacter = "";
        //Deselect enemy character
        GameManager.Instance.enemySelectedCharacter = "";
        //Set character selected to false
        GameManager.Instance.hasCharacterSelected = false;

        Debug.Log("Character Deselected");
    }

    public void EnemyCharSelect()
    {
        int randomValue = Random.Range(0, 3);

        if (randomValue == 0)
        {
            //Set enemy character to Assassin
            GameManager.Instance.enemySelectedCharacter = "Assassin";
        }

        else if (randomValue == 1)
        {
            //Set enemy character to Knight
            GameManager.Instance.enemySelectedCharacter = "HolyKnight";
        }
        else
        {
            //Set enemy character to Mage
            GameManager.Instance.enemySelectedCharacter = "Mage";
        }

        Debug.Log($"The Enemy Chose {GameManager.Instance.enemySelectedCharacter}");
    }
}
