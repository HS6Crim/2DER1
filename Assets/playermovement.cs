using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public AudioClip jump;
    AudioSource playerSFX; 

    public Transform groundCheckPoint;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSFX = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("isGrounded", isGrounded);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            playerSFX.PlayOneShot(jump);
        }
        Debug.Log(moveSpeed);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}
