using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {
	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rigidBody;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording){
			Record ();
		}else {
			PlayBack();
		}

	}

	void PlayBack(){
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;

		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}

	void Record ()
	{	
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame(float time, Vector3 pos, Quaternion rot){
		this.frameTime = time;
		this.position = pos;
		this.rotation = rot;
	}


}