using UnityEngine;

public class RotateAroundItem : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    private float currentAngle = 0f;
    public bool isHoveringOverItem;

    //Calculates the item's colliders size and rotates the indicator around it based on where mouse is currently
    void Update()
    {
        if (isHoveringOverItem && boxCollider != null)
        {            
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            float halfWidth = boxCollider.size.x / 2f;
            float halfHeight = boxCollider.size.y / 2f;

            Vector3 boxCenter = (Vector2)boxCollider.transform.position + boxCollider.offset;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 

            Vector3 directionToMouse = mousePosition - boxCenter;

            currentAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            float angleInRadians = currentAngle * Mathf.Deg2Rad;

            bool isHorizontal = Mathf.Abs(directionToMouse.x) > Mathf.Abs(directionToMouse.y);

            float x, y;

            if (isHorizontal)
            {
                x = Mathf.Sign(directionToMouse.x) * halfWidth;
                y = Mathf.Tan(angleInRadians) * x;
                y = Mathf.Clamp(y, -halfHeight, halfHeight);
            }
            else
            {
                y = Mathf.Sign(directionToMouse.y) * halfHeight;
                x = y / Mathf.Tan(angleInRadians);
                x = Mathf.Clamp(x, -halfWidth, halfWidth);
            }

            transform.position = new Vector3(x, y) + boxCenter;

            Vector3 directionToCenter = boxCenter - transform.position;

            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle + 90);  
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
