using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenuScript : MonoBehaviour
{
   public GameObject pauseMenuUI;
   public GameObject optionsMenuUI;
<<<<<<< HEAD

=======
   public GameObject[] objectsToPause;
   bool pauseAction = false;
   private float noClickTime = 0.0f;
   private void Awake()
   {
      if (pauseMenuUI)
      {
         pauseMenuUI.SetActive(false);
      }
      if(optionsMenuUI)
      { 
         optionsMenuUI.SetActive(false);
      }
   }
   void Update()
   {
      Keyboard keyboard = Keyboard.current;
      if (keyboard.backspaceKey.ReadValue() > 0f && noClickTime <=0f )
      {
         pauseAction = true;
         Debug.Log($"pause action {pauseAction}");
      }
      noClickTime -= Time.deltaTime;
   }
   void FixedUpdate()
   {
      Debug.Log($"Fxed Update {pauseAction}");
      if (pauseAction)
      {
         noClickTime = 1f;
         pauseAction = false;
         if (isPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
         foreach (GameObject obj in objectsToPause)
         {
            SetGameObjectState(obj, !isPaused);
         }
         if (PlayerData.current != null)
         {
            PlayerData.current.AudioVolume = SceneLoader.instance.AudioVolume.value;
            PlayerData.current.EFXVolume = SceneLoader.instance.EFXVolume.value;
            PlayerData.current.CameraSensitivity = SceneLoader.instance.CameraSensitivity.value;
         }
      }
   }
   void ResumeGame()
   {
      SetGameObjectState(pauseMenuUI, false);
      SetGameObjectState(optionsMenuUI, false);
      
      isPaused = false;
      Time.timeScale = 1f;
   }

   void PauseGame()
   {
      SetGameObjectState(pauseMenuUI, true);
      SetGameObjectState(optionsMenuUI, false);
      isPaused = true;
      Time.timeScale = 0f;
   }
>>>>>>> 6a4d87566346ef2fee92ee3f4c70a6305ffe92bb

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
