using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = 5f;
	public Transform grafika;
	float turning;

	void Start()
	{
		turning = Random.Range(-20f,20f);
	}

	// Update is called once per frame
	void Update () {
		Vector2 pos = (Vector2)transform.position;
		
		Vector2 velocity = new Vector2(0, maxSpeed * Time.deltaTime);
		
		pos += Vector2.down * velocity;
		grafika.transform.rotation = Quaternion.Euler(grafika.transform.rotation.x, grafika.transform.rotation.y, grafika.transform.rotation.z + turning);

		transform.position = (Vector3)pos;
	}
}
