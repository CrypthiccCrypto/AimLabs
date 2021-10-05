using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;

    void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    void Update() {
        getLinearInput();
        getRotationalInput();
        getClickInput();
        getJumpInput();
        getRunInput();
    }

    void getLinearInput() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");


        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 moveDir = (moveHorizontal + moveVertical).normalized;
        Vector3 velVec = moveDir*speed;
        
        playerMovement.setVelocity(velVec);
    }

    void getJumpInput() {
        if(Input.GetKeyDown("space")) {
            playerMovement.jumpPlayer();
        }
    }

    void getRotationalInput() {
        float yRot = Input.GetAxisRaw("Mouse X")/10;
        float xRot = Input.GetAxisRaw("Mouse Y")/10;

        Vector3 p_rotation = new Vector3(0f, yRot*lookSensitivity, 0f);
        playerMovement.setRotation(p_rotation);


        Vector3 c_rotation = new Vector3(xRot*lookSensitivity, 0f, 0f);
        playerMovement.setCameraRotation(c_rotation);
    }
    void getClickInput() {
        if(Input.GetMouseButtonDown(0)) {
            playerShoot.setShooting(true);
        }
         if (Input.GetMouseButtonUp(0)) {
            playerShoot.setShooting(false);
            playerShoot.resetCoolDown();
        }
    }

    void getRunInput() {
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            playerMovement.setRunning(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)){
            playerMovement.setRunning(false);
        }
    }
}