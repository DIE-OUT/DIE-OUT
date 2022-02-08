// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputTable.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputTable : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputTable()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputTable"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""3e356d59-a3f9-4334-86bc-7173a5dc3be1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d75ca832-8407-4043-9b2f-581df5bb3fd1"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8759d020-6fc7-41d0-aa71-f228dadfa077"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tackle"",
                    ""type"": ""Button"",
                    ""id"": ""4949a35a-c232-4f86-a3a7-e3a037715393"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""1c12a57a-1f8d-4e6e-b08c-1774c2052d33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""58e44b21-9533-4645-bc7b-74853bca332b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1350637-415f-460b-a479-b473d75b9d83"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""21b01835-a03c-47a2-b0d1-20f2e4b31174"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""26635b90-5fbf-45be-8343-d26f9e8e9223"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eed944b6-326e-4739-958c-ac9b93416f6a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""de5dbcc8-3b57-447e-88cb-739ce63c08b7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5fc9bf3-05a3-450d-b4c9-814c50798a69"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""e389f71b-8ba2-4684-8dc7-106e7d1bf301"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""041c6d8f-74ba-4ebc-a8b2-3a78e9cf9619"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b94c7c67-e021-4318-aa8c-a151f458839a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b7fdedbc-98d7-4c88-ba8a-d13d35325ed0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ceef7e29-34ee-47ac-9442-72c020268f62"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1b25dccd-2f40-47ca-aefd-dc4dfa4a63dd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""594f0b05-e0c7-4a10-9746-3d55740523da"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd19726d-e1b6-4f35-a994-1a01c08a6168"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Tackle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e29f69b-91e7-48d0-aa4e-48fe36512f3b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Tackle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd050705-09bb-43cf-bbf1-4974c97cb2e1"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e756a7b-e179-495f-9d7c-d2508e033b9d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03c1fa0d-f61b-4d28-a00e-10de7c113c83"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90af8e80-4c1e-4654-9d5b-c18179e2ffbb"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cc0c213-d9b1-41ee-91b1-7b19f376133a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Navigation"",
            ""id"": ""619623e0-daa8-4626-b766-edc9ff8b722e"",
            ""actions"": [
                {
                    ""name"": ""AnyButton"",
                    ""type"": ""Button"",
                    ""id"": ""9527c1be-d873-49f0-951d-3bb0578020af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scoreboard"",
                    ""type"": ""Button"",
                    ""id"": ""5797bf1b-55b2-44f4-9af7-4f97168ae51e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7e1d39bd-e16c-4aec-a2a0-484fc198a43c"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7748be90-326c-4c58-b1b0-b1ee18c4ad1c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d4b3927-6271-4b79-9ccf-4e7b5dcd4b74"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""668147f9-f470-40a3-9dc6-fdab3df1f90d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a91a139d-6157-4166-affb-e22164f7eaf6"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6e8fdbb-0600-476e-9af9-ca55b2a01626"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a87a6e2f-8d28-4fac-9443-55ea43a84ad3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3031a79c-3522-4441-b779-9667193743c7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51c8d647-7c24-49c0-a336-b770d9c7924c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91fb8054-b3f1-4690-9b26-546fb9525837"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce9269b2-f868-4d39-ad5d-177e4ce330f9"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_Tackle = m_CharacterControls.FindAction("Tackle", throwIfNotFound: true);
        m_CharacterControls_PickUp = m_CharacterControls.FindAction("PickUp", throwIfNotFound: true);
        m_CharacterControls_Throw = m_CharacterControls.FindAction("Throw", throwIfNotFound: true);
        // Navigation
        m_Navigation = asset.FindActionMap("Navigation", throwIfNotFound: true);
        m_Navigation_AnyButton = m_Navigation.FindAction("AnyButton", throwIfNotFound: true);
        m_Navigation_Scoreboard = m_Navigation.FindAction("Scoreboard", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Move;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_Tackle;
    private readonly InputAction m_CharacterControls_PickUp;
    private readonly InputAction m_CharacterControls_Throw;
    public struct CharacterControlsActions
    {
        private @InputTable m_Wrapper;
        public CharacterControlsActions(@InputTable wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @Tackle => m_Wrapper.m_CharacterControls_Tackle;
        public InputAction @PickUp => m_Wrapper.m_CharacterControls_PickUp;
        public InputAction @Throw => m_Wrapper.m_CharacterControls_Throw;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Tackle.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTackle;
                @Tackle.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTackle;
                @Tackle.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTackle;
                @PickUp.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPickUp;
                @Throw.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Tackle.started += instance.OnTackle;
                @Tackle.performed += instance.OnTackle;
                @Tackle.canceled += instance.OnTackle;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

    // Navigation
    private readonly InputActionMap m_Navigation;
    private INavigationActions m_NavigationActionsCallbackInterface;
    private readonly InputAction m_Navigation_AnyButton;
    private readonly InputAction m_Navigation_Scoreboard;
    public struct NavigationActions
    {
        private @InputTable m_Wrapper;
        public NavigationActions(@InputTable wrapper) { m_Wrapper = wrapper; }
        public InputAction @AnyButton => m_Wrapper.m_Navigation_AnyButton;
        public InputAction @Scoreboard => m_Wrapper.m_Navigation_Scoreboard;
        public InputActionMap Get() { return m_Wrapper.m_Navigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NavigationActions set) { return set.Get(); }
        public void SetCallbacks(INavigationActions instance)
        {
            if (m_Wrapper.m_NavigationActionsCallbackInterface != null)
            {
                @AnyButton.started -= m_Wrapper.m_NavigationActionsCallbackInterface.OnAnyButton;
                @AnyButton.performed -= m_Wrapper.m_NavigationActionsCallbackInterface.OnAnyButton;
                @AnyButton.canceled -= m_Wrapper.m_NavigationActionsCallbackInterface.OnAnyButton;
                @Scoreboard.started -= m_Wrapper.m_NavigationActionsCallbackInterface.OnScoreboard;
                @Scoreboard.performed -= m_Wrapper.m_NavigationActionsCallbackInterface.OnScoreboard;
                @Scoreboard.canceled -= m_Wrapper.m_NavigationActionsCallbackInterface.OnScoreboard;
            }
            m_Wrapper.m_NavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AnyButton.started += instance.OnAnyButton;
                @AnyButton.performed += instance.OnAnyButton;
                @AnyButton.canceled += instance.OnAnyButton;
                @Scoreboard.started += instance.OnScoreboard;
                @Scoreboard.performed += instance.OnScoreboard;
                @Scoreboard.canceled += instance.OnScoreboard;
            }
        }
    }
    public NavigationActions @Navigation => new NavigationActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ICharacterControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTackle(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
    public interface INavigationActions
    {
        void OnAnyButton(InputAction.CallbackContext context);
        void OnScoreboard(InputAction.CallbackContext context);
    }
}
