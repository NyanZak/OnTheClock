using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dotty2 : MonoBehaviour
{
    public Transform centerImage;
    public float rotationSpeed = 5f;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = mousePosition - centerImage.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
