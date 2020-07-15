using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCollectBonus : MonoBehaviour
{

    public delegate void OnFocusChanged(Active newFocus);
    public OnFocusChanged onFocusChangedCallback;
    private Active focus;  
    private Camera camera;

    // Ustawianie maski dla obiektów z którymi gracz wchodzić z działanie
    public LayerMask activeObjectLayer;  

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100f, activeObjectLayer))
            {
               SetFocus(hit.collider.GetComponent<Active>());
               Debug.Log("ustawianie focusa");
            }
        }

    }

    // Ustawianie focusa na nowy
    void SetFocus(Active newFocus)
    {
        //Debug.Log("1");
        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(newFocus);

        // Jeśli focus się zmienił
        if (focus != newFocus && focus != null)
        {
            // Resetowanie zaznaczenia poprzez wywołanie funkcje 
            focus.DeFocus();
            Debug.Log("3");
        }

        // Ustawianie nowego focusu dla tego co klikneliśmy
        // Jeśli jest to inny obiekt, ustaw null dla focus

        focus = newFocus;

        if (focus != null)
        {
            // Dla nasze
            focus.OnFocused(transform);
            Debug.Log("4");
        }

    }

}