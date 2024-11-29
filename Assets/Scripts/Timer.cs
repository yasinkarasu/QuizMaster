using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCompleteAnswer = 10f;


    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    float timerValue;


    void Update() 
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion; // 5/10 = 0,5
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCompleteAnswer;
            }
        }
        else
        {
             if(timerValue > 0)
             {
                fillFraction = timerValue / timeToShowCompleteAnswer;
             }
             else
             {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
             }
        }

        Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    } 

}
