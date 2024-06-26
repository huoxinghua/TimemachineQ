//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""RedPlayerMovement"",
            ""id"": ""69a24f68-b7b8-441e-b6bf-327708008e56"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9825190f-834a-4902-befc-dddb002e798f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8e1fee0c-f01f-4224-ab84-c2ae78fea39b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ae8e0644-b7f9-4581-9d52-561ee6701002"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ce204116-7dce-419d-b32f-ee4db1654732"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""606a6677-e511-4802-b62b-ea0b7df226a9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cae8cff4-63df-421c-9255-d46944294645"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b321b10d-37f1-438b-86de-95398ce09053"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea819a63-4c06-477a-bbd3-d1de32742903"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BluePlayerMovement"",
            ""id"": ""5843ad81-53a3-41b8-aaea-486356dcf49c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fb088640-ff85-4253-879a-6999d9c15529"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""91b2654f-62e6-457b-a85b-8bd31ffe865c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""03832854-79cf-4ca7-87c4-75c34945f08b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ca603202-b6c8-41f9-9f3b-a841c7a5e759"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3ab46566-36cc-410c-9095-dc1e287efea8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""52cfc02f-1f58-4646-a955-b5939db9d97e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bafaf68a-0944-48cc-87d2-ee3c2faebf09"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15490c2d-0c7e-483f-9815-2354f401ecd9"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RedPlayerMovement
        m_RedPlayerMovement = asset.FindActionMap("RedPlayerMovement", throwIfNotFound: true);
        m_RedPlayerMovement_Move = m_RedPlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_RedPlayerMovement_Jump = m_RedPlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_RedPlayerMovement_Shoot = m_RedPlayerMovement.FindAction("Shoot", throwIfNotFound: true);
        // BluePlayerMovement
        m_BluePlayerMovement = asset.FindActionMap("BluePlayerMovement", throwIfNotFound: true);
        m_BluePlayerMovement_Move = m_BluePlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_BluePlayerMovement_Jump = m_BluePlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_BluePlayerMovement_Shoot = m_BluePlayerMovement.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // RedPlayerMovement
    private readonly InputActionMap m_RedPlayerMovement;
    private List<IRedPlayerMovementActions> m_RedPlayerMovementActionsCallbackInterfaces = new List<IRedPlayerMovementActions>();
    private readonly InputAction m_RedPlayerMovement_Move;
    private readonly InputAction m_RedPlayerMovement_Jump;
    private readonly InputAction m_RedPlayerMovement_Shoot;
    public struct RedPlayerMovementActions
    {
        private @PlayerInput m_Wrapper;
        public RedPlayerMovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_RedPlayerMovement_Move;
        public InputAction @Jump => m_Wrapper.m_RedPlayerMovement_Jump;
        public InputAction @Shoot => m_Wrapper.m_RedPlayerMovement_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_RedPlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RedPlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IRedPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_RedPlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RedPlayerMovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IRedPlayerMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IRedPlayerMovementActions instance)
        {
            if (m_Wrapper.m_RedPlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRedPlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_RedPlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RedPlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RedPlayerMovementActions @RedPlayerMovement => new RedPlayerMovementActions(this);

    // BluePlayerMovement
    private readonly InputActionMap m_BluePlayerMovement;
    private List<IBluePlayerMovementActions> m_BluePlayerMovementActionsCallbackInterfaces = new List<IBluePlayerMovementActions>();
    private readonly InputAction m_BluePlayerMovement_Move;
    private readonly InputAction m_BluePlayerMovement_Jump;
    private readonly InputAction m_BluePlayerMovement_Shoot;
    public struct BluePlayerMovementActions
    {
        private @PlayerInput m_Wrapper;
        public BluePlayerMovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_BluePlayerMovement_Move;
        public InputAction @Jump => m_Wrapper.m_BluePlayerMovement_Jump;
        public InputAction @Shoot => m_Wrapper.m_BluePlayerMovement_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_BluePlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BluePlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IBluePlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_BluePlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BluePlayerMovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IBluePlayerMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IBluePlayerMovementActions instance)
        {
            if (m_Wrapper.m_BluePlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBluePlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_BluePlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BluePlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BluePlayerMovementActions @BluePlayerMovement => new BluePlayerMovementActions(this);
    public interface IRedPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IBluePlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
