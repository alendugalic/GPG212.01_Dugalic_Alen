using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public bool canFire;
    public GameObject fireBall;
    public GameObject iceBall;
    public GameObject electricBall;
    public Transform mouthTransform;
    private float fireTimer;
    private float iceTimer;
    private float electricTimer;

    [SerializeField] private float fireCooldown;
    [SerializeField] private float iceCooldown;
    [SerializeField] private float electricCooldown;

    private void Start()
    {
        mainCam = Camera.main;
        fireTimer = fireCooldown;
        iceTimer = iceCooldown;
        electricTimer = electricCooldown;
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -rotZ);

        FireBreath();
        IceBreath();
        ElectricBreath();
    }

    private void FireBreath()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canFire && fireTimer >= fireCooldown)
        {
            canFire = false;
            Instantiate(fireBall, mouthTransform.position, Quaternion.identity);
            fireTimer = 0f;
        }

        if (!canFire)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireCooldown)
            {
                canFire = true;
            }
        }
    }

    private void IceBreath()
    {
        if (Input.GetKeyDown(KeyCode.W) && canFire && iceTimer >= iceCooldown)
        {
            canFire = false;
            Instantiate(iceBall, mouthTransform.position, Quaternion.identity);
            iceTimer = 0f;
        }

        if (!canFire)
        {
            iceTimer += Time.deltaTime;
            if (iceTimer >= iceCooldown)
            {
                canFire = true;
            }
        }
    }

    private void ElectricBreath()
    {
        if (Input.GetKeyDown(KeyCode.E) && canFire && electricTimer >= electricCooldown)
        {
            canFire = false;
            Instantiate(electricBall, mouthTransform.position, Quaternion.identity);
            electricTimer = 0f;
        }

        if (!canFire)
        {
            electricTimer += Time.deltaTime;
            if (electricTimer >= electricCooldown)
            {
                canFire = true;
            }
        }
    }
}