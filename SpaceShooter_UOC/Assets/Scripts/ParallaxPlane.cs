using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPlane : MonoBehaviour
{
    private Material mat;
    public float offsetX = 0.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] float offsetSpeed = 0.1f;
    bool isMyShader = false;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        if (mat.shader.name == "Shader Graphs/NoBlack") isMyShader = true;
        else isMyShader = false;
    }

    // Update is called once per frame
    void Update()
    {
        offsetX += Time.deltaTime * offsetSpeed;

        if (isMyShader)
            mat.SetFloat("_Offset", offsetX);
        else
            mat.mainTextureOffset = new Vector2(offsetX, 0.0f);
    }
}
