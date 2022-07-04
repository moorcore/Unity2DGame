using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;

    TMP_Text score;

    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}
