using UnityEngine;

public class Lesson11OldInputSystem : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 20f;
    [SerializeField]
    private float moveSpeed=20f;
    [SerializeField]
    private float sensitivity=5f;
    private Transform tankHead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tankHead = transform.Find("Tank_Head");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed);
        tankHead.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity);
    }
}
