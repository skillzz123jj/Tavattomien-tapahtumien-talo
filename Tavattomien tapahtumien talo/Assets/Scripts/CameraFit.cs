using UnityEngine;
using Unity.Cinemachine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private SpriteRenderer spriteSize;
    [SerializeField] private SpriteRenderer SpriteToFitTo;


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
        cam.Lens.OrthographicSize = orthographicSize;

        if (gameObject.name == "AtticCamera")
        {
            float offsetY = orthographicSize - baseSpriteBounds.extents.y;
            cam.transform.position = new Vector3(
                baseSpriteBounds.center.x,
                baseSpriteBounds.center.y - offsetY,
                cam.transform.position.z
            );
        }
        else
        {
            cam.transform.position = new Vector3(baseSpriteBounds.center.x, actualSpriteBounds.center.y, cam.transform.position.z);

        }
    }
}
