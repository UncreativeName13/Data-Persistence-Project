using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighScore()
    {
        ScoreManager.Instance.LoadScore();
        scoreText.SetText($"Best Score : {ScoreManager.Instance.highScorePlayerName}: {ScoreManager.Instance.highScore}");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ScoreManager.Instance.currentPlayer = nameField.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
