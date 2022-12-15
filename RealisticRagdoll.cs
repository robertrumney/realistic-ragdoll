using UnityEngine;

public class RealisticRagdoll : MonoBehaviour
{
    // The list of rigidbodies in the ragdoll, automatically populated at runtime
    private Rigidbody[] ragdollRigidbodies;
    private bool atRest = true;

    private void Awake()
    {
        // Populate the list of rigidbodies in the ragdoll
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Invoke("End", 5);
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            // Apply downward force to each rigidbody in the ragdoll to make it fall realistically
            foreach (Rigidbody rb in ragdollRigidbodies)
            {
                rb.AddForce(Vector3.down * 9.8f * rb.mass);
            }

            // Check if the ragdoll has come to a rest

            foreach (Rigidbody rb in ragdollRigidbodies)
            {
                if (rb.velocity.magnitude > 1.0f || rb.angularVelocity.magnitude > 1.0f)
                {
                    atRest = false;
                    break;
                }
            }

            // If the ragdoll is at rest, disable and destroy this script
            if (atRest)
            {
                enabled = false;
                Destroy(this);
            }
        }
    }

    // If the ragdoll hasn't come to a rest after 5 seconds, disable and destroy this script
    private void End()
    {
        if (!atRest)
        {
            enabled = false;
            Destroy(this);
        }  
    }
}
