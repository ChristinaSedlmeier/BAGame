using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour
{

    public GameObject oldMirror;
    public GameObject newMirror; 

    // Start is called before the first frame update
    void Start()
    {
        oldMirror.SetActive(true);
        newMirror.SetActive(false);

        
    }

   public void TurnOffOldMirror()
    {
        oldMirror.SetActive(false);
    }

    public void TurnOnNewMirror()
    {
        newMirror.SetActive(true);
    }


}
