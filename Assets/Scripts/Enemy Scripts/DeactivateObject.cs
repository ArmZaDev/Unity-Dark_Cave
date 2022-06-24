using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{

    [SerializeField]
    private float deactivateTimer = 3f;

    private void Start()
    {
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }



}// class






