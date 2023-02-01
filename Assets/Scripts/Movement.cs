using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
public class Movement : MonoBehaviour
{   
    [Header("Variables")]
    [Tooltip("The force applied to the player when moving")]
    public float Speed;
    [Tooltip("The multiplier for speed on the player")]
    public float SpeedMultiplier;
    [Tooltip("The force applied to the player when jumping")]
    public float JumpForce;
    [Tooltip("The multiplier for jump force on the player")]
    public float JumpForceMultiplier;
    private float xInput;
    private bool grounded;
    [Space(15)]
    [Header("Outsie variables")]
    [Tooltip("The rigidbody componenet on the player")]
    public Rigidbody2D rb;
    [Tooltip("The camera of the player")]
    public GameObject Camera;
    [Tooltip("The sound to be played when you jump")]
    public AudioClip JumpSound;
    [Tooltip("The audio source on the player")]
    public AudioSource AS;
    [Tooltip("The sprite renderer on the player")]
    public SpriteRenderer SR;
    [Tooltip("The sprite for when the player is not in air")]
    public Sprite NormalSprite;
    [Tooltip("The sprite for when the player is in air")]
    public Sprite JumpSprite;
    [Tooltip("When deactivated the game is paused")]
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
        {
            Time.timeScale = 0;
        }
        //Pauses the game
        if (on)
        {
            Time.timeScale = 1;
            //Move
            xInput = Input.GetAxis("Horizontal") * Time.deltaTime * Speed * SpeedMultiplier;
            rb.AddForce(Vector2.right * xInput);
            //Clamp Speed
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -8, 8), rb.velocity.y);
            //Only use speed if you press button
            if (Input.GetAxis("Horizontal") == 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            //Rotate to where your going
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            //Jump/play sound/ change sprite
            if (grounded)
            {
                if (Input.GetAxis("Jump") != 0)
                {
                    rb.AddForce(Vector2.up * JumpForce * JumpForceMultiplier);
                    AS.PlayOneShot(JumpSound);
                    SR.sprite = JumpSprite;
                    grounded = false;
                }
            }
            //Make camera follow position
            Camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            //Limit upwards velocity
            if (rb.velocity.y > 5)
            {
                rb.AddForce(Vector2.up * -rb.velocity.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        SR.sprite = NormalSprite;
    }
}
