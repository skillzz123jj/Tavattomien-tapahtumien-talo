using UnityEngine;

public class ShowHints : MonoBehaviour
{
    [SerializeField] private GameObject hintsDisabledBox;
    [SerializeField] private GameObject hintsEnabledBox;
    [SerializeField] private GameObject hint1Box;


    void Start()
    {
        if (GameData.Instance.hintsEnabled)
        {
            hintsEnabledBox.SetActive(true);
            hintsDisabledBox.SetActive(false);
        }
        else
        {
            hintsEnabledBox.SetActive(false);
            hintsDisabledBox.SetActive(true);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateHintCard()
    {
        hint1Box.SetActive(true);
    }
}
