using TMPro;
using UnityEngine;

public class UIDisplayDropable : MonoBehaviour
{
   
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textSnakeKilled;
    [SerializeField] private TextMeshProUGUI wave;

    public static int snakeKilled;
    public static int money = 0;
    public static int waveCount;
    public static int totaleWave;
    public static int numberToKilleInWave;
  
  
    void Start()
    {
        
        snakeKilled = 0;
        money = 0;
    }

  
    void Update()
    {
       text.text = (money + ""  );
        wave.text = ("Wave " + waveCount + " / " + totaleWave);
        textSnakeKilled.text = (snakeKilled + " / " + numberToKilleInWave);

        
    }


    public static int GetWaveCount()
    {
        return waveCount;   
    }
    public static int GetTotalWave()
    {
        return totaleWave;   
    }
    public static int EnnemyLeft()
    {
        return numberToKilleInWave - snakeKilled;   
    }
    
}
