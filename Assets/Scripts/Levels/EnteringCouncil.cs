using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringCouncil : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag(Tags.Player.ToString()))
      {
         SceneLoader.instance.Load(SceneLoader.Scene.CouncilRoom);
      }
   }
}