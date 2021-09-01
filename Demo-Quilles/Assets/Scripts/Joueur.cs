using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public GameObject boule;
    public GameObject fleche;

    public Vector3 decalageInitialFleche;
    public float vitesse;
    public float vitesseRotation;

    private float rotationInitialeFleche;

    // Contrôles
    [Header("Contrôles")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;
    public KeyCode toucheRotationGauche = KeyCode.Q;
    public KeyCode toucheRotationDroite = KeyCode.E;

    // Bornes
    [Header("Bornes")]
    public float limiteX;
    public float rotationMax;

    // Start is called before the first frame update
    void Start()
    {
        fleche.transform.position = boule.transform.position + decalageInitialFleche;
        rotationInitialeFleche = fleche.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacements latéraux
        if (Input.GetKey(toucheDroite))
        {
            if (boule.transform.position.x < limiteX)
            {
                boule.transform.position += Vector3.right * vitesse * Time.deltaTime;
                fleche.transform.position += Vector3.right * vitesse * Time.deltaTime;
            }
        }
        if (Input.GetKey(toucheGauche))
        {
            if (boule.transform.position.x > -limiteX)
            {
                boule.transform.position += Vector3.left * vitesse * Time.deltaTime;
                fleche.transform.position += Vector3.left * vitesse * Time.deltaTime;
            }
        }

        // Rotation
        if (Input.GetKey(toucheRotationDroite))
        {
            if (fleche.transform.rotation.eulerAngles.y < rotationInitialeFleche + rotationMax)
            {
                fleche.transform.RotateAround(boule.transform.position, Vector3.up, vitesseRotation * Time.deltaTime);
            }
        }
        if (Input.GetKey(toucheRotationGauche))
        {
            if (fleche.transform.rotation.eulerAngles.y > rotationInitialeFleche - rotationMax)
            {
                fleche.transform.RotateAround(boule.transform.position, Vector3.up, -1 * vitesseRotation * Time.deltaTime);
            }
        }
    }
}
