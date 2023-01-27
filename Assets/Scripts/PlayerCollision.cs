using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<AudioManager>().Play("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}