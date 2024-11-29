using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
/*
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswersIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

        /*
        TextMeshProUGUI buttonText = answerButtons[0].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(0);

        buttonText = answerButtons[1].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(1);

        buttonText = answerButtons[2].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(2);

        buttonText = answerButtons[3].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(3);
        

    }
    void start()
    {
        GetNextQuestion();
        //DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage ;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswersIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswersIndex);
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswersIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }
    
    void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++) 
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i< answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>(); 
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}

*/

public class Quiz : MonoBehaviour
{

    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswersIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();

    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;

        // Doğru cevap kontrolü
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswersIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswersIndex);
            questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswersIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    // Yeni soruyu almak ve butonları yeniden etkinleştirmek için
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);  // Butonları yeniden etkinleştir
            SetDefaultButtonSprites();  // Butonları varsayılan sprite'larla sıfırla
            GetRandomQuestion();
            DisplayQuestion();
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Contains(currentQuestion);
        }
        questions.Remove(currentQuestion);
    }

    // Soruyu görüntülemek için fonksiyon
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    // Butonların etkinlik durumunu ayarlamak için fonksiyon
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    // Butonları varsayılan sprite'lara sıfırlamak için fonksiyon
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
