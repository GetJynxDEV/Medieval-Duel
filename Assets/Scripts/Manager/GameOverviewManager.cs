using UnityEngine;

public class GameOverviewManager : MonoBehaviour
{
    //Attach the Damage Calculation script to this script
    [SerializeField] private DamageCalculatation calc;

    //Reference to the player and enemy stats script
    [SerializeField] private Stats playerStats;
    [SerializeField] private Stats enemyStats;

    //Reference to the Information Manager script
    [SerializeField] private InformationManager information;

    //True if the player or enemy has blocked an attack
    public bool hasPlayerBlocked = false;
    public bool hasEnemyBlocked = false;

    public bool endTurn = false;

    public void Attack()
    {
        float hitChance = Random.Range(0, 1);

        information.playerInformation[0].text = information.player[0] = "Player Attacked the Enemy";

        if (hitChance <= playerStats.skillChance)
        {
            if (hasEnemyBlocked)
            {
                hasEnemyBlocked = false;

                information.playerInformation[1].text = information.enemy[2];
            }

            else
            {
                float damageAmount = calc.physicalDamage(enemyStats.armor, playerStats.damage);
                enemyStats.TakeDamage(Mathf.RoundToInt(damageAmount));

                information.playerInformation[1].text = information.enemy[1] = $"Enemy Received {damageAmount} DMG";
            }
        }

        else
        {
            //Attack Missed
            information.playerInformation[1].text = information.enemy[1] = "Player Attack missed";
        }

        PlayerEndTurn();
    }

    public void Defend()
    {
        float blockChance = Random.Range(0, 1);

        information.playerInformation[0].text = information.player[0] = "Player used Block";

        if (blockChance <= playerStats.skillChance)
        {
            hasPlayerBlocked = true;
        }
        else
        {
            information.playerInformation[1].text = information.player[3] = "Player failed to use block";
        }

        PlayerEndTurn();
    }

    public void SAttack()
    {
        float hitChance = Random.Range(0, 1);

        information.playerInformation[0].text = information.player[0] = "Player used Special Attack";

        if (hitChance <= playerStats.skillChance)
        {
            if (hasEnemyBlocked)
            {
                hasEnemyBlocked = false;

                information.playerInformation[1].text = information.enemy[2];
            }

            else
            {
                if (playerStats.currentMana >= playerStats.sDamageCost)
                {
                    float damageAmount = calc.physicalDamage(enemyStats.armor, playerStats.sDamage);
                    enemyStats.TakeDamage(Mathf.RoundToInt(damageAmount));
                    playerStats.currentMana -= playerStats.sDamageCost;

                    information.playerInformation[1].text = information.enemy[1] = $"Enemy Received {damageAmount} DMG";
                }
                else
                {
                    Debug.Log("Not Enough Mana to use Special Attack");

                    information.Buttons[3].interactable = false;
                }
            }
        }

        else
        {
            //Special Attack Missed
            information.playerInformation[1].text = information.enemy[1] = "Player Special Attack missed";

            playerStats.currentMana -= playerStats.sDamageCost;
        }

        PlayerEndTurn();
    }

    private void PlayerEndTurn()
    {
        information.CloseAbility();

        //randomAction will decide if enemy will attack(0) defend(1) or use special attack(2)
        int randomAction = Random.Range(0, 2);

    noMana:

        if (randomAction == 0)
        {
            //Enemy Attacks

            float hitChance = Random.Range(0, 1);

            information.enemyInformation[0].text = information.player[0] = "Enemy Attacked the Player";

            if (hitChance <= enemyStats.skillChance)
            {
                if (hasPlayerBlocked)
                {
                    hasPlayerBlocked = false;

                    information.enemyInformation[1].text = information.enemy[2] = "Player Blocked the Attack";
                }
                else
                {
                    float damageAmount = calc.physicalDamage(playerStats.armor, enemyStats.damage);
                    playerStats.TakeDamage(Mathf.RoundToInt(damageAmount));
                    information.enemyInformation[1].text = information.player[1] = $"Player Received {damageAmount} DMG";
                }
            }

            else
            {
                information.enemyInformation[1].text = information.player[1] = "Enemy Attack Missed";
            }
        }

        else if (randomAction == 1)
        {
            //Enemy Defends
            float blockChance = Random.Range(0, 1);

            information.enemyInformation[0].text = information.enemy[0] = "Enemy used Block";

            if (blockChance <= enemyStats.skillChance)
            {
                hasEnemyBlocked = true;
            }
            else
            {
                information.enemyInformation[1].text = information.enemy[3] = "Enemy failed to use block";
            }
        }

        else
        {
            float hitChance = Random.Range(0, 1);

            information.enemyInformation[0].text = information.enemy[0] = "Enemy used Special Attack";

            if (hitChance <= enemyStats.skillChance)
            {
                if (hasPlayerBlocked)
                {
                    hasPlayerBlocked = false;
                    information.enemyInformation[1].text = information.enemy[2] = "Player Blocked the Attack";
                }
                else
                {
                    if (enemyStats.currentMana >= enemyStats.sDamageCost)
                    {
                        float damageAmount = calc.physicalDamage(playerStats.armor, enemyStats.sDamage);
                        playerStats.TakeDamage(Mathf.RoundToInt(damageAmount));
                        enemyStats.currentMana -= enemyStats.sDamageCost;
                        information.enemyInformation[1].text = information.player[1] = $"Player Received {damageAmount} DMG";
                    }
                    else
                    {
                        Debug.Log("Not Enough Mana to use Special Attack");

                        //Return to the start of the enemy turn to choose a different action
                        randomAction = Random.Range(0, 1);
                        goto noMana;
                    }
                }
            }

            else
            {
                //Special Attack Missed
                information.enemyInformation[1].text = information.player[1] = "Enemy Special Attack missed";
                enemyStats.currentMana -= enemyStats.sDamageCost;
            }
        }

        IncreaseMana();
        GameManager.Instance.endTurn = true;
    }

    public void IncreaseMana()
    {
        if (playerStats.currentMana < playerStats.maxMana)
        {
            playerStats.currentMana += playerStats.increaseMana;

            Debug.Log("Increased Mana for Player");
        }

        if (enemyStats.currentMana < enemyStats.maxMana)
        {
            enemyStats.currentMana += enemyStats.increaseMana;

            Debug.Log("Increased Mana for Enemy");
        }
    }
}
