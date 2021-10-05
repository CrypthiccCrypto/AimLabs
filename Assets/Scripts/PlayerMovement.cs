using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 runVelocity = Vector3.zero;
    private Vector3 jumpVelocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 c_rotation = Vector3.zero;
    private Rigidbody rb;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject ground;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform gun;
    [SerializeField]
    private bool isRunning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        movePlayer();
        combinedMovement();
        rotatePlayer();
        rotateCameraAndGun();
    }
    public void combinedMovement() {
        velocity = runVelocity + jumpVelocity;
        rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
    }
    public void setVelocity(Vector3 velVec) {
        runVelocity = velVec;
    }
    public void setRotation(Vector3 rotation) {
        this.rotation = rotation;
    }
    public void setCameraRotation(Vector3 c_rotation) {
        this.c_rotation = c_rotation;
    }
    public void setRunning(bool isRunning) {
        this.isRunning = isRunning;
    }
    void movePlayer() {
        if(velocity != Vector3.zero) {
            if(isRunning) {
                runVelocity = 2.0f * runVelocity;
            }
        }
    }
    void rotatePlayer() {
        if(rotation != Vector3.zero) {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }
    }
    void rotateCameraAndGun() {
        if(c_rotation != Vector3.zero) {
            cam.transform.Rotate(-c_rotation);
            gun.transform.Rotate(-c_rotation);
        }
    }
    public void jumpPlayer() {
        if(Physics.Raycast(transform.position, Vector3.down, 2.5f, mask)) {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);   
        }
    }
}
