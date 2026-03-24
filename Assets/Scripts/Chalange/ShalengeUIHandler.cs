using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShalengeUIHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI rafaleT;
    [SerializeField] private TextMeshProUGUI shortyT;
    [SerializeField] private TextMeshProUGUI upGradeFeedBack;
    [SerializeField] private TextMeshProUGUI shortyKilled;
    [SerializeField] private TextMeshProUGUI rifleKilled;
    [SerializeField] private LevelUpGuns levelUpGuns;
    [SerializeField] private float delay;
    [SerializeField] private GameObject checkRafale;
    [SerializeField] private GameObject checkShorty;

    public List<ChalengeSetUp> currentChlenge = new List<ChalengeSetUp>();
    public static event Action OnRifleUpdate;
    public static event Action OnShortyUpdate;
    private void Start()
    {
        IniteChalenges();
        upGradeFeedBack.text = "";

    }

    public static bool rbee = true;
    public static bool stee = true;
    private void OnEnable()
    {
        ChalengeSetUp.OnGunUpgraded += ChalengeSetUp_OnGunUpgraded;
    }

    private void ChalengeSetUp_OnGunUpgraded()

    {
        if (currentChlenge[0].completed && rbee)
        {
            StartCoroutine(UpgradFeedback("Rifle Upgraded "));
            GunVisualeChenger.vusuale.ChangeRifleColor(0.25f);
            OnRifleUpdate?.Invoke();
            rbee = false;
        }
        if (currentChlenge[1].completed && stee)
        {
            StartCoroutine(UpgradFeedback("ShortGun Upgraded "));
            GunVisualeChenger.vusuale.ChangeShortyColor(0.25f);
            OnShortyUpdate?.Invoke();
            stee = false;    
        }
        if (currentChlenge[0].completed && currentChlenge[1].completed)
        {
            Debug.Log("ChalangeEnds");
            StartCoroutine(Clear());

        }
    }
    private void Update()
    {
        checkRafale.SetActive(currentChlenge[0].completed);
        checkShorty.SetActive(currentChlenge[1].completed);
        rifleKilled.text = ($"Killed {levelUpGuns.rafaleEnnemyKilled} / {currentChlenge[0].killeRequired}");
        shortyKilled.text = ($"Killed {levelUpGuns.shortyEnnemyKilled} / {currentChlenge[1].killeRequired}");
    }

    private void IniteChalenges()
    {
        if (levelUpGuns.GetcurrentChalange() == null) return;
        currentChlenge = levelUpGuns.GetcurrentChalange();
        rafaleT.text = ($"Kille {currentChlenge[0].killeRequired} Snakes With The Rifle");
        shortyT.text = ($"Kille {currentChlenge[1].killeRequired} Snakes WIth The ShortGun");

    }

    private IEnumerator Clear()
    {

        yield return new WaitForSeconds(5f);
        levelUpGuns.ClearChalenges();
        yield return new WaitForSeconds(0.2f);
        IniteChalenges();
        rbee = true;
        stee = true;
        // call chalenge feedback


    }
    private IEnumerator UpgradFeedback(string text)
    {

        upGradeFeedBack.text = text.Trim();
        yield return new WaitForSeconds(delay);
        upGradeFeedBack.text = "";

    }

    public void Show()
    {
        animator.Play("Chow");
        Time.timeScale = 0.2f;
    }
    public void Hide()
    {
        animator.Play("Hide");
        Time.timeScale = 1;
    }
}
