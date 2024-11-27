using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswersIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

        // Soruyu başlatmak için GetNextQuestion çağırıyoruz.
        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        // Doğru cevap kontrolü
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswersIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswersIndex);
            questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswersIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        // Cevaplardan sonra butonları devre dışı bırakıyoruz.
        SetButtonState(false);
    }

    // Yeni soruyu almak ve butonları yeniden etkinleştirmek için
    void GetNextQuestion()
    {
        SetButtonState(true);  // Butonları yeniden etkinleştir
        SetDefaultButtonSprites();  // Butonları varsayılan sprite'larla sıfırla
        DisplayQuestion();
    }

    // Soruyu görüntülemek için fonksiyon
    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
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
