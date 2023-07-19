using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button playButton, quitButton;
    [SerializeField] TMP_Text titleTxt;
    [SerializeField] Image fadeScreen;


    private void Awake()
    {
        StartCoroutine(MainMenuUIAnimation());
    }

    IEnumerator MainMenuUIAnimation()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(0, 1.5f);
        yield return new WaitForSeconds(1.5f);
        fadeScreen.gameObject.SetActive(false);
        titleTxt.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        yield return new WaitForSeconds(1f);
        playButton.gameObject.SetActive(true);
        playButton.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        yield return new WaitForSeconds(1f);
        quitButton.gameObject.SetActive(true);
        quitButton.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
    }
}
