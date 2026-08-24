using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpen = false; //the bool used in the animation
    int time = 1000; //time iterval untill door closes by itself
    bool isColliding = false; //checks if player is colliding with the door


    void Update()
    {
        if (!isColliding && isOpen)
        {
            time--;

            if (time <= 0)
            {
                ToggleDoor();
                time = 1000;
            }
        }
    }
    void ToggleDoor()
    {
        isOpen = !isOpen;

        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetBool("IsOpen", isOpen);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        isColliding = true;

        if (!isOpen)
            ToggleDoor();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        isColliding = false;
        time = 1000;
    }
}