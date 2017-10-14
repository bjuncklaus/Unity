using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolymonController : MonoBehaviour {

    Transform target;
    public float speed;
    public float distanceFromPlayer;

    void Start() {
        target = PlayerManager.instance.player.transform;
    }

    void FixedUpdate() {
        //float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();
		float step = speed * Time.deltaTime;
        //Vector3 destination = new Vector3(target.position.x + distanceFromPlayer, transform.position.y, target.position.z + distanceFromPlayer);
        Vector3 destination = target.position - target.forward;
        destination.y = target.position.y + target.localScale.y + distanceFromPlayer;
        //transform.position = Vector3.MoveTowards(transform.position, destination, step);
        transform.position = Vector3.Lerp(transform.position, destination, step);
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
