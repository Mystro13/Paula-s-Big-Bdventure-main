
using UnityEngine;

public class MainMenu : MonoBehaviour
{

   public void StartGame()
   {
      SceneLoader.instance.Load (SceneLoader.Scene.Cemetery);
      Debug.Log("Start Game");
   }
   public void StartMenu()
   {
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Main Menu");
   }

   public void QuitGame()
   {
      
      Debug.Log("Quit Game");
      Application.Quit();
      //UnityEditor.EditorApplication.isPlaying = false;
   }
}
