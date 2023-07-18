using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject slimePrefab;
    public GameObject flyEnemyPrefab;
    public GameObject portal;
    public Transform spawnpoint1, spawnpoint2;
    public Transform flyEnemySpawnPoint;
    [SerializeField] float slimeSpawnCooldown;
    [SerializeField] float flyEnemySpawnCooldown;
    [SerializeField] TMP_Text ultimateInfoTxt;
    [SerializeField] TMP_Text killCountTxt;
    [SerializeField] TMP_Text surviveTimeTxt;
    [SerializeField] TMP_Text gameOverTxt;
    [SerializeField] TMP_Text finalKillCountTxt;
    [SerializeField] TMP_Text finalSurvivorTimeTxt;
    [SerializeField] Image fadeScreen;
    public int killCount;
    public float surviveTime;
    public float targetSurviveTime;
    public bool gameStart;


    private void Awake()
    {
        instance = this;
        gameStart = true;
    }
    private void Start()
    {   
        if(gameStart)
        {
            StartCoroutine(UltimateAbilityInfoText());
            StartCoroutine(SlimeSpawner());
            StartCoroutine(FlyEnemySpawner());

            killCount = 0;
            surviveTime = 20f;
            targetSurviveTime = 30f;
        }
        
        
    }

    private void Update()
    {
        if(gameStart)
        {
            UpdateKillCount();
            UpdateSurviveTime();
            SlimeSpawnCooldownController();
        }

        if(!gameStart)
        {
            StartCoroutine(GameOverScene());
        }

        
        
        
    }

    IEnumerator SlimeSpawner()
    {
        PortalSpawner(spawnpoint1);
        yield return new WaitForSeconds(.2f);
        Instantiate(slimePrefab, spawnpoint1.position, spawnpoint1.rotation);
        yield return new WaitForSeconds(slimeSpawnCooldown);
        PortalSpawner(spawnpoint2);
        yield return new WaitForSeconds(.2f);
        Instantiate(slimePrefab, spawnpoint2.position, spawnpoint2.rotation);
        yield return new WaitForSeconds(slimeSpawnCooldown);
        StartCoroutine(SlimeSpawner());
    }

    IEnumerator FlyEnemySpawner()
    {
        float threshold = 30f;

        while (true)
        {
            if (surviveTime >= threshold)
            {
                GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("FlyEnemy");

                if (existingEnemies.Length == 0)
                {
                    Instantiate(flyEnemyPrefab, flyEnemySpawnPoint.position, flyEnemySpawnPoint.rotation);
                }

               
            }

            yield return null;
        }

    }

    void PortalSpawner(Transform spawnPoint)
    {
        Instantiate(portal, spawnPoint.position, spawnPoint.rotation);
    }

    IEnumerator UltimateAbilityInfoText()
    {
        ultimateInfoTxt.GetComponent<CanvasGroup>().DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        ultimateInfoTxt.GetComponent<CanvasGroup>().DOFade(0, 3f);
    }

    public void UpdateKillCount()
    {
        killCountTxt.text = "Kill Count: "+ killCount;
    }

    private void UpdateSurviveTime()
    {
        surviveTime += Time.deltaTime;
        surviveTimeTxt.text = "Survival Time: " + surviveTime.ToString("0");
    }

    private void SlimeSpawnCooldownController()
    {
        if(surviveTime >= targetSurviveTime)
        {
            slimeSpawnCooldown *= 0.8f;
            targetSurviveTime *= 2;
        }
    }

    
     
    public IEnumerator GameOverScene()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 3f);
        yield return new WaitForSeconds(1);
        gameOverTxt.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        yield return new WaitForSeconds(1);
        finalKillCountTxt.text = "Kill Count: " + killCount.ToString();
        finalKillCountTxt.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        yield return new WaitForSeconds(1);
        finalSurvivorTimeTxt.text = "Survive Time: " + surviveTime.ToString("0");
        finalSurvivorTimeTxt.GetComponent<CanvasGroup>().DOFade(1, 1.5f);

    }
}
