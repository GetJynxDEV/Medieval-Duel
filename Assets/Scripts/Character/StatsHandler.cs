using UnityEngine;

public class StatsHandler : MonoBehaviour
{
    //StatsHanlder will handle what your Character Stats will be

    public bool hasStatsSet = false;

    [SerializeField] private Stats status;
    [SerializeField] private Stats enemyStats;

    [SerializeField] private InformationManager information;

    private void Update()
    {
        if (!hasStatsSet)
        {
            setPlayerStats();
            setEnemyStats();

            hasStatsSet = true;
        }
        
    }

    public void setPlayerStats()
    {
        if (GameManager.Instance.selectedCharacter == "Assassin")
        {
            //Set Assassin Stats
            status.maxHealth = 75;
            status.maxMana = 30;
            status.increaseMana = 10;
            status.damage = 15;
            status.sDamage = 30;
            status.sDamageCost = 20;
            status.armor = 5;
            status.skillChance = 0.6f;
        }

        if (GameManager.Instance.selectedCharacter == "HolyKnight")
        {
            //Set Knight Stats
            status.maxHealth = 100;
            status.maxMana = 50;
            status.increaseMana = 7;
            status.damage = 25;
            status.sDamage = 50;
            status.sDamageCost = 20;
            status.armor = 15;
            status.skillChance = 0.4f;
        }

        if (GameManager.Instance.selectedCharacter == "Mage")
        {
            //Set Mage Stats
            status.maxHealth = 50;
            status.maxMana = 100;
            status.increaseMana = 30;
            status.damage = 60;
            status.sDamage = 120;
            status.sDamageCost = 70;
            status.armor = 10;
            status.skillChance = 0.3f;
        }

        status.SetStats();
    }

    public void setEnemyStats()
    {
        if (GameManager.Instance.enemySelectedCharacter == "Assassin")
        {
            //Set Assassin Stats
            enemyStats.maxHealth = 75;
            enemyStats.maxMana = 30;
            enemyStats.increaseMana = 10;
            enemyStats.damage = 15;
            enemyStats.sDamage = 30;
            enemyStats.sDamageCost = 20;
            enemyStats.armor = 5;
            enemyStats.skillChance = 0.6f;
        }
        if (GameManager.Instance.enemySelectedCharacter == "HolyKnight")
        {
            //Set Knight Stats
            enemyStats.maxHealth = 100;
            enemyStats.maxMana = 50;
            enemyStats.increaseMana = 7;
            enemyStats.damage = 25;
            enemyStats.sDamage = 50;
            enemyStats.sDamageCost = 20;
            enemyStats.armor = 15;
            enemyStats.skillChance = 0.4f;
        }
        if (GameManager.Instance.enemySelectedCharacter == "Mage")
        {
            //Set Mage Stats
            enemyStats.maxHealth = 50;
            enemyStats.maxMana = 100;
            enemyStats.increaseMana = 30;
            enemyStats.damage = 60;
            enemyStats.sDamage = 120;
            enemyStats.sDamageCost = 70;
            enemyStats.armor = 10;
            enemyStats.skillChance = 0.2f;
        }

        enemyStats.SetStats();
    }
}
