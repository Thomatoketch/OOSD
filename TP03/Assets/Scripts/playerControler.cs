using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public int moveSpeed = 10;
    public int jumpForce = 10;
    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded = true;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed; // A/D or Left/Right Arrow
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;   // W/S or Up/Down Arrow

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + movement * Time.deltaTime);

        bool isWalking = moveX != 0 || moveZ != 0;
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);


        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
