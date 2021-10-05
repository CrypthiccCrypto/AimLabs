using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    [SerializeField]
    private Transform muzzle;
    private float timer;

    [SerializeField]
    Camera cam;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float coolDown = 0.2f;

    private float range = 100f;

    private bool isShooting = false;

    public void setShooting(bool b) {
        isShooting = b;
    }

    void Update()
    {
        if(isShooting)
            gunShoot();
    }

    public void gunShoot() {
        timer += Time.deltaTime;
        if(timer > coolDown) {
            timer = 0.0f;
            Vector3 hitLocation = Vector3.zero;
            Vector3 noise = 0.0f * new Vector3(UnityEngine.Random.Range(-0.05f, 0.05f), UnityEngine.Random.Range(-0.05f, 0.05f), UnityEngine.Random.Range(-0.05f, 0.05f));
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) {
                hitLocation = hit.point;
                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity).GetComponent<BulletShoot>().setVelDir((hitLocation - muzzle.position).normalized + noise);
            }
            else {
                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity).GetComponent<BulletShoot>().setVelDir(muzzle.transform.forward + noise);
            }
            
        }
    }

    public void resetCoolDown() {
        timer = coolDown + 0.01f;
    }
}
