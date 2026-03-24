using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance {  get; private set; }




    private int N1_ennemyKilled;
    private int N2_ennemyKilled;
    public float surviveTime {  get; private set; }
    public string surviveTimeString { get; private set; }
    private int minutes;
    private int seconds;
    public int hightScore;
    public int score = 0;
    private int bonusScore = 15;

  

    public delegate void SurviveTime();

    public SurviveTime surviveTimeDEL;

    
    public int Score()
    {
        return TotalEnnemyKilled() + TotalSurviveTime() * bonusScore; //
    }

    private int TotalEnnemyKilled()
    {
        return N2_GetEnnemyKilled() + N1_GetEnnemyKilled();
    }
    private int TotalSurviveTime()
    {
        return minutes * 60 + seconds;
    }

    private void Awake()
    {
        Instance = this;
       // DontDestroyOnLoad(this);
    }

    private void Start()
    {
       
        surviveTime = 0;
        hightScore = PlayerPrefs.GetInt("HightScore", 0);

        surviveTimeString = "";
        surviveTimeDEL = SurvivedTime;
    }

    private void Update()
    {
        score = Score();
        surviveTime += Time.deltaTime;

    }

    public void N1_SetEnnemyKilled(int ennemieKilled)
    {
        this.N1_ennemyKilled = ennemieKilled;
    }
    public int N1_GetEnnemyKilled()
    {
        return N1_ennemyKilled;
    }
    public void N2_SetEnnemyKilled(int ennemieKilled)
    {
        this.N2_ennemyKilled = ennemieKilled;
    }
    public int N2_GetEnnemyKilled()
    {
        return N2_ennemyKilled;
    }

    public void SurvivedTime()
    {

        minutes = Mathf.FloorToInt(surviveTime / 60);
        seconds = Mathf.FloorToInt(surviveTime % 60);

        surviveTimeString = $"{minutes} : {seconds:D2}";
    }


    public void HightScor()
    {
        if(ScoreAfterDeadOrWin.scoreCount > hightScore)
        {

            //hightScore = score;
            StartCoroutine(AddHightSocre());
        }

    }
    private IEnumerator AddHightSocre()
    {
        while (ScoreAfterDeadOrWin.scoreCount > hightScore)
        {
            hightScore ++;
            yield return new WaitForSeconds(0.05f);
        }
        if(ScoreAfterDeadOrWin.scoreCount <= hightScore)
        {
            PlayerPrefs.SetInt("HightScore", hightScore);

        }
    }
}
