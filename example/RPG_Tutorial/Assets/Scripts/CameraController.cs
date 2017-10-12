﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public float currentZoom = 10f,
                zoomSpeed = 4f,
                minZoom = 5f,
                maxZoom = 10f,
                pitch = 2f,
                yawSpeed = 100f,
                currentYaw = 0f;

    void Update() {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Horizontal means "A" and "D" or the joysticks left and right
        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate() {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + CameraPitch());
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

    Vector3 CameraPitch() {
        // The camera needs a pitch because target.position is set to the pivot
        // point of the Player, which is at the bottom
        return Vector3.up * pitch;
    }
}
