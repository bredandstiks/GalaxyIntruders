using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private InputSystem_Actions _actions;

    void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _actions = new InputSystem_Actions();
    }

    void OnEnable() => _actions.Enable();
    void OnDisable() => _actions.Disable();

    public InputAction ShootAction => _actions.Player.Shoot;
    public InputAction LeftAction => _actions.Player.Left;
    public InputAction RightAction => _actions.Player.Right;
}