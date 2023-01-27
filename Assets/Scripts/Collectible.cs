using UnityEngine;
public class Collectible : MonoBehaviour
{
    public ExitDoor exitDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exitDoor.Collect();
            Destroy(gameObject);
        }
    }
}