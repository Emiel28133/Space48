using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool useInput = false;

    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        if (useInput)
        {
            moveAmount *= Input.GetAxis("Vertical");
        }

        transform.position = transform.position + transform.forward * moveAmount;
    }
}
