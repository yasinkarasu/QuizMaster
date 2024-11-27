using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCompleteAnswer = 10f;

    public bool isAnsweringQuestion = false;

    float timerValue;


    void Update() 
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCompleteAnswer;
            }
        }
        else
        {
             if(timerValue <=0)
             {
                isAnsweringQuestion = true;
                timerValue = timeToShowCompleteAnswer;
             }
        }

        if(timerValue <= 0)
        {
            timerValue = timeToCompleteQuestion;
            timerValue = timeToCompleteQuestion; 
        }
        
        Debug.Log(timerValue);
    } 

}
