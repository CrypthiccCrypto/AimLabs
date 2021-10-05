using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    private Vector3 velDir = Vector3.zero;
    private float bulletSpeed = 100.0f;
    [SerializeField]
    private WallTarget wallTarget;

    void Start() {
        wallTarget = FindObjectOfType<WallTarget>();
    }
    void OnTriggerEnter(Collider other) {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Ground") {
            Destroy(gameObject);
        }
        else if(LayerMask.LayerToName(other.gameObject.layer) == "Target") {
            Destroy(other.gameObject);
            wallTarget.destroyTarget();
            Destroy(gameObject);
        }
    }
    public void setVelDir(Vector3 velDir) {
        this.velDir = velDir;
    }

    void Update()
    {   
        transform.position += velDir*bulletSpeed*Time.deltaTime;
        Destroy(gameObject, 5f);
    }
}
