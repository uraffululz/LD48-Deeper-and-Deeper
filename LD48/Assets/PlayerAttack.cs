using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour {

	GameManager gameMan;
	Camera mainCam;

	//[SerializeField] GameObject gun;
	[SerializeField] GameObject harpoon;
	GameObject loadedHarpoon;
	[SerializeField] Transform loadEmpty;
	float reloadTimer = 1f;
	float currentReloadTime;

	[SerializeField] GameObject target;
	Vector2 newTargetPos;


	
	void Start() {
		gameMan = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameManager>();
        mainCam = Camera.main;
    }


    void Update() {
		if (currentReloadTime <= 0 && loadEmpty.transform.childCount == 0) {
			loadedHarpoon = Instantiate(harpoon, loadEmpty.position, Quaternion.LookRotation(-loadEmpty.forward, loadEmpty.up), loadEmpty.transform);
			loadedHarpoon.transform.localScale = Vector3.one;
		}
		else {
			currentReloadTime -= Time.deltaTime;
		}
    }


	void LateUpdate () {
		target.transform.position = new Vector3(newTargetPos.x, newTargetPos.y, 0);
		//print("Target position: " + target.transform.position);

	}


	public void OnAim(InputAction.CallbackContext aimContext) {
		//print(aimContext.ReadValue<Vector2>());
		//print(mainCam.ViewportToWorldPoint(aimContext.ReadValue<Vector2>()));
		//print(mainCam.ScreenPointToRay(aimContext.ReadValue<Vector2>()).GetPoint(10));

		if (!gameMan.gameOver && aimContext.performed) {
			//target.transform.position = new Vector2(mainCam.transform.position.x, mainCam.transform.position.y) + aimContext.ReadValue<Vector2>();

			newTargetPos = transform.position + mainCam.ScreenPointToRay(aimContext.ReadValue<Vector2>()).GetPoint(10);
		}
	}


	public void OnFire(InputAction.CallbackContext fireContext) {
		if (!gameMan.gameOver && loadEmpty.childCount > 0) {
			GameObject firedHarpoon = loadEmpty.GetChild(0).gameObject;
			firedHarpoon.GetComponent<Rigidbody>().AddForce(-firedHarpoon.transform.up * 10, ForceMode.Impulse);
			firedHarpoon.GetComponent<HarpoonScript>().wasFired = true;
			firedHarpoon.GetComponent<AudioSource>().Play();
			firedHarpoon.transform.SetParent(null);
			currentReloadTime = reloadTimer;
		}
	}
}
