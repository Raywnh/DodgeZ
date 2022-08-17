using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private float  timePerSpawn;
    [SerializeField] private GameObject point;

    private static int maxNumberOfObjects = 4;
    private int currentNumberOfPoints = 0;
 
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("Spawn", 5f, timePerSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()  {
        
        if (currentNumberOfPoints < maxNumberOfObjects)    {
            Instantiate(point, new Vector3(Random.Range(-10f,8f), Random.Range(-1f,6f), 0f),Quaternion.identity);
            currentNumberOfPoints++;
        }

    }

    public void decreaseNumberOfPoints()    {

        if (currentNumberOfPoints > 0) {
            currentNumberOfPoints--;
        }
    }
}
