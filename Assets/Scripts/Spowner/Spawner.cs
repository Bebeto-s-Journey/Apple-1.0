using System.Collections;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("SpawnPoint")]
    [SerializeField] Transform[] ennemiespownPoints;
    [Header("Ennemie")]
    [SerializeField] GameObject normaleEnnemiesprefabe;
    [SerializeField] GameObject sniperEnnemiesprefabe;
  
    [Header("Wave")]
    [SerializeField] private float timeBetweenWaves;
    [Header("Wave One")]
    [SerializeField] private int waveOneNumberToSpawn;   
    [SerializeField] private float waveOneTimeAfterEachSpawn;  
    [Header("Wave Two")]
    [SerializeField] private int waveTwoNumberToSpawn;   
    [SerializeField] private int waveTwoSniperNumberToSpawn;   
    [SerializeField] private float waveTwoTimeAfterEachSpawn;  
    [Header("Wave three")]
    [SerializeField] private int waveThreeNumberToSpawn;   
    [SerializeField] private int waveThreeSniperNumberToSpawn;   
    [SerializeField] private float waveThreeTimeAfterEachSpawne;

    public EventHandler OnLevelFinished;
    private GameObject ennemieInScene;    // Check if non ennemiee to go next wave
    private int waveCounter;
    private int numberTokillInWave;




    private void Start()
    {
       StartCoroutine(spownNormaleEnnemies());
    }
    private void Update()
    {
        UIDisplayDropable.waveCount = waveCounter;
        UIDisplayDropable.numberToKilleInWave = numberTokillInWave;

        ennemieInScene = GameObject.FindGameObjectWithTag("Ennemie");   
    }


    private IEnumerator spownNormaleEnnemies()
   {
       
       for (int i = 0; i != waveOneNumberToSpawn; i++)
       {
            waveCounter = 1;
            numberTokillInWave = waveOneNumberToSpawn;
            int random = Random.Range(0, ennemiespownPoints.Length);
            Instantiate(normaleEnnemiesprefabe, ennemiespownPoints[random].position, Quaternion.identity);
            yield return new WaitForSeconds(waveOneTimeAfterEachSpawn);
            // Reinitialize the number Of player killed
       }

        yield return new WaitUntil(() => ennemieInScene == null ) ;
        Debug.Log("Wave One ends");
        yield return new WaitForSeconds(timeBetweenWaves);
        Debug.Log("Wave Two Started");

        UIDisplayDropable.snakeKilled = 0;


        for (int i = 0; i != waveTwoNumberToSpawn; i++)
        {          
            waveCounter = 2;
            numberTokillInWave = waveTwoNumberToSpawn + waveTwoSniperNumberToSpawn;
            int random = Random.Range(0, ennemiespownPoints.Length);
            Instantiate(normaleEnnemiesprefabe, ennemiespownPoints[random].position, Quaternion.identity);
            int _random = Random.Range(0, ennemiespownPoints.Length);
            if (i < waveTwoSniperNumberToSpawn) Instantiate(sniperEnnemiesprefabe, ennemiespownPoints[_random].position, Quaternion.identity); 
            yield return new WaitForSeconds(waveTwoTimeAfterEachSpawn);
        }
       
        yield return new WaitUntil(() => ennemieInScene == null ) ;
        Debug.Log("Wave Two ends");
        yield return new WaitForSeconds(timeBetweenWaves);
        Debug.Log("Wave Three Started");

        UIDisplayDropable.snakeKilled = 0;


        for (int i = 0; i != waveThreeNumberToSpawn; i++)
        {
            waveCounter = 3;
            numberTokillInWave = waveThreeNumberToSpawn + waveThreeSniperNumberToSpawn;
            int random = Random.Range(0, ennemiespownPoints.Length);
            Instantiate(normaleEnnemiesprefabe, ennemiespownPoints[random].position, Quaternion.identity);
            int _random = Random.Range(0, ennemiespownPoints.Length);
            if (i < waveThreeSniperNumberToSpawn) Instantiate(sniperEnnemiesprefabe, ennemiespownPoints[_random].position, Quaternion.identity);
            yield return new WaitForSeconds(waveThreeTimeAfterEachSpawne);
        }

        yield return new WaitUntil(() => ennemieInScene == null ) ;
        OnLevelFinished?.Invoke(this, EventArgs.Empty);
    }


}
