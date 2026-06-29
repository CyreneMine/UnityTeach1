using UnityEngine;
/// <summary>
/// 让物体自转
/// </summary>
public class RotateObj : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
