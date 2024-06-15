using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Private Variables
    private PlayerController playerController;
    public enum PlayerType {RedPlayer,BluePlayer}
    [SerializeField] private PlayerType playerType;
    #endregion


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    
    void OnEnable()
    {
        Debug.Log("get playerType" + playerType);
        PlayerInput playerInput = new PlayerInput();
       
        if (playerInput != null)
        {
            if (playerType == PlayerType.RedPlayer)
            {

            playerInput.RedPlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
            playerInput.RedPlayerMovement.Jump.performed += (Val) => playerController.Jump();
            playerInput.RedPlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
            }
            else if (playerType == PlayerType.BluePlayer) 
            {
                playerInput.BluePlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
                playerInput.BluePlayerMovement.Jump.performed += (Val) => playerController.Jump();
                playerInput.BluePlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
            }

        }
        if (playerType == PlayerType.RedPlayer)
        {

            playerInput.RedPlayerMovement.Enable();
        }
        else if (playerType == PlayerType.BluePlayer)
        {
            playerInput.BluePlayerMovement.Enable();
        }
    }
 

}
