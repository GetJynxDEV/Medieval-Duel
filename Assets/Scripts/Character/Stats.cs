using UnityEngine;

public class Stats : MonoBehaviour
{
    //Current Health is the current health of the character
    public float currentHealth;
    //Max Health is the maximum health of the character
    public float maxHealth;

    //Current Mana is the current mana of the character
    public float currentMana;
    //Max Mana is the maximum mana of the character
    public float maxMana;
    //Increase Mana is the amount of mana the character will gain at the start of their turn
    public float increaseMana;

    //Damage is the damage of a normal attack
    public float damage;
    //sDamage is the damage of a Special Attack
    public float sDamage;
    //sDamageCost is the mana cost of using a Special Attack
    public float sDamageCost;

    //Armor will reduce the damage taken from attacks
    public float armor;

    //Skill Chance means the chance of hitting the target with a skill or using a skill successfully

    public float skillChance; //0f = 0% , 0.75 = 75%, 1f = 100% Hit Chance, modify this to your needs

    public void SetStats()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public void ResetValue()
    {
        maxHealth = 0;
        maxMana = 0;
        damage = 0;
        armor = 0;
        skillChance = 0;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            GameManager.Instance.isGameOver = true;

            Debug.Log($"{gameObject.name} has died.");
        }
    }
}
