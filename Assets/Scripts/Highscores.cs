using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    const string privateCode = "0nyxDy71_0GstFw8j09zHADZ3JUnGYu0W7s9izH3iluw";
    const string publicCode = "5e6e75c2fe232612b8b07804";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;

    void Awake()
    {
        /*AddNewHighscore("test1", 10);
        AddNewHighscore("test2", 40);
        AddNewHighscore("test3", 60);

        DownloadHighscores();
        */
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoresFromDataBase());
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if(string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
        }
        else
        {
            print("Error uploading " + www.error);
        }
    }

    IEnumerator DownloadHighscoresFromDataBase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print(www.text);
            FormatHighScores(www.text);
        }
        else
        {
            print("Error Downloading " + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        highscoresList = new Highscore[entries.Length];

        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);
            string username = entryInfo[0];
            int score = Int32.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
        }
    }

}
public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
}
