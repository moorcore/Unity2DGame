using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    [SerializeField]
    private Texture2D cursorTexture;

    public void OnHover()
    {
        audioSource.PlayOneShot(hoverFX);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void OnClick()
    {
        audioSource.PlayOneShot(clickFX);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
