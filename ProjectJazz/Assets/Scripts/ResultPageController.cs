using UnityEngine;
using Fungus;

public class ResultPageController : MonoBehaviour
{
    public string fungusBlockName; // Name of the Fungus block to execute
    public Flowchart flowchart;    // Reference to the Fungus Flowchart

    /// <summary>
    /// Hides the result page and executes the specified Fungus block.
    /// </summary>
    public void OnClickResultPage()
    {

        // Execute the specified Fungus block
        if (flowchart != null && !string.IsNullOrEmpty(fungusBlockName))
        {
            flowchart.ExecuteBlock(fungusBlockName);
        }
        else
        {
            Debug.LogWarning("Flowchart or block name is missing!");
        }

        gameObject.SetActive(false);
    }
}
