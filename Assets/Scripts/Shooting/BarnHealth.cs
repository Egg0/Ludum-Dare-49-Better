using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarnHealth : EnemyHealth
{
    public BoolSO victory;

    protected override void Die()
    {
        Debug.Log("Game over, barn destroyed");
        victory.active = true;
        base.Die();
    }
}
