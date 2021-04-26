using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	//GameObject player;

	Skybox depths;
	[SerializeField] Color initialDepthsColor;

	public float camSpeed = 1.5f;// {get; private set;}

	public Vector3 bounds;

 
	void Start() {
		//player = GameObject.FindGameObjectWithTag("Player");
		depths = GetComponent<Skybox>();
		depths.material.color = initialDepthsColor;

        bounds = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
    }


    void Update() {
        //transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.up, camSpeed * Time.deltaTime);

		//depths
		//RenderSettings.skybox.
    }


	void LateUpdate () {
		//Vector3 playerPos = player.transform.position + (player.GetComponent<PlayerMove>().moveDir;
		//playerPos.x = transform.position.x + Mathf.Clamp(playerPos.x, bounds.x, bounds.x * -1);
		//playerPos.y = Mathf.Clamp(playerPos.y, transform.position.y + bounds.y, transform.position.y - bounds.y);
		//player.transform.position = playerPos;
	}
}
