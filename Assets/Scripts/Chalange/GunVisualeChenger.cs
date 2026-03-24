using UnityEngine;

public class GunVisualeChenger : MonoBehaviour
{
    public static GunVisualeChenger vusuale;

    [SerializeField] private SpriteRenderer rifleSprite;
    [SerializeField] private SpriteRenderer shortySprite;

    [Range(0f, 1f)]
    public float rifleTransitionValue;
    public Color rifleTint;
    public Color rifleColor;

    [Range(0f, 1f)]
    public float shortyTransitionValue;
    public Color shortyTint;
    public Color shortyColor;

    private void Awake()
    {
        vusuale = this;
    }

    public SpriteRenderer RifleSprite => rifleSprite;
    public SpriteRenderer ShortySprite => shortySprite;

    private void Start()
    {
        shortyColor = Color.white;
        rifleColor = Color.white;
    }

    float bee = 0;
    float tee = 0;
    public void ChangeRifleColor(float blendValue)
    {
        bee += blendValue;
        rifleSprite.color = Color.Lerp(rifleColor, rifleTint, bee);
    }
    public void ChangeShortyColor(float blendValue)
    {
        tee += blendValue;
        shortySprite.color = Color.Lerp(shortyColor, shortyTint, tee);
    }

}
