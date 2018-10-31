using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

    // Use this for initialization
   public void Play()
    {
        #pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("GamePlay"); 
        #pragma warning restore CS0618 // Type or member is obsolete
    }

    public void Quit()
    {
        Application.Quit();
    }


}
