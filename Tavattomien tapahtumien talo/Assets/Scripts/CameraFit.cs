using UnityEngine;
using Unity.Cinemachine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private SpriteRenderer spriteSize;
    [SerializeField] private SpriteRenderer SpriteToFitTo;
    [SerializeField] private float atticPosition;

    void Update()
    {
        AdjustCameraSize();
    }

    //Camera size calculated based on attic sprite and user's screen size
    private void AdjustCameraSize()
    {
        if (cam == null || spriteSize == null)
        {
            return;
        }

        float screenAspectRatio = Camera.main.aspect;

        Bounds baseSpriteBounds = spriteSize.bounds;
        Bounds actualSpriteBounds = SpriteToFitTo.bounds;

        float spriteAspectRatio = baseSpriteBounds.size.x / baseSpriteBounds.size.y;
        float orthographicSize;

        if (screenAspectRatio >= spriteAspectRatio)
        {
            orthographicSize = baseSpriteBounds.extents.y;
        }
        else
        {
            orthographicSize = baseSpriteBounds.extents.x / screenAspectRatio;
        }

        float spriteWidth = baseSpriteBounds.size.x;
        float screenAspect = Screen.width / (float)Screen.height;
        float consistentOrthographicSize = (spriteWidth / 2f) / screenAspect;

        cam.Lens.OrthographicSize = consistentOrthographicSize;

        if (gameObject.name == "AtticCamera")
        {
            float topPositionY = baseSpriteBounds.center.y + atticPosition;
            cam.transform.position = new Vector3(
                baseSpriteBounds.center.x,  
                topPositionY,               
                cam.transform.position.z    
            );
        }
        else
        {
            cam.transform.position = new Vector3(
                baseSpriteBounds.center.x,                
                actualSpriteBounds.center.y - 0.5f,       
                cam.transform.position.z                       
            );
        }
    }
}
