using UnityEngine;
using UnityEngine.InputSystem;

public class Taberu : MonoBehaviour
{
    public LayerMask iceLayer;
    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.rightButton.wasPressedThisFrame)
        {

            Ray ray = Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue()
                );

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, iceLayer))
            {

                if (hit.collider.CompareTag("Ice"))
                {
                    Destroy(hit.collider.gameObject);
                }
              
            }
        }
    }
}
