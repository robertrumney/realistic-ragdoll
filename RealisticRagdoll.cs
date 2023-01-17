using UnityEngine;

public class RealisticRagdoll : MonoBehaviour
{
    // The list of rigidbodies in the ragdoll, automatically populated at runtime
    private Rigidbody[] ragdollRigidbodies;

    // Flag to enable the optional "GutBuster" function
    private bool enableGutBuster = true;

    private void Awake()
    {
        // Populate the list of rigidbodies in the ragdoll
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        
        Invoke("End", 5);
        
        if(enableGutBuster)
            GutBuster();
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
                // If the ragdoll is at rest, disable and destroy this script
                if (rb.velocity.magnitude < 1.0f && rb.angularVelocity.magnitude < 1.0f)
                {
                   End();
                }
            }
        }
    }

    // If the ragdoll hasn't come to a rest after 5 seconds, disable and destroy this script
    private void End()
    {
         enabled = false;
         Destroy(this);
    }

    // Function to simulate a punch to the stomach
    public void GutBuster()
    {
        // Find the middle spine rigidbody using the HumanBodyBones enum
        Rigidbody spineRigidbody = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>();

        // Apply a backwards force to the spine rigidbody to simulate the punch
        spineRigidbody.AddForce(-transform.forward * 500.0f, ForceMode.Impulse);
    }
}
