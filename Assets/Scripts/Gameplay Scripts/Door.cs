using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private BoxCollider2D boxCol2D;

    private Animator anime;

    private int diamondCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        boxCol2D = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
    }

    void OpenDoor()
    {
        anime.Play(TagManager.OPEN_ANIMATION_NAME);
    }

    void RemoveCollider()
    {
        boxCol2D.enabled = false;
    }

    public void RegisterDiamond()
    {
        diamondCount++;
    }

    public void DiamondCollected()
    {
        diamondCount--;

        if (diamondCount == 0)
        {
            OpenDoor();
        }
    }




}//class





