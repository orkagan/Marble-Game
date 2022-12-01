using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HighScoreData
{
    public float score;

    public HighScoreData() { score = float.MaxValue; }
    public HighScoreData(float score)
    {
        this.score = score;
    }
    public void SubmitScore(float score)
    {
        if (this.score > score)
        {
            this.score = score;
        }
    }
}
