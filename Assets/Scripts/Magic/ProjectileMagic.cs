using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMagic : MagicBase
{
    public Projectile projectilePrefab;
    public GameObject projectileSpawnPoint;


    public override void Magic()
    {
        Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
        projectile.Init(playerMovement.playerFacingRight);
        
        
    }
}
