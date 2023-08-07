using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
   public void PlayGame()
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManager.Instance.CharIndex = selectedCharacter;
        Debug.Log(selectedCharacter);
       SceneManager.LoadScene("Gameplay");
    }
}