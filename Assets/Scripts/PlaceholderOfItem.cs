using UnityEngine;
using UnityEngine.UI;

public class PlaceholderOfItem : MonoBehaviour
{
    public Part Part;
    private Image image;
    private Vector2 initialPosition;

    public void Init()
    {
        image = GetComponent<Image>();
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        image.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        image.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        image.color = Color.white;
    }
}