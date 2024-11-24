using UnityEngine;
using UnityEngine.UI; // Required for color picker functionality
using System.Collections;

public class DissolveController : MonoBehaviour
{
    [Header("Dissolve Properties")]
    [SerializeField, Range(0f, 1f)] private float dissolvePercentage = 0f; // Slider for dissolve percentage
    [SerializeField] private Color edgeColor = Color.red; // Color picker for edge color

    [Header("Dissolve Animation Settings")]
    [SerializeField] private float dissolveTime = 1f; // Time to fully dissolve (default: 1 second)
    private Material dissolveMaterial; // Reference to the dissolve shader material

    private void Start()
    {
        // Fetch the material applied to the sphere
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer found on the GameObject!");
            return;
        }

        dissolveMaterial = renderer.material;
        if (dissolveMaterial == null)
        {
            Debug.LogError("No material found on the Renderer!");
            return;
        }

        // Set initial shader values
        UpdateDissolveProperties();
    }

    private void Update()
    {
        // Dynamically update shader properties from exposed variables
        UpdateDissolveProperties();

        // Example Input: Trigger dissolve using the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveSphereOverTime());
        }
    }

    private void UpdateDissolveProperties()
    {
        // Update dissolve percentage in the shader
        dissolveMaterial.SetFloat("_DissolveAmount", dissolvePercentage);

        // Update edge color in the shader
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

        // Ensure the sphere is fully dissolved
        dissolveMaterial.SetFloat("_DissolveAmount", 1f);

        // Destroy the GameObject
        Destroy(gameObject);
    }
}
