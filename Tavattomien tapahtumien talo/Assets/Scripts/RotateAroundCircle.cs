using UnityEngine;

public class RotateAroundCircle : MonoBehaviour
{
    // Reference to the object with the CapsuleCollider2D
    public CapsuleCollider2D capsuleCollider;

    // Track the current angle of rotation
    private float currentAngle = 0f;

    // Boolean to check if we're hovering over an item
    public bool isHoveringOverItem;

    void Update()
    {
        if (isHoveringOverItem && capsuleCollider != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            // Get the "radius" based on the capsule's size and axis
            float radius = capsuleCollider.size.x / 2f;  // Default to horizontal axis as radius (for vertical axis, change to size.y)

            // If the capsule is aligned vertically, use the y-axis for radius calculation
            if (capsuleCollider.direction == CapsuleDirection2D.Vertical)
            {
                radius = capsuleCollider.size.y / 2f;
            }

            // Get the center position of the CapsuleCollider2D
            Vector3 circleCenter = (Vector2)capsuleCollider.transform.position + capsuleCollider.offset;

            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Set z to 0 since we're working in 2D space

            // Calculate the direction from the center to the mouse position
            Vector3 directionToMouse = mousePosition - circleCenter;

            // Calculate the angle between the center and the mouse position
            currentAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            // Convert the angle to radians
            float angleInRadians = currentAngle * Mathf.Deg2Rad;

            // Calculate the new position based on the angle, keeping the object on the capsule's circumference
            float x = Mathf.Cos(angleInRadians) * radius;
            float y = Mathf.Sin(angleInRadians) * radius;

            // Update the position of the object relative to the capsule center
            transform.position = new Vector3(x, y) + circleCenter;

            // Make the object (e.g., speech bubble) always face the center of the capsule

            // Calculate direction vector from the object to the center
            Vector3 directionToCenter = circleCenter - transform.position;

            // Calculate the angle needed to rotate towards the center
            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;

            // Apply the rotation so that the object's "up" direction points towards the center
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);  // Adjust to align the "up" vector
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;


        }

    }
}
