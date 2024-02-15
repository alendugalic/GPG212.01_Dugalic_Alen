using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider iceBreathSlider;
    public Slider electricBreathSlider;
    public AudioSource breathAudio;
    public AudioClip fireSfx, iceSfx, elecSfx;
 
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
        iceBreathSlider.value = iceTimer;
        ElectricBreath();
        electricBreathSlider.value = electricTimer;

    }

    private void FireBreath()
    {
        if (Input.GetKeyDown(KeyCode.Q) && fireTimer >= fireCooldown)
        {
            Instantiate(fireBall, mouthTransform.position, Quaternion.identity);
            fireTimer = 0f;
            breathAudio.clip = fireSfx;
            breathAudio.Play();
        }

        if (fireTimer < fireCooldown)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void IceBreath()
    {
        if (Input.GetKeyDown(KeyCode.W) && iceTimer >= iceCooldown)
        {
            Instantiate(iceBall, mouthTransform.position, Quaternion.identity);
            iceTimer = 0f;
            breathAudio.clip = iceSfx;
            breathAudio.Play();
        }

        if (iceTimer < iceCooldown)
        {
            iceTimer += Time.deltaTime;
        }
    }

    private void ElectricBreath()
    {
        if (Input.GetKeyDown(KeyCode.E) && electricTimer >= electricCooldown)
        {
            Instantiate(electricBall, mouthTransform.position, Quaternion.identity);
            electricTimer = 0f;
            breathAudio.clip = elecSfx;
            breathAudio.Play();
        }

        if (electricTimer < electricCooldown)
        {
            electricTimer += Time.deltaTime;
        }
    }
    public void CooldownDisp()
    {

    }
}