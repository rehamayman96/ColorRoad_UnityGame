using UnityEngine;
public class OptionMenu : MonoBehaviour {
	
    public void Mute()
    {
        AudioListener.volume = 0.0f;
    }

    public void UnMute()
    {
        AudioListener.volume = 1.0f;
    }
}
