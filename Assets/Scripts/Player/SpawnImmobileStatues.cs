using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImmobileStatues : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
      Debug.Log("spawner for statues");
      GameObject spawner = GameObject.Find("EnemySpawnTrigger");
      if (spawner)
      {
         Debug.Log("spawner found");
         SpawnEnemiesToPoints spawnEnemiesToPoints = spawner.GetComponent<SpawnEnemiesToPoints>();
         if (spawnEnemiesToPoints)
         {
            spawner.GetComponent<SpawnEnemiesToPoints>().CreateStatues();
            //spawner.SetActive(false);
         }
      }
   }
}
