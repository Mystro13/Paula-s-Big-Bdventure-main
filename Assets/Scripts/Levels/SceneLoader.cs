using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader:MonoBehaviour
{
   public static SceneLoader instance;
   public enum Scene
   {
      MainMenu,
      Cemetery,
      FirstFloor,
      CouncilRoom,
      SecondFloor,
      ThirdFloor,
      Throne,
   }

   //sliders
   public Slider AudioVolume;
   public Slider EFXVolume;
   public Slider CameraSensitivity;
   public float MaxAudioVolume  = 10;
   public float MaxEFXVolume = 10;
   public float MaxCameraSensitivity = 10;
   //We may need to save the full player between scenes
   GameObject savedPlayer;
   PlayerInteraction playerInteraction;
   //When we save player between scene, we need to define where to spawn the player in the next scene.
   //We could use the scene loader object as the place to spawn the player
   public Transform playerSceneTarget;
   public void Load(Scene scene)
   {
      SaveLoadData.Save();
      SceneManager.LoadScene(scene.ToString());
      SaveLoadData.Load();
      if (savedPlayer)
      {
         playerInteraction = savedPlayer.GetComponent<PlayerInteraction>();
         if (playerInteraction)
         {
            playerInteraction.SetPlayerData(PlayerData.current);
         }
      }
   }

   void Awake()
   {
      if (instance == null)
      {
         DontDestroyOnLoad(gameObject);
         instance = this;
      }
      else if (instance != this)
      {
         Destroy(gameObject);
      }

      if (playerSceneTarget == null)
         playerSceneTarget = gameObject.transform;

      if (gameObject)
      {
         if (PlayerData.current != null)
         {
            AudioVolume.value = PlayerData.current.AudioVolume;
            EFXVolume.value = PlayerData.current.EFXVolume;
            CameraSensitivity.value = PlayerData.current.CameraSensitivity;
         }
      }
   }

   public void AssignPlayer(GameObject player)
   {
      savedPlayer = player;
   }

   void Update()
   {
      Debug.Log($"Mouse sensitivity {CameraSensitivity.value * MaxCameraSensitivity}");
   }
}
