using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{   

    private float currentTime = 0.00f;
    [SerializeField] private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = currentTime.ToString("F2"); // F2 --> formatted to two decimal places 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        textBox.text = currentTime.ToString("F2");
    }
}
