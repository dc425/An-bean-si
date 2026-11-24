
using UnityEngine;
using TMPro;
using System.Collections;

public class DangerWarningUI : MonoBehaviour
{
    public GameObject warningPanel;
    public TextMeshProUGUI warningText;

    public float displayTime = 4f;

    private Coroutine hideCoroutine;

    private void Start()
    {
        warningPanel.SetActive(false);
    }

    public void ShowWarning()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        warningPanel.SetActive(true);
        warningText.text = "THE DULLAHAN IS NEAR!";

        hideCoroutine = StartCoroutine(HideWarning());
    }

    private IEnumerator HideWarning()
    {
        yield return new WaitForSeconds(displayTime);

        warningPanel.SetActive(false);
        hideCoroutine = null;
    }
}
