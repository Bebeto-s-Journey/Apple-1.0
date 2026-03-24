using UnityEngine;
using UnityEngine.Video;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject playScreen;
    [SerializeField] private GameObject skipe;

    private bool dontShowAgain;


    private void Awake()
    {
        dontShowAgain = PlayerPrefs.GetInt("objectKeyedee", 0) == 1;
    }
    private void Start()
    {

        if (!dontShowAgain)
        {

            if(PlayerPrefs.GetInt("objectKeyedee", 0) == 1)
            {
               skipe.SetActive(true);
            
            }


            video.loopPointReached += OnCinematicEnd;

        }
        else
        {
            ShowPlayScreen();
        }

    }

   

    private void OnCinematicEnd(VideoPlayer vp)
    {
        ShowPlayScreen();
    }


    private void ShowPlayScreen()
    {
        
        playScreen.SetActive(true);
        Destroy(transform.gameObject);
    }

    public void Skipe()
    {
       
            ShowPlayScreen();

    }
    void OnDestroy()
    {
        // Save the state when the object is destroyed
        PlayerPrefs.SetInt("objectKeyedee", 1);
        PlayerPrefs.Save();
    }

}
