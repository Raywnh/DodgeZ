using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShields : MonoBehaviour
{
    [SerializeField] private float  timePerSpawn;
    [SerializeField] private GameObject shield;

    private static int maxNumberOfObjects = 2;
    private int currentNumberOfShields = 0;
 
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("Spawn", 10f, timePerSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()  {
        
        if (currentNumberOfShields < maxNumberOfObjects)    {
            Instantiate(shield, new Vector3(Random.Range(-10f,8f), -1.2f, 0f),Quaternion.identity);
            currentNumberOfShields++;
        }

    }

    public void decreaseNumberOfShields()    {

        if (currentNumberOfShields > 0) {
            currentNumberOfShields--;
        }
    }
}
