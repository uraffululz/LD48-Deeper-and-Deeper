using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

	GameManager gameMan;
	Camera mainCam;
	CameraMove camMove;

	public Vector3 moveDir = new Vector3();
	float speed = 5;
	

	void Start() {
		gameMan = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameManager>();
        mainCam = Camera.main;
		camMove = mainCam.gameObject.GetComponent<CameraMove>();
    }


    void Update() {
        //transform.position = Vector3.Lerp(transform.position, transform.position + moveDir, speed * Time.deltaTime);
    }


	void LateUpdate () {
		if (!gameMan.gameOver) {
			Vector3 playerPos = transform.position + (moveDir * speed * Time.deltaTime);// + (-Vector3.up * camMove.camSpeed * Time.deltaTime);
			playerPos.x = Mathf.Clamp(playerPos.x, mainCam.transform.position.x + (camMove.bounds.x * .95f), mainCam.transform.position.x - (camMove.bounds.x * .95f));
			playerPos.y = Mathf.Clamp(playerPos.y, mainCam.transform.position.y + (camMove.bounds.y * 1.2f), mainCam.transform.position.y - (camMove.bounds.y * .8f));
			playerPos.z = 0;
			transform.position = playerPos;
		}
	}


	public void OnMove (InputAction.CallbackContext context) {
		moveDir = context.ReadValue<Vector2>();

		if (context.canceled) {
			moveDir = Vector2.zero;
		}
	}
}
