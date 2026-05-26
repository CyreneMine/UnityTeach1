using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson11 : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 20f;
    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float sensitivity = 50f;
    private Vector2 lookInput;
    private Vector2 moveInput;
    [SerializeField]
    private Transform tankHead;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerController = new  PlayerController();
    }
    

    private void OnEnable()
    {
        playerController.Enable();
        playerController.Player.Move.performed += OnMove;
        playerController.Player.Move.canceled += OnMove;
        playerController.Player.Look.performed += OnLook;
        playerController.Player.Look.canceled += OnLook;
    }

    private void OnDisable()
    {
        playerController.Disable();
        playerController.Player.Move.performed -= OnMove;
        playerController.Player.Move.canceled -= OnMove;
        playerController.Player.Look.performed -= OnLook;
        playerController.Player.Look.canceled -= OnLook;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,moveInput.y) * (Time.deltaTime * moveSpeed));
        transform.Rotate(Vector3.up * moveInput.x * (Time.deltaTime * rotateSpeed));
        tankHead.Rotate(Vector3.up*lookInput.x*sensitivity*Time.deltaTime);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }
}
