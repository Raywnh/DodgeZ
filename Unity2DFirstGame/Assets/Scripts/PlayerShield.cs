using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{   
    private GameObject shieldGlowObject;
    private float shieldDuration = 6.0f;
    private bool shieldIsAlreadyOn = false;

    [SerializeField] private GameObject shieldGlow;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(shieldDuration);
    }

    void EndShield()    {
        Destroy(shieldGlowObject, 0.5f);
        shieldIsAlreadyOn = false;

        FindObjectOfType<DestroyOnCollision>().ShieldOff();
    }

    public void TurnOnShield() {

        if(!shieldIsAlreadyOn)  {
            shieldGlowObject = Instantiate(shieldGlow, playerTransform.position, playerTransform.rotation);

            shieldGlowObject.transform.SetParent(playerTransform);

            FindObjectOfType<DestroyOnCollision>().ShieldOn();

            shieldIsAlreadyOn = true;
            shieldDuration = 7.0f;
        }
        


        Invoke("EndShield", shieldDuration);
    }

}
