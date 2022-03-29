using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenuScript : MonoBehaviour
{
   public static bool isPaused = false;
   public GameObject pauseMenuUI;
   public GameObject optionsMenuUI;
   public GameObject[] objectsToPause;

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
      if (keyboard.backspaceKey.ReadValue() > 0f)
      {
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
            SetGameObjectState( obj, !isPaused);
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

   public void GoToMainMenu()
   {
      ResumeGame();
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Go To Main Menu");
   }

   public void OpenOptionsMenu()
   {
      if(isPaused)
      {
         SetGameObjectState(pauseMenuUI, false);
         SetGameObjectState(optionsMenuUI, true);
      }
   }
   public void CloseOptionsMenu()
   {
      PauseGame();
   }
   void SetGameObjectState(GameObject obj, bool state)
   {
      if(obj)
      {
         obj.SetActive(state);
      }
   }
}
