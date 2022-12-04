using UnityEngine;

[ExecuteInEditMode]
public class ShaderHandle : MonoBehaviour
{
    [SerializeField] private Material effectMaterial;

    public Material EffMaterial { get => effectMaterial; }

    private void OnRenderImage(RenderTexture src, RenderTexture dest) 
    {
        Graphics.Blit(src,dest,effectMaterial);
    }
}
