using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string highScorePlayerName;
    public int highScore;

    public string currentPlayer;
    public int currentScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class ScoreSave
    {
        public string playerName;
        public int highScore;
    }

    public void SaveScore()
    {
        ScoreSave save = new ScoreSave();
        save.playerName = currentPlayer;
        save.highScore = currentScore;

        highScorePlayerName = currentPlayer;
        highScore = currentScore;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreSave save = JsonUtility.FromJson<ScoreSave>(json);

            highScorePlayerName = save.playerName;
            highScore = save.highScore;
        }
    }
}
