using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEggs : MonoBehaviour
{
    public GameObject eggPrefab;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer + 1)
        {
            timer = Time.time;
            Drop();
        }
    }

    void Drop()
    {
        // Debug.Log("Dropping egg");
        Instantiate(eggPrefab, transform.position, transform.rotation);
    }
}
