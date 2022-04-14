using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenuScript : MonoBehaviour
{
   public GameObject pauseMenuUI;
   public GameObject optionsMenuUI;


   public void GoToMainMenu()
   {
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Go To Main Menu");
   }

   public void OpenOptionsMenu()
   {
      SetGameObjectState(pauseMenuUI, false);
      SetGameObjectState(optionsMenuUI, true);
   }

   public void CloseOptionsMenu()
   {
      if (PlayerData.current != null)
      {
         PlayerData.current.AudioVolume = SceneLoader.instance.AudioVolume.value;
         PlayerData.current.EFXVolume = SceneLoader.instance.EFXVolume.value;
         PlayerData.current.CameraSensitivity = SceneLoader.instance.CameraSensitivity.value;
      }
      SetGameObjectState(pauseMenuUI, true);
      SetGameObjectState(optionsMenuUI, false);
   }
   void SetGameObjectState(GameObject obj, bool state)
   {
      if (obj)
      {
         obj.SetActive(state);
      }
   }
}
