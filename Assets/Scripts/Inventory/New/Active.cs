using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{

    public float radius = 10f;
    bool isFocus = false;  
    Transform player;       
    bool wasActived = false; 

    void Update()
    {
        if (isFocus) 
        {
            // Obliczanie odległości pomiędzy pozycją gracza w odniesieniu do pozycji przedmiotu
            float distance = Vector3.Distance(player.position, transform.position);
            Debug.Log(distance);
            // Debug.Log(wasActived);
            // Sprawdzanie czy gracz nie oddziałowywał z przedmiot i jak daleko znajduje sie od niego
            if (!wasActived && distance <= radius)
            {
                Interact();
                wasActived = true;
               
            }
        }
    }

    // Metoda wywoływana gdy focus jest on
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        wasActived = false;
        player = playerTransform;
    }

    // Resetowanie focusa
    public void DeFocus()
    {
        isFocus = false;
        wasActived = false;
        player = null;
    }

    // Metoda do nadpisania 
    public virtual void Interact()
    {
       Debug.Log("Interacting yeah");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
