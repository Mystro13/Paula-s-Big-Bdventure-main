
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
   {
      InitializePlayerData();
      SceneLoader.instance.Load (SceneLoader.Scene.Cemetery);
      Debug.Log("Start Game");
   }
   public void StartMenu()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Main Menu");
   }

   public void QuitGame()
   {
      Debug.Log("Quit Game");
      Application.Quit();
      //UnityEditor.EditorApplication.isPlaying = false;
   }

   void InitializePlayerData()
   {
      if (PlayerData.current == null)
      {
         PlayerData.current = new PlayerData();
      }
      SaveLoadData.Save();
   }
}
