using UnityEngine;
using Unity.Cinemachine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private SpriteRenderer spriteSize;
    [SerializeField] private SpriteRenderer SpriteToFitTo;

    [SerializeField] float atticPosition;
    void Update()
    {
        AdjustCameraSize();
    }

    private void AdjustCameraSize()
    {
        if (cam == null || spriteSize == null)
        {
            return;
        }

        //Get the aspect ratio of the screen (width/height)
        float screenAspectRatio = Camera.main.aspect;

        //Calculate the bounds of the sprites
        Bounds baseSpriteBounds = spriteSize.bounds;

        Bounds actualSpriteBounds = SpriteToFitTo.bounds;

        //Get the aspect ratio of the sprite
        float spriteAspectRatio = baseSpriteBounds.size.x / baseSpriteBounds.size.y;

        //Calculate the desired orthographic size based on the sprite's dimensions
        float orthographicSize;

        if (screenAspectRatio >= spriteAspectRatio)
        {
            orthographicSize = baseSpriteBounds.extents.y;
        }
        else
        {
            orthographicSize = baseSpriteBounds.extents.x / screenAspectRatio;
        }

        // Set the orthographic size of the camera


        float spriteWidth = baseSpriteBounds.size.x;
        float screenAspect = Screen.width / (float)Screen.height;
        float consistentOrthographicSize = (spriteWidth / 2f) / screenAspect;

        // Apply consistent orthographic size to all cameras
        cam.Lens.OrthographicSize = consistentOrthographicSize;

        if (gameObject.name == "AtticCamera")
        {
            // Align the top of the atticSprite to the top of the screen
            float topPositionY = baseSpriteBounds.center.y + atticPosition; // - consistentOrthographicSize;
            cam.transform.position = new Vector3(
                baseSpriteBounds.center.x,  // Center horizontally
                topPositionY,               // Align top of sprite with screen top
                cam.transform.position.z    // Preserve Z position
            );
        }
        else
        {
            // Position logic for non-attic cameras (use consistent orthographic size)
            cam.transform.position = new Vector3(
                baseSpriteBounds.center.x,                // Adjust horizontal position
                actualSpriteBounds.center.y - 0.5f,            // Adjust vertical position
                cam.transform.position.z                       // Preserve Z position
            );
        }
    }
}
