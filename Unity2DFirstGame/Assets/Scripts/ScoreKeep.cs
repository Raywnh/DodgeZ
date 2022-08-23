using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour
{   
    [SerializeField] private Text textBox;
    protected internal int score = 0;


    // Start is called before the first frame update
    void Start()
    {   
        textBox.text = score.ToString();
        InvokeRepeating("IncreaseScoreByTime", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void IncreaseScoreByTime()  {
        score += 200;
        textBox.text = score.ToString();
    }

    public void IncreaseScoreByPoints()    {
        score += 500;
        textBox.text = score.ToString();
    }

    public string GetFinalScore() {
        return score.ToString();
    }
}
