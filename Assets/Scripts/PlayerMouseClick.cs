using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseClick : MonoBehaviour
{
    [SerializeField] AudioClip clickClip;
    [SerializeField] AudioSource sfx;
    Transform currentTransform;
    private void Update()
    {
        CheckForObject();        
    }

    private void CheckForObject()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask.GetMask("Default")))
        {
            if (raycastHit.transform != null)
            {
                if (raycastHit.transform.gameObject.TryGetComponent(out ArrowSquare arrow))
                {                    
                    if (Input.GetMouseButtonDown(0))
                    {
                        ClickObject(arrow, 1);
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        ClickObject(arrow, -1);
                    }
                    
                }
            }           
        }
    }

    private void ClickObject(ArrowSquare arrow, int multiplier)
    {
        arrow.Rotate(multiplier);
        sfx.clip = clickClip;
        sfx.Play();
    }
}
