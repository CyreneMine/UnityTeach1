using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObj:TankBaseObj
{
    private Vector2 moveInput;
    private Vector2 lookInput;
    private PlayerController playerAction;

    private void OnDisable()
    {
        playerAction.Player.Move.performed -= OnMove;
        playerAction.Player.Move.canceled -= OnMove;
        playerAction.Player.Look.performed -= OnLook;
        playerAction.Player.Look.canceled -= OnLook;
        playerAction.Disable();
    }

    private void Start()
    {
        playerAction = new PlayerController();
        playerAction.Enable();
        playerAction.Player.Move.performed += OnMove;
        playerAction.Player.Move.canceled += OnMove;
        playerAction.Player.Look.performed += OnLook;
        playerAction.Player.Look.canceled += OnLook;
    }
    
    private void Update()
    {
        {//旧版输入系统
            /*
            transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));
            transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * Time.deltaTime * roundSpeed));
            head.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * Time.deltaTime * headRoundSpeed));
            */
        }
        {//新输入系统
            transform.Translate(new Vector3(0,0,moveInput.y)* (Time.deltaTime * moveSpeed));
            transform.Rotate(new Vector3(0,moveInput.x,0)* (Time.deltaTime * roundSpeed));
            head.transform.Rotate(new Vector3(0,lookInput.x,0));
        }
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void Fire()
    {
        
    }
}
