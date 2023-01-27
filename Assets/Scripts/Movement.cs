using UnityEngine;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer, platformLayer;
    public Animator animator;
    private bool isGrounded, isOnPlatform;
    private AudioSource audioSource;
    public AudioClip Jump;

    void Update()
    {
        isGrounded = Physics2D.BoxCast(groundCheck.position, new Vector2(0.5f, 0.1f), 0f, Vector2.down, 0.1f, groundLayer);
        isOnPlatform = Physics2D.BoxCast(groundCheck.position, new Vector2(0.5f, 0.1f), 0f, Vector2.down, 0.1f, platformLayer);
        if (Input.GetKeyDown(KeyCode.Space) && (isOnPlatform || isGrounded))
        {
            animator.SetTrigger("Jump");
            //FindObjectOfType<AudioManager>().Play("Jump2");
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Jump;
            audioSource.pitch = (Random.Range(1f, 2f));
            audioSource.Play();

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    

}