using UnityEngine;

public class RotateAroundCircle : MonoBehaviour
{
    // Reference to the object with the BoxCollider2D
    public BoxCollider2D boxCollider;

    private float currentAngle = 0f;

    public bool isHoveringOverItem;

    void Update()
    {
        if (isHoveringOverItem && boxCollider != null)
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            // Get the half-width and half-height of the BoxCollider2D
            float halfWidth = boxCollider.size.x / 2f;
            float halfHeight = boxCollider.size.y / 2f;

            // Get the center position of the BoxCollider2D
            Vector3 boxCenter = (Vector2)boxCollider.transform.position + boxCollider.offset;

            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Set z to 0 since we're working in 2D space

            // Calculate the direction from the center to the mouse position
            Vector3 directionToMouse = mousePosition - boxCenter;

            // Calculate the angle between the center and the mouse position
            currentAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            // Convert the angle to radians
            float angleInRadians = currentAngle * Mathf.Deg2Rad;

            // Determine if the object should move along the horizontal or vertical sides of the box
            // The idea is to check which component (x or y) dominates the direction to the mouse.
            bool isHorizontal = Mathf.Abs(directionToMouse.x) > Mathf.Abs(directionToMouse.y);

            // Calculate the new position based on the side of the box
            float x, y;

            if (isHorizontal)
            {
                // If horizontal, clamp x to the edges and calculate y based on the proportion of the angle
                x = Mathf.Sign(directionToMouse.x) * halfWidth;
                y = Mathf.Tan(angleInRadians) * x;
                y = Mathf.Clamp(y, -halfHeight, halfHeight);
            }
            else
            {
                // If vertical, clamp y to the edges and calculate x based on the proportion of the angle
                y = Mathf.Sign(directionToMouse.y) * halfHeight;
                x = y / Mathf.Tan(angleInRadians);
                x = Mathf.Clamp(x, -halfWidth, halfWidth);
            }

            // Update the position of the object relative to the box center
            transform.position = new Vector3(x, y) + boxCenter;

            // Make the object (e.g., speech bubble) always face the center of the box
            Vector3 directionToCenter = boxCenter - transform.position;

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
