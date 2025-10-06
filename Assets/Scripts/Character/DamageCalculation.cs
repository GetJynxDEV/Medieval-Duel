using UnityEngine;

public class DamageCalculatation : MonoBehaviour
{
    float finalDamageValue;

    public float physicalDamage(float defenderArmor, float attackerDamage)
    {
        finalDamageValue = attackerDamage - defenderArmor;

        if (finalDamageValue < 0)
        {
            finalDamageValue = 1;
        }

        return finalDamageValue;
    }
}

