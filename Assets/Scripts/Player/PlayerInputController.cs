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
        PlayerInput playerInput = new PlayerInput();
     
        if (playerInput != null)
        {
            if (playerType == PlayerType.RedPlayer)
            {

            playerInput.RedPlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
            playerInput.RedPlayerMovement.Jump.performed += (Val) => playerController.Jump();
            playerInput.RedPlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
            playerInput.RedPlayerMovement.Shoot.started += i => playerController.PlayerShoot();
            }
            else if (playerType == PlayerType.BluePlayer) 
            {
                playerInput.BluePlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
                playerInput.BluePlayerMovement.Jump.performed += (Val) => playerController.Jump();
                playerInput.BluePlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
                playerInput.BluePlayerMovement.Shoot.started += i => playerController.PlayerShoot();
            }

            //this is for the switch to up and down the elevator;both of the player can interact with the switch
            playerInput.PlayerAction.Operate.performed += (val) => playerController.Operate();
            playerInput.PlayerAction.Operate.performed += (val) => playerController.OperateReleased();

        }
        if (playerType == PlayerType.RedPlayer)
        {
            playerInput.RedPlayerMovement.Enable();
            //thus will make the switch with the elevator Y key work
            playerInput.PlayerAction.Enable();
        }
        else if (playerType == PlayerType.BluePlayer)
        {
            playerInput.BluePlayerMovement.Enable();
            playerInput.PlayerAction.Enable();
        }
    }
 

}
