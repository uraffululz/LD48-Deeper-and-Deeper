using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHoseScript : MonoBehaviour
{

	[SerializeField] Transform airHoseConnector;

    void Start() {
        
    }


    void Update() {
        GetComponent<LineRenderer>().SetPosition(1, airHoseConnector.transform.position);
    }
}
