using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : Zone
{
    [SerializeField] protected Text _winnerText;
    protected static List<GameObject> _winners;

    public HighScoreManager highScore;

    protected void Start()
    {
        if (_winners == null) _winners = new List<GameObject>();
        if (highScore == null) highScore = FindObjectOfType<HighScoreManager>();
        if(_winnerText!=null) _winnerText.text = "";
    }
    protected void DisplayWinningText(string marbleName)
    {
        if (_winnerText != null) _winnerText.text += $"{marbleName} Wins!\n";
    }
    protected override void ZoneTrigger(GameObject marble)
    {
        if(!_winners.Contains(marble)) _winners.Add(marble);
        DisplayWinningText(marble.name);
        StartCoroutine(DissableWithDelay(marble));
        if (highScore != null) highScore.GameWon();
    }
}
