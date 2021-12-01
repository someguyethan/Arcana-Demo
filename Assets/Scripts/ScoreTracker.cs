using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float score;

    public static ScoreTracker Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score.ToString();
    }
}
