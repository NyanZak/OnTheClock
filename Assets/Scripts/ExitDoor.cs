using UnityEngine;
using TMPro;
public class ExitDoor : MonoBehaviour
{
    public GameObject levelCompleteMenu;
    public int collectiblesNeeded = 3;
    private int collectiblesCollected = 0;
    public TMP_Text collectibleText;
    private void Start()
    {
        gameObject.SetActive(false);
        collectibleText.text = collectiblesCollected + "/" + collectiblesNeeded;
    }
    public void Collect()
    {
        collectiblesCollected += 1;
        collectibleText.text = collectiblesCollected + "/" + collectiblesNeeded;
        if (collectiblesCollected >= collectiblesNeeded)
        {
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collectiblesCollected >= collectiblesNeeded)
        {
            FindObjectOfType<AudioManager>().Play("Win");
            levelCompleteMenu.SetActive(true);
        }
    }
}