using UnityEngine;
public class RotateObject : MonoBehaviour
{
    public float speed = 10.0f; // rotation speed
    public int rotationDirection = -1; // 1 for clockwise, -1 for counterclockwise
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * rotationDirection * Time.deltaTime);
    }
}
