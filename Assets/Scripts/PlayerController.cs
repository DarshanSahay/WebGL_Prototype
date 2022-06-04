using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip coinPickUp;
    [SerializeField] private AudioClip keyPick;

    [SerializeField] private Animator anim;
    [SerializeField] private Transform cam;

    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    private float gravity;
    private Vector3 direction;
    private float horizonatal;
    private float vertical;

    private void Start()
    {
        gravity = -9.18f;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()                                                   //function to control player movement
    {
        if(GameManager.Instance.cType == ControllerTypes.KeyBoard)
        {
            horizonatal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        else if(GameManager.Instance.cType == ControllerTypes.Joystick)
        {
            horizonatal = joystick.Horizontal;
            vertical = joystick.Vertical;
        }

        direction = new Vector3(horizonatal, 0f, vertical).normalized;
        direction = Quaternion.AngleAxis(cam.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        if (direction != Vector3.zero)
        {
            anim.SetBool("canMoveForward", true);
            Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 180f * Time.deltaTime);
        }
        else
        {
            anim.SetBool("canMoveForward", false);
        }

        controller.Move(new Vector3(direction.x * Time.deltaTime, gravity * Time.deltaTime, direction.z * Time.deltaTime) * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            GameManager.Instance.UpdateCoinCount();
            AudioManager.Instance.PlaySound(coinPickUp);
            Destroy(other.gameObject);
        }
        if(other.tag == "Key")
        {
            GameManager.Instance.UpdateKeyCount();
            AudioManager.Instance.PlaySound(keyPick);
            Destroy(other.gameObject);
        }
        UIManager.Instance.UpdateUI();
    }

    public void PlayWalkSound()                   //being called through animation events
    {
        source.Play();
    }
}
