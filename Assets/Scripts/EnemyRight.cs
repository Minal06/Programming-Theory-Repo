using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : Enemy
{ 
  public override void SpawnCheck()
    {
        if (transform.position.x > -spawnBoundry)
        {
            MoveLeft();
        }
    }   
   
}
