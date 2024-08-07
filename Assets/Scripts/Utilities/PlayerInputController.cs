using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Private Variables
    private PlayerController playerController;
    //private GameManager gameManager;
    public enum PlayerType { RedPlayer, BluePlayer }
    [SerializeField] private PlayerType playerType;
    #endregion
  
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        PlayerInput playerInput = new PlayerInput();
        playerInput.Game.Pause.performed += (val) => GameManager.Instance.ShowPauseMenu();

        if (playerInput != null)
        {
            if (playerType == PlayerType.RedPlayer)
            {

                playerInput.RedPlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
               

                //check the W key input
                if (!playerController.isOnLadder)
                {
                    playerInput.RedPlayerMovement.StairMove.performed += (val) => playerController.StairMove(val.ReadValue<float>());
                    playerInput.RedPlayerMovement.Jump.canceled += (val) => playerController.StopInStair();
                }
                playerInput.RedPlayerMovement.Jump.performed += (val) => playerController.Jump();
                playerInput.RedPlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
                playerInput.RedPlayerMovement.Shoot.started += i => playerController.PlayerShoot();


            }

            else if (playerType == PlayerType.BluePlayer)
            {
                playerInput.BluePlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
 
                if (!playerController.isOnLadder)
                {
                    playerInput.BluePlayerMovement.StairMove.performed += (val) => playerController.StairMove(val.ReadValue<float>());
                    playerInput.BluePlayerMovement.Jump.canceled += (val) => playerController.StopInStair();

                }
                playerInput.BluePlayerMovement.Jump.performed += (val) => playerController.Jump();
                playerInput.BluePlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
                playerInput.BluePlayerMovement.Shoot.started += i => playerController.PlayerShoot();
            }

            if (playerType == PlayerType.RedPlayer)
            {
                playerInput.RedPlayerMovement.Enable();
                playerInput.Game.Pause.Enable();
            }
            else if (playerType == PlayerType.BluePlayer)
            {
                playerInput.BluePlayerMovement.Enable();
                playerInput.Game.Pause.Enable();
            }
        }
    }
 

   

    public PlayerType GetPlayerType()
    {
        return playerType;
    }

}