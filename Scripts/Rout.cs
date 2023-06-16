using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rout : MonoBehaviour
{
    [SerializeField]
    GameObject Sqr;
    [SerializeField]
    GameObject Ro;
    [SerializeField]
    GameObject SqrDr;
    [SerializeField]
    GameObject RoDr;
    public bool pol;
    private string name;
    private bool _insideCollision;
    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        Sqr.SetActive(false);
        Ro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_insideCollision && pol && name == "SqrOt" && !isDragging)
        {
            Sqr.SetActive(true);
            Destroy(SqrDr);
        }
        if (_insideCollision && !pol && name == "RoOt" && !isDragging)
        {
            Ro.SetActive(true);
            Destroy(RoDr);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
            name = other.gameObject.name;
            _insideCollision = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
}
