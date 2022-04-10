using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPlane : MonoBehaviour
{
    private Material mat;
    private float tilling = 0.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] float tillingSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset = new Vector2(tilling, 0.0f);
        tilling += Time.deltaTime * tillingSpeed;
    }
}
