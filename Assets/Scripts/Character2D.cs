using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spr;
    [SerializeField, Range(0.1f, 10f)]
    float moveSpeed = 1f;
    [SerializeField, Range(0.1f, 15f)]
    float jumpForce;
    Rigidbody2D rb2D;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        if(jumpButton && IsGrounding)
        {
            anim.SetTrigger("jump");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }      
    }

    void LateUpdate()
    {
        spr.flipX = flipSprite;
       anim.SetFloat("moveX", Mathf.Abs(Axis.x));
    }

    void FixedUpdate()
    {
        Debug.Log(rb2D.velocity.y);
        anim.SetFloat("velocityY", rb2D.velocity.y);
    }

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    bool flipSprite
    {
        get => Axis.x > 0 ? false : Axis.x < 0f ? true : spr.flipX;
    }
    bool jumpButton => Input.GetButtonDown("Jump");
    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
