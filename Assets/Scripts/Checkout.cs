using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Checkout : MonoBehaviour
{
    CartInventory inventory;
    public GameObject receiptUI;
    public TMP_InputField highscoreInput;
    Highscores highscore;
    public int maxHighScores;
    ReceiptEntry[] entries;
    bool showHighScore = false;

    private void Awake()
    {
        highscore = gameObject.GetComponent<Highscores>();
    }

    public void GenerateReceipt()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<CartInventory>();
        //var receipt = Instantiate(receiptUI);
        receiptUI.SetActive(true);
        ReceiptHandler handler = receiptUI.GetComponent<ReceiptHandler>();
        handler.buttonHighscore.SetActive(true);
        handler.buttonMainMenu.SetActive(false);
        handler.label.text = "Result";
        for (int i = 0; i<ItemList.instance.itemPrefabs.Count;i++)
        {
            Item currItem = ItemList.instance.itemPrefabs[i].GetComponent<Item>();
            Time.timeScale = 0;
            Debug.Log(inventory);
            int count = inventory.items.Where(x => x.itemName == currItem.itemName).Count();

            Debug.Log(currItem.itemName + " : " + count);
            if (count > 0)
            {
                int price = currItem.score * count;
                var pos = Instantiate(handler.entryPrefab, handler.listObj.transform);
                ReceiptEntry entry = pos.GetComponent<ReceiptEntry>();
                entry.itemName.text = count.ToString() + "x " + currItem.itemName;
                entry.itemAmount.text = price.ToString() + ",-";
            }

        }
        var pos1 = Instantiate(handler.entryPrefab, handler.listObj.transform);
        ReceiptEntry entry1 = pos1.GetComponent<ReceiptEntry>();
        entry1.itemName.text = "Total:";
        entry1.itemName.fontStyle = TMPro.FontStyles.Bold;
        entry1.itemAmount.text = inventory.score + ",-";
        entry1.itemAmount.fontStyle = TMPro.FontStyles.Bold;
    }

    public void UploadHighscore()
    {
        if(!string.IsNullOrEmpty(highscoreInput.text))
        {
            highscore.AddNewHighscore(highscoreInput.text, inventory.score);
        }
        InitShowHighscore();
    }
    public void InitShowHighscore()
    {
        receiptUI.SetActive(true);
        highscore.DownloadHighscores();
        ReceiptHandler handler = receiptUI.GetComponent<ReceiptHandler>();
        handler.label.text = "Highscores";
        handler.buttonHighscore.SetActive(false);
        handler.buttonMainMenu.SetActive(true);
        foreach(Transform child in handler.listObj.transform)
        {
            Destroy(child.gameObject);
        }
        entries = new ReceiptEntry[maxHighScores];
        for(int i = 0; i< entries.Length; i++)
        {
            var pos = Instantiate(handler.entryPrefab, handler.listObj.transform);
            entries[i] = pos.GetComponent<ReceiptEntry>();
        }
        ShowHighScore();
        StartCoroutine(RefreshHighScore());
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        receiptUI.SetActive(true);
        ReceiptHandler handler = receiptUI.GetComponent<ReceiptHandler>();
        handler.buttonHighscore.SetActive(true);
        handler.buttonMainMenu.SetActive(false);
        handler.label.text = "Game Over";
        handler.highScoreInput.SetActive(false);
    }
    IEnumerator RefreshHighScore()
    {
        yield return new WaitForSecondsRealtime(1);
        ShowHighScore();
        yield return new WaitForSecondsRealtime(3);
        ShowHighScore();
        yield return new WaitForSecondsRealtime(10);
        ShowHighScore();
    }
    public void ShowHighScore()
    {
        print("showhighscore");
        if(highscore.highscoresList == null || highscore.highscoresList.Length == 0)
        {
            foreach (ReceiptEntry entry in entries)
            {
                entry.itemAmount.text = "";
                entry.itemName.text = "Fetching ...";
            }
            return;
        }
        for(int i = 0; i<maxHighScores; i++)
        {
            if(i<highscore.highscoresList.Length)
            {
                entries[i].itemName.text = (i+1) + ". " + highscore.highscoresList[i].username;
                entries[i].itemAmount.text = highscore.highscoresList[i].score.ToString();
            }
            else
            {
                entries[i].itemName.text = "";
                entries[i].itemAmount.text = "";
            }
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
