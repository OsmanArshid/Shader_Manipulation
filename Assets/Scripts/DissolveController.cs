using UnityEngine;
using UnityEngine.UI; // Required for color picker functionality
using System.Collections;

public class DissolveController : MonoBehaviour
{
    [Header("Dissolve Properties")]
    [SerializeField, Range(0f, 1f)] private float dissolvePercentage = 0f; // slider for dissolve percentage
    [SerializeField] private Color edgeColor = Color.red; // da color picker for edge color of sphere


    [Header("Dissolve Animation Settings")] // so u can find easily 
    [SerializeField] private float dissolveTime = 1f; // time it will take to fully dissolve 
    private Material dissolveMaterial; // da dissolve shader material


    private void Start()
    {

        Renderer renderer = GetComponent<Renderer>(); // fetching the render applied on da sphere
        if (renderer == null)
        {
            Debug.LogError("No Renderer found");
            return;
        }

        dissolveMaterial = renderer.material;
        if (dissolveMaterial == null)
        {
            Debug.LogError("No material found");
            return;
        }


        UpdateDissolveProperties(); // da initial shader values
    }

    private void Update()
    {

        UpdateDissolveProperties(); // the updating for the inspector variables

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveSphereOverTime()); // starting the dissolving
        }
    }

    private void UpdateDissolveProperties()
    {
        // updating da dissolve percentage in da shader
        dissolveMaterial.SetFloat("_DissolveAmount", dissolvePercentage);

        // updating edge color in da shader
        dissolveMaterial.SetColor("_EdgeColor", edgeColor);
    }

    private IEnumerator DissolveSphereOverTime()
    {
        float elapsedTime = 0f;

        // Start dissolving over the defined dissolveTime
        while (elapsedTime < dissolveTime)
        {
            dissolvePercentage = Mathf.Lerp(0f, 1f, elapsedTime / dissolveTime);
            dissolveMaterial.SetFloat("_DissolveAmount", dissolvePercentage);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dissolveMaterial.SetFloat("_DissolveAmount", 1f);  // ensuring the sphere is fully dissolved


        // Destroy the GameObject
        Destroy(gameObject);
    }
}

