using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeFade : MonoBehaviour
{
    public GameObject cube;

    private Material cubeMat;
    private IEnumerator fadingCoroutine;

    public void TransparencyManager()
    {
        //fade Out
        cubeMat = cube.GetComponent<MeshRenderer>().material;
        fadingCoroutine = TranspInOut(3, true);
        StartCoroutine(fadingCoroutine);
    }

    public IEnumerator TranspInOut(float t, bool fadeOut)
    {
        //fade out
        Debug.Log("cubeMat " + cubeMat);
        while (cubeMat.color.a > 0.0f)
        {
            float timeChange = (Time.deltaTime / t);
            Debug.Log("Before - Changing material:" + cubeMat + " r:" + cubeMat.color.r + " g:" + cubeMat.color.g + " b:" + cubeMat.color.b + " with alpha:" + cubeMat.color.a + " timeChange:" + timeChange);
            Color fadedColor = new Color(cubeMat.color.r, cubeMat.color.g, cubeMat.color.b, cubeMat.color.a - timeChange);
            Debug.Log("Before - FadeColor: " + fadedColor);
            cubeMat.SetColor("_BaseColor", fadedColor);
            Debug.Log("Before - Changing material:" + cubeMat + " r:" + cubeMat.color.r + " g:" + cubeMat.color.g + " b:" + cubeMat.color.b + " with alpha:" + cubeMat.color.a);
            yield return null;
        }
    }

    public void Start()
    {
        TransparencyManager();
    }
}

