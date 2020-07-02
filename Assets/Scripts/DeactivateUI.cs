using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateUI : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
