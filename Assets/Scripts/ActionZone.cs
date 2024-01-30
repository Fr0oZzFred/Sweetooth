using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class ActionZone : MonoBehaviour {
    [SerializeField] InputActionAsset inputActions;
    InputAction interactAction;

    [SerializeField] UnityEvent onPlayerEnterEvent;
    [SerializeField] UnityEvent onInteractEvent;
    [SerializeField] UnityEvent onPlayerLeaveEvent;
    private void Awake() {
        interactAction = inputActions.FindActionMap("gameplay").FindAction("interact");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerEnter();
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerLeave();

    }
    private void OnPlayerEnter() {
        interactAction.performed += OnInteract;
        onPlayerEnterEvent.Invoke();
    }
    private void OnPlayerLeave() {
        interactAction.performed -= OnInteract;
        onPlayerLeaveEvent.Invoke();
    }

    void OnInteract(InputAction.CallbackContext context) {
        onInteractEvent.Invoke();
    }
}