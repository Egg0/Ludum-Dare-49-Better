using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{

    public Rigidbody2D horse;
    private float clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > clock + 5)
        {
            SpawnHorse();
            switch ((int)(Random.value * 10))
            {
                case 0:
                    Debug.Log("Attack 0");
                    break;
                case 1:
                    Debug.Log("Attack 1");
                    SpawnHorse();
                    break;
                case 2:
                    Debug.Log("Attack 2");
                    break;
                case 3:
                    Debug.Log("Attack 3");
                    break;
                case 4:
                    Debug.Log("Attack 4");
                    break;
                case 5:
                    Debug.Log("Attack 5");
                    break;
                case 6:
                    Debug.Log("Attack 6");
                    break;
                case 7:
                    Debug.Log("Attack 7");
                    break;
                case 8:
                    Debug.Log("Attack 8");
                    break;
                case 9:
                    Debug.Log("Attack 9");
                    break;
                default:
                    Debug.Log("default attack");
                    break;
            }
            clock = Time.time;
        }
    }

    void SpawnHorse()
    {
        // Debug.Log("Spawned horse");
        Rigidbody2D horse1;
        horse1 = Instantiate(horse, transform.position, transform.rotation);
        horse1.velocity = transform.TransformDirection(Vector2.left * 10);
    }
}
