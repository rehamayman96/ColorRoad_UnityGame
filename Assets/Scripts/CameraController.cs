using UnityEngine;

public class CameraController : MonoBehaviour {
    //This is Main Camera in the Scene
    Camera m_MainCamera;
    //This is the second Camera and is assigned in inspector
    public Camera m_CameraTwo;
    public Canvas canvas;
    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;
        //Use this to disable secondary Camera
        m_CameraTwo.enabled = false;
    }

    void Update()
    {
        //Press the L Button to switch cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera(); 
        }
    }

    public void SwitchCamera()
    {
        if (m_MainCamera.enabled)
        {
            //Enable the second Camera
            m_CameraTwo.enabled = true;
            canvas.worldCamera = m_CameraTwo;
            //The Main first Camera is disabled
            m_MainCamera.enabled = false;
        }
        //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
        else if (!m_MainCamera.enabled)
        {
            //Disable the second camera
            m_CameraTwo.enabled = false;

            //Enable the Main Camera
            m_MainCamera.enabled = true;
            canvas.worldCamera = m_MainCamera;

        }
    }
}
