using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is responsable to set the action for the character idepedent on view.
public class Actions : MonoBehaviour
{
    [SerializeField] Behaviour[] tPView; //components of the third person view;
    [SerializeField] Behaviour[] fPView; //components of the first person view
    public bool pov;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            TogglePov();
            if (pov == true)
            {
                DisableComponents(tPView);
                EnableComponents(fPView);
            }
            if (pov == false)
            {
                DisableComponents(fPView);
                EnableComponents(tPView);
            }
        
        }
      

    }



    void DisableComponents(Behaviour[] disableThis)
    {
        for (int i = 0; i < disableThis.Length; i++)
        {
            disableThis[i].enabled = false;
        }
    }
    void EnableComponents(Behaviour[] enableThis)
    {
        for (int i = 0; i < enableThis.Length; i++)
        {
            enableThis[i].enabled = true;
        }
    }

    void TogglePov()
    {
        pov = !pov;
    }
    
}
