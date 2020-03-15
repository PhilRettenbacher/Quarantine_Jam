using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReceiptHandler : MonoBehaviour
{
    public GameObject listObj;
    public List<ReceiptEntry> entries = new List<ReceiptEntry>();
    public GameObject entryPrefab;
    public TextMeshProUGUI label;
    public GameObject highScoreInput;
    public GameObject buttonHighscore;
    public GameObject buttonMainMenu;
}
