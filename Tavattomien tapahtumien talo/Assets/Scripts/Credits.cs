using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] Button closeCredits;
    [SerializeField] TMP_Text openCreditsButton;
    [SerializeField] string openCreditsTextContent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            closeCredits.onClick.Invoke();
            openCreditsButton.text = $"{openCreditsTextContent}";
        }
        if (credits.activeSelf)
        {
          
            openCreditsButton.text = $"<b>{openCreditsTextContent}</b>";
        }

    }
}
