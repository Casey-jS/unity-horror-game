using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    public float speed;
    public float groundDrag;

    public LayerMask ground;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip moveSound;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        rb.drag = groundDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput == 0 && verticalInput == 0)
        {
            audioSource.Stop();
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(moveSound);
        }

    }
}
