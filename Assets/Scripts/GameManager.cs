using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject slimePrefab;
    public GameObject portal;
    public Transform spawnpoint1, spawnpoint2;
    [SerializeField] float spawnCooldown;
    [SerializeField] TMP_Text ultimateInfoTxt;

    private void Start()
    {
        StartCoroutine(UltimateAbilityInfoText());
        StartCoroutine(SlimeSpawner());
    }

    IEnumerator SlimeSpawner()
    {
        PortalSpawner(spawnpoint1);
        yield return new WaitForSeconds(.2f);
        Instantiate(slimePrefab, spawnpoint1.position, spawnpoint1.rotation);
        yield return new WaitForSeconds(spawnCooldown);
        PortalSpawner(spawnpoint2);
        yield return new WaitForSeconds(.2f);
        Instantiate(slimePrefab, spawnpoint2.position, spawnpoint2.rotation);
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SlimeSpawner());
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
}
