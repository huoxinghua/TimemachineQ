using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Private Variables
    private PlayerController playerController;
    public enum PlayerType { RedPlayer, BluePlayer }
    [SerializeField] private PlayerType playerType;
    #endregion

    //private bool CanMoveUp = false;
    //private bool canMoveUp = false;
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
                playerInput.RedPlayerMovement.MoveUp.performed += (val) => playerController.StairMove(val.ReadValue<float>());

                //check the W key input
                if (!playerController.isClimbing)
                {
                    playerInput.RedPlayerMovement.Jump.performed += (Val) => playerController.Jump();
                }
                playerInput.RedPlayerMovement.MoveUp.performed += (context) => playerController.StairMove(context.ReadValue<float>());

                playerInput.RedPlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
                playerInput.RedPlayerMovement.Shoot.started += i => playerController.PlayerShoot();

            }

            else if (playerType == PlayerType.BluePlayer)
            {
                playerInput.BluePlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<float>());
                playerInput.BluePlayerMovement.MoveUp.performed += (val) => playerController.StairMove(val.ReadValue<float>());

                if (!playerController.isClimbing)
                {
                    playerInput.BluePlayerMovement.Jump.performed += (Val) => playerController.Jump();

                }
                playerInput.BluePlayerMovement.MoveUp.performed += (context) => playerController.StairMove(context.ReadValue<float>());
                playerInput.BluePlayerMovement.Jump.canceled += (val) => playerController.JumpReleased();
                playerInput.BluePlayerMovement.Shoot.started += i => playerController.PlayerShoot();
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
}