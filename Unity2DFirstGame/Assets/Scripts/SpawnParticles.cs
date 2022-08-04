using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{   
    [SerializeField] private float timePerSpawn;
    [SerializeField] private GameObject particle;

    private static int maxNumberOfObjects = 4;
    private int currentNumberOfParticles = 0;
 
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("Spawn", 10f,timePerSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()  {
        
        if (currentNumberOfParticles < maxNumberOfObjects)    {
            Instantiate(particle, new Vector3(Random.Range(-10f,8f), Random.Range(-1f,6f), 0f),Quaternion.identity);
           
        }
        currentNumberOfParticles++;
    }

}
