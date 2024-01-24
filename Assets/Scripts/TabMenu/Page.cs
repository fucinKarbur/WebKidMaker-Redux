using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public PageControl Control { get; private set; }

    private void Awake()
    {
        Control = GetComponentInChildren<PageControl>();
    }
}
