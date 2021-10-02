using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{

    public Rigidbody2D horse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SpawnHorse();
    }

    void SpawnHorse()
    {
        Debug.Log("YUP");
        Rigidbody2D horse1;
        horse1 = Instantiate(horse, transform.position, transform.rotation);
        horse1.velocity = transform.TransformDirection(Vector2.left * 10);
    }
}
