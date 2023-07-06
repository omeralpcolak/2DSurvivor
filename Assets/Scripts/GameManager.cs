using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slimePrefab;
    public GameObject portal;
    public Transform spawnpoint1, spawnpoint2;
    [SerializeField] float spawnCooldown;

    private void Start()
    {
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
}
