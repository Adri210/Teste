using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string customMessage; // Mensagem personalizada para a intera��o
    public Color newColor = Color.red; // Cor que o objeto assumir� ao interagir

    private MeshRenderer meshRenderer; // Refer�ncia ao componente MeshRenderer do objeto
    private Color originalColor; // Cor original do objeto

    private void Start()
    {
        // Obt�m o componente MeshRenderer do objeto
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // Salva a cor original do objeto
            originalColor = meshRenderer.material.color;
        }
        else
        {
            Debug.LogWarning("MeshRenderer n�o encontrado no objeto!");
        }
    }

    public string GetInteractionMessage()
    {
        return string.IsNullOrEmpty(customMessage) ? "Interagir com " + gameObject.name : customMessage;
    }

    public void Interact()
    {
        if (meshRenderer != null)
        {
            // Alterna entre a cor original e a nova cor
            if (meshRenderer.material.color == originalColor)
            {
                meshRenderer.material.color = newColor;
            }
            else
            {
                meshRenderer.material.color = originalColor;
            }

            Debug.Log($"Interagiu com {gameObject.name} e mudou a cor para {meshRenderer.material.color}");
        }
        else
        {
            Debug.LogWarning("MeshRenderer n�o encontrado no objeto!");
        }
    }
}