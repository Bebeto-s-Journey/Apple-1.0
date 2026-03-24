using System;
using System.Collections;

using TMPro;
using UnityEngine;

public class ScoreAfterDeadOrWin : MonoBehaviour
{
    [SerializeField] private OnPLayerIsDead PlayerDead;

    [SerializeField] private Canvas canvas;

    [SerializeField] private TextMeshProUGUI cointCount;

    [SerializeField] private TextMeshProUGUI surviveTime;

    [SerializeField] private TextMeshProUGUI numberKilled;
    public static int N1_numberOfEnnemyKilled;
    [SerializeField] private TextMeshProUGUI N2_ennemyKilled;
    public static int N2_numberOfEnnemyKilled;

    [SerializeField] private TextMeshProUGUI wave;
    [SerializeField] private TextMeshProUGUI ennemyrestant;
     private int waveCount;
     private int totalWaveCount;
     private int ennemyLeft;
    

    [SerializeField] private TextMeshProUGUI score;
     public static int scoreCount;
    [SerializeField] private TextMeshProUGUI hightScore;
  




    void Start()
    {
        N1_numberOfEnnemyKilled = 0;
        N2_numberOfEnnemyKilled = 0;
        scoreCount = 0;
        PlayerDead.OnPlayerDead += ShowScoreUI;
        time = 0.5f;
        divider = 1;

}

   
 


    private void ShowScoreUI(object sender, EventArgs e)
    {
        ennemyLeft = UIDisplayDropable.EnnemyLeft();
        waveCount = UIDisplayDropable.GetWaveCount();
        totalWaveCount = UIDisplayDropable.GetTotalWave();
        StartCoroutine(ShowScoreUI());
        StartCoroutine(CountScore());
    }
   /* private void CameraOutZoom(object sender, EventArgs e)
    {
        NextLevel();
    }*/

    IEnumerator ShowScoreUI()
    {
        ScoreManager.Instance.N1_SetEnnemyKilled(N1_numberOfEnnemyKilled);
        ScoreManager.Instance.N2_SetEnnemyKilled(N2_numberOfEnnemyKilled);

        yield return new WaitForSeconds(2);

        hightScore.text = ScoreManager.Instance.hightScore.ToString();
        cointCount.text = UIDisplayDropable.money.ToString();
        numberKilled.text = (ScoreManager.Instance.N1_GetEnnemyKilled() + ScoreManager.Instance.N2_GetEnnemyKilled()).ToString();
        surviveTime.text = ScoreManager.Instance.surviveTimeString;
        if(canvas.enabled == false)
        ScoreManager.Instance.surviveTimeDEL();

        wave.text = $" {waveCount} / {totalWaveCount}";  
        ennemyrestant.text = ennemyLeft.ToString();  
        canvas.enabled = true;
    }

    /* private void NextLevel()
     {
         Debug.Log("GameEnds");
     }*/

    private float time = 0.5f;
    private float divider = 1;
    private IEnumerator CountScore()
    {
        
        while(scoreCount < ScoreManager.Instance.score)
        {
            scoreCount++;
            score.text = scoreCount.ToString();
            yield return new WaitForSeconds(time / divider);
            divider += time / divider;
        }
        if (scoreCount == ScoreManager.Instance.score)
        {
            ScoreManager.Instance.HightScor();
        }
    }

}
