using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoloGame : MonoBehaviour
{

    [Header("Game")]
    [SerializeField] private Transform BoloPrefab = null;
    [SerializeField] private Transform BolaPrefab = null;
    [SerializeField] private List<Transform> BoloPositions = new List<Transform>();
    [SerializeField] private Transform BolaPosition = null;
    [SerializeField] private float BolaSpeed = 0.0f;

    [Header("UI")]
    [SerializeField] private TMP_Text ScoreNumber = null;

    private Transform Bola = null;
    private Rigidbody BolaRB = null;

    private int Score = 0;

    private void Awake()
    {
        // Spawn bolos
        foreach (var pos in BoloPositions)
            Instantiate(BoloPrefab, pos.position, Quaternion.identity);

        // Spawn bola
        Bola = Instantiate(BolaPrefab, BolaPosition.position, BolaPosition.rotation);
        BolaRB = Bola.GetComponent<Rigidbody>();

        // Set score
        ScoreNumber.text = Score.ToString();
    }

    private void Start()
    {
    }

    private void Update()
    {
        // If player press space, add force to bola
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BolaRB.AddForce(Vector3.forward * BolaSpeed, ForceMode.Impulse);
            BolaRB.AddTorque(Vector3.right * BolaSpeed, ForceMode.Impulse);
        }
    }

    public void AddScore(int score)
    {
        Score += score;
        ScoreNumber.text = Score.ToString();
    }

}
