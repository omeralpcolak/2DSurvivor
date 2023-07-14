using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelXPManager : MonoBehaviour
{

    public GameObject xpPrefab;
    public float currentXp, maxXp;
    float targetXp;
    public Image xpImg;
    float addSpeed = .5f;
    public bool canXpCreated;
    public float currentLevel, nextLevel;
    [SerializeField] TMP_Text currentLevelTxt, nextLevelTxt;
    // Start is called before the first frame update
    void Start()
    {
        canXpCreated = true;
        currentLevel = 1;
        nextLevel = currentLevel + 1;
        currentXp = 0;
        maxXp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelUI();
        LevelUp();
        



        xpImg.fillAmount = Mathf.MoveTowards(xpImg.fillAmount, targetXp, addSpeed * Time.deltaTime);
    }



    public void XPSpawner(Transform xpLocation)
    {   
        if(canXpCreated)
        {
            Instantiate(xpPrefab, xpLocation.position, xpLocation.rotation);
        }
        
    }

    public void UpdateXpBar()
    {
        targetXp = currentXp / maxXp;
       
    }

    public void LevelUp()
    {
        if (currentXp >= maxXp)
        {
            currentXp = 0;
            maxXp *= 1.5f;
            currentLevel++;
            nextLevel++;
            UpdateXpBar();
        }
        
    }

    void UpdateLevelUI()
    {
        currentLevelTxt.text = currentLevel.ToString();
        nextLevelTxt.text = nextLevel.ToString();
    }
}
