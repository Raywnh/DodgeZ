using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{   

    [SerializeField] GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", 10f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void spawnObject()  {
        Debug.Log("Spawned");
        Instantiate(particle, new Vector3(Random.Range(-10f,8f), Random.Range(-1f,6f), 0f),Quaternion.identity);
    }
}
