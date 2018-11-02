using UnityEngine;

public class CameraConstrain : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(2.07685f, transform.position.y * 1.0f, transform.position.z * 1.0f);
	}
}
