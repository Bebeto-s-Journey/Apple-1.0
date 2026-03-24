using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using TMPro;

[System.Serializable] 

public class WaveClass
{

    public int amountOfEnnemyOfLevel1ToSpawn;
    public int amountOfEnnemyOfLevel2ToSpawn;
    public int amountOfEnnemyOfLevel3ToSpawn;
    public int amountOfEnnemyOfLevel4ToSpawn;
    public float timeAfterEachSpawn;



    public int TotalAmountOfEnnemyToSpawn() 
    {
        int totaleEnnemyInOnWave = Mathf.Max(amountOfEnnemyOfLevel1ToSpawn, amountOfEnnemyOfLevel2ToSpawn, amountOfEnnemyOfLevel3ToSpawn, amountOfEnnemyOfLevel4ToSpawn); 
        return totaleEnnemyInOnWave;
    }
    public int TotalEnnemySpwanedInWave()
    {
        int totaleEnnemySpawned = (amountOfEnnemyOfLevel1ToSpawn + amountOfEnnemyOfLevel2ToSpawn + amountOfEnnemyOfLevel3ToSpawn + amountOfEnnemyOfLevel4ToSpawn);
        return totaleEnnemySpawned;
    }
}

public class Spawner2 : MonoBehaviour
{
    [Header("SpawnPoints")]
    [SerializeField] private Transform[] spawnPoints;
    [Header("Ennemies To Spawn")]
    [SerializeField] private GameObject ennemyLevel1;
    [SerializeField] private GameObject ennemyLevel2;
    [SerializeField] private GameObject ennemyLevel3;
    [SerializeField] private GameObject ennemyLevel4;
    [Header("Wave Config")]
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private BoxCollider2D _collider;

    public EventHandler OnLevelFinished;
    [SerializeField] private List<WaveClass> waves = new();
    private GameObject ennemyInScene;
    private OnPLayerIsDead onPlayerDead;
    private void Start()
    {
        StartCoroutine(WaveManager());
        onPlayerDead = FindAnyObjectByType<OnPLayerIsDead>();

        conseilles.gameObject.SetActive(false);

    }



    private void Update()
    {
        ennemyInScene = GameObject.FindGameObjectWithTag("Ennemie");

    }
    int a = 0;
    int b = 0;
    int c = 0;
    int d = 0;
    int wave;
    private IEnumerator WaveManager()
    {
        UIDisplayDropable.totaleWave = waves.Count;
        for ( wave = 0; wave < waves.Count; wave++)
        {

            UIDisplayDropable.snakeKilled = 0;
            UIDisplayDropable.waveCount = wave + 1;  // pour eviter qu'il ne display Dans la UI  0 au prmier wave 
            UIDisplayDropable.numberToKilleInWave = waves[wave].TotalEnnemySpwanedInWave();


            a = 0;
            b = 0;
            c = 0;
            d = 0;

            for (int j = 0; j < waves[wave].TotalAmountOfEnnemyToSpawn(); j++)
            {
                SpawnEnnemy(ennemyLevel1, waves[wave].amountOfEnnemyOfLevel1ToSpawn, ref a);
                SpawnEnnemy(ennemyLevel2, waves[wave].amountOfEnnemyOfLevel2ToSpawn, ref b);
                SpawnEnnemy(ennemyLevel3, waves[wave].amountOfEnnemyOfLevel3ToSpawn, ref c);
                SpawnEnnemy(ennemyLevel4, waves[wave].amountOfEnnemyOfLevel4ToSpawn, ref d);

                yield return new WaitForSeconds(waves[wave].timeAfterEachSpawn);
            }

            yield return new WaitUntil(() => ennemyInScene == null);
            if (wave < waves.Count)
            {
                StartCoroutine(UpdateCountdown(timeBetweenWaves));
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }



        OnLevelFinished?.Invoke(this, EventArgs.Empty);

        if (endGamelevel)
            onPlayerDead.OnPlayerDead?.Invoke(this, EventArgs.Empty);


    }

    public bool endGamelevel;




    private void SpawnEnnemy(GameObject ennemy, int shouldSpawnOrNot, ref int j)
    {
        if (shouldSpawnOrNot > j)
        {
            int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            Instantiate(ennemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            j++;
        }

    }

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI conseilles;

    IEnumerator UpdateCountdown(float countdownValue)
    {
        conseilles.gameObject.SetActive(true);
            conseilles.text = Coseille();
        while (countdownValue != 0)
        {
            countdownText.text = $"Next Wave {Mathf.CeilToInt(countdownValue)} s";
            yield return new WaitForSeconds(1f);
            countdownValue -= 1;
        }
        if (countdownValue == 0)
        {
            countdownText.text = "";
            conseilles.text = "";
            conseilles.gameObject.SetActive(false);
            //countdownValue = 0;
        }

    }


    [SerializeField] private string[] stringTable;
    private string Coseille()
    {
        int beeR = UnityEngine.Random.Range(0, stringTable.Length); 

        return stringTable[beeR];   
    }
}


    





