using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Animator ac;
    public float survivalTime = 5f;
    private float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<Animator>();
        destroyTime = Time.time + survivalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
