using UnityEngine;
using System.Collections;
public class RotateObjects : MonoBehaviour
{
    public GameObject[] objectsToRotate;
    void Start()
    {
        StartCoroutine(RotateOverTime());
    }
    IEnumerator RotateOverTime()
    {
        float rotationSpeed = 6;
        float rotationTime = 60f;
        float elapsedTime = 0f;
        while (elapsedTime < rotationTime)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                objectsToRotate[i].transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}