using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;

    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI levelText;

    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;
        
        levelText.text = "lv. " + level.ToString();
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = unit.position + offset;
        levelText.text = "lv. " + level.ToString();
    }

    public void SetLevel(int charLevel)
    {
        level = charLevel; 
    }

}
