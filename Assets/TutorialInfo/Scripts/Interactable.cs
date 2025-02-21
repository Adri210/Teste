using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string customMessage; // Mensagem personalizada para a intera��o
    public Color newColor = Color.red; // Cor que o objeto assumir� ao interagir

    private Renderer objectRenderer; // Refer�ncia ao componente Renderer do objeto
    private Color originalColor; // Cor original do objeto

    private void Start()
    {
        // Obt�m o componente Renderer do objeto
        objectRenderer = GetComponent<Renderer>();

        // Salva a cor original do objeto
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogWarning("Renderer n�o encontrado no objeto!");
        }
    }

    public string GetInteractionMessage()
    {
        return string.IsNullOrEmpty(customMessage) ? "Interagir com " + gameObject.name : customMessage;
    }

    public void Interact()
    {
        if (objectRenderer != null)
        {
            // Alterna entre a cor original e a nova cor
            if (objectRenderer.material.color == originalColor)
            {
                objectRenderer.material.color = newColor;
            }
            else
            {
                objectRenderer.material.color = originalColor;
            }

            Debug.Log($"Interagiu com {gameObject.name} e mudou a cor para {objectRenderer.material.color}");
        }
        else
        {
            Debug.LogWarning("Renderer n�o encontrado no objeto!");
        }
    }
}