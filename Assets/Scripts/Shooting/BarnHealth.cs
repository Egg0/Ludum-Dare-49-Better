using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnHealth : EnemyHealth
{
    protected override void Die()
    {
        Debug.Log("Game over, barn destroyed");
        base.Die();
    }
}
