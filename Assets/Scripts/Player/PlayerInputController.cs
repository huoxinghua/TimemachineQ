using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Private Variables
    PlayerController playerController;
    #endregion


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void OnEnable()
    {
        PlayerInput playerInput = new PlayerInput();
        if (playerInput != null)
        {
            Debug.Log("get playerInput" + playerInput);
            playerInput.RedPlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<Vector2>());
        }
        //playerInput.Enable();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
