using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int totalCoin;
    public TMP_Text topBarText;
    public TMP_Text questionText;
    public TMP_Text ResultText,RewardText,TotalRewardText,showTotalRewardText;

    public Button[] answerButtons;
    public GameObject ResultPanel,FinalResultPanel,QuizPanel,LoadingPanel;
    private string[] questions = {
        "Which amusement park was the first to be built in the world?",
        "What is the tallest roller coaster in the world?",
        "Which amusement park is home to the iconic 'It's a Small World' ride?"
    };

    private string[][] answerOptions = {
        new string[] { "A) Disneyland", "B) Tivoli Gardens", "C) Luna Park" },
        new string[] { "A) Kingda Ka", "B) Steel Dragon 2000", "C) Formula Rossa" },
        new string[] { "A) Universal Studios", "B) Six Flags Magic Mountain", "C) Disneyland" }
    };
    private string[] questions2 = {
        "What is the result of 4 + 8 * 11?",
        "What is the value of 9 / 3 * 2?",
        "What is the answer to 5 - 2 * 3 + 8?"
    };

    private string[][] answerOptions2 = {
        new string[] { "A) 88", "B) 96", "C) 52" },
        new string[] { "A) 6", "B) 3", "C) 2" },
        new string[] { "A) 3", "B) 9", "C) -1" }
    };

    private int[] correctAnswers = { 1, 0, 2 };

    private int currentQuestionIndex;
    private int selectedAnswerIndex;
    public int TotalReward;
    public bool istrivia;

    public void SelectAnswer(int answerIndex)
    {
        selectedAnswerIndex = answerIndex;
        if (istrivia)
            CheckAnswer();
        else
            CheckAnswer2();
    }

    public void CheckAnswer()
    {
        if (selectedAnswerIndex == correctAnswers[currentQuestionIndex])
        {
            ResultPanel.SetActive(true);
            ResultText.text = "Correct Answer!";
            RewardText.text = "250 B";
            TotalReward += 250;
        }
        else
        {
            ResultPanel.SetActive(true);
            ResultText.text = "Incorrect Answer!";
            RewardText.text = "0 B";
            
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            FinalResultPanel.SetActive(true);
            totalCoin += TotalReward;
            TotalRewardText.text = TotalReward.ToString();
        }
    }
    public void CheckAnswer2()
    {
        if (selectedAnswerIndex == correctAnswers[currentQuestionIndex])
        {
            ResultPanel.SetActive(true);
            ResultText.text = "Correct Answer!";
            RewardText.text = "250 B";
            TotalReward += 250;
        }
        else
        {
            ResultPanel.SetActive(true);
            ResultText.text = "Incorrect Answer!";
            RewardText.text = "0 B";

        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion2();
        }
        else
        {
            FinalResultPanel.SetActive(true);
            totalCoin += TotalReward;
            TotalRewardText.text = TotalReward.ToString();
        }
    }

    private void DisplayQuestion()
    {
        showTotalRewardText.text = TotalReward.ToString();
        questionText.text = questions[currentQuestionIndex];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = answerOptions[currentQuestionIndex][i];
        }
    }
    private void DisplayQuestion2()
    {
        showTotalRewardText.text = TotalReward.ToString();

        questionText.text = questions2[currentQuestionIndex];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = answerOptions2[currentQuestionIndex][i];
        }
    }
    public void ResetQuiz()
    {
        currentQuestionIndex = 0;
        selectedAnswerIndex = -1;
        TotalReward = 0;
    }
    public void StartQuizLoading(bool isTrivia)
    {
        istrivia = isTrivia;
        LoadingPanel.SetActive(true);
        Invoke("OpenQuiz", 2);

    }
    void OpenQuiz()
    {
        LoadingPanel.SetActive(false);
        QuizPanel.SetActive(true);
        if (istrivia)
            DisplayQuestion();
        else
            DisplayQuestion2();
    }
    public void changeTopBarText(string newText)
    {
        topBarText.text = newText;
    }
    public void GetBonus()
    {
        totalCoin += 1000;
    }
   

}
