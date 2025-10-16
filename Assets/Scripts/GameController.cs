using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public InputActionAsset actions;
    private InputAction Select;
    public Camera cam;
    private RaycastHit hitInfo = new RaycastHit();
    private Vector3 mouseWorldPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
        actions.FindActionMap("gameplay").FindAction("Select").performed += OnSelect;
        actions.FindActionMap("gameplay").Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSelect(InputAction.CallbackContext context)
    {
        
        
        Debug.Log(Physics.Raycast(cam.ScreenPointToRay(mouseWorldPos), out hitInfo));
        Debug.Log(mouseWorldPos);
        if (Physics2D.Raycast(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f))
        {
            Debug.Log("Selected!");
        }
        
        
    }
}
