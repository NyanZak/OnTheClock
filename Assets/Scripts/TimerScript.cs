using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public float currentTime, startingTime;
    [SerializeField] TMP_Text countdownText;
    public Animator animator;
    private void Start()
    {
        currentTime = startingTime;
    }
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime < 11)
        {
         countdownText.color = Color.red;
         animator.SetTrigger("Pulsing");
         FindObjectOfType<AudioManager>().Play("Click2");
        }
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}