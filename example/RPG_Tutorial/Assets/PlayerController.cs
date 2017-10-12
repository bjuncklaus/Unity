using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    Camera cam;
    PlayerMotor motor;
    RaycastHit hitDestination;

    public LayerMask movementMask;
    public int range;

    // Use this for initialization
    void Start() {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update() {
        if (LeftClicked()) {
            Move(false);
        }

        if (RightClicked()) {
            Move(true);
        }
    }

    void Move(bool checkForInteractable) {
		// Origin of the ray to be cast
        Vector3 rayOrigin = Input.mousePosition;

		// The ray origin
		Ray rayFrom = cam.ScreenPointToRay(rayOrigin);

		// What we hit with the casted ray


        if (checkForInteractable) {
            if (CastCustomRay(rayFrom, checkForInteractable)) {
                // Check if an interactable was hit and set it as the focus

            }
        } else {
            if (CastCustomRay(rayFrom, checkForInteractable))	{
    			// Move the player to what we hit
                MovePlayer();

    			// Stop focusing any objects
    		}
        }
    }

    void MovePlayer() {
        //Debug.Log("We hit: " + hit.collider.name + " at: " + hit.point);
        motor.MoveToPoint(hitDestination.point);
    }

    bool CastCustomRay (Ray rayFrom, bool checkForInteractable) {
        if (checkForInteractable) {
            return Physics.Raycast(rayFrom, out hitDestination, range);
        }

        return Physics.Raycast(rayFrom, out hitDestination, range, movementMask);
    }

	bool LeftClicked() {
		return Input.GetMouseButton(0);
	}

	bool RightClicked() {
		return Input.GetMouseButton(1);
	}
}
