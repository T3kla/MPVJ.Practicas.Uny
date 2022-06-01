using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoloDetector : MonoBehaviour
{

    [SerializeField] private BoloGame Game = null;

    private List<GameObject> Bolos = new List<GameObject>();

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Bolo")
            if (!Bolos.Contains(Col.gameObject))
            {
                Bolos.Add(Col.gameObject);
                Game?.AddScore(1);
            }
    }
}
