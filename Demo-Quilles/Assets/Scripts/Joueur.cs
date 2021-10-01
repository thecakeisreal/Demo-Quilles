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
    public float tauxChmgtForce;

    private float rotationInitialeFleche;
    private float forceLancer;                  // Force du lancer

    // Contrôles
    [Header("Contrôles")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;
    public KeyCode toucheRotationGauche = KeyCode.Q;
    public KeyCode toucheRotationDroite = KeyCode.E;
    public KeyCode toucheAugmenterForce = KeyCode.W;
    public KeyCode toucheDiminuerForce = KeyCode.S;
    public KeyCode toucheLancer = KeyCode.Space;

    // Bornes
    [Header("Bornes")]
    public float limiteX;
    public float rotationMax;
    public float forceMinimale;
    public float forceMaximale;
    public Color couleurForceMin;
    public Color couleurForceMax;

    // Start is called before the first frame update
    void Start()
    {
        rotationInitialeFleche = fleche.transform.rotation.eulerAngles.y;
        ReinitialiserJoueur();
    }

    // Replace la flèche à sa position initiale
    public void ReinitialiserJoueur()
    {
        fleche.transform.position = boule.transform.position + decalageInitialFleche;
        fleche.transform.rotation = Quaternion.Euler(0f, rotationInitialeFleche, 0f);
        fleche.GetComponent<MeshRenderer>().material.color = couleurForceMin;

        forceLancer = 0f;
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

        // Force du lancer
        if (Input.GetKey(toucheAugmenterForce))
        {
            forceLancer += tauxChmgtForce * Time.deltaTime;
            forceLancer = Mathf.Clamp01(forceLancer);

            fleche.GetComponent<MeshRenderer>().material.color = Color.Lerp(couleurForceMin, couleurForceMax, forceLancer);
            //fleche.transform.localScale = Vector3.one + Vector3.forward * forceLancer;
        }
        if (Input.GetKey(toucheDiminuerForce))
        {
            forceLancer -= tauxChmgtForce * Time.deltaTime;
            forceLancer = Mathf.Clamp01(forceLancer);

            fleche.GetComponent<MeshRenderer>().material.color = Color.Lerp(couleurForceMin, couleurForceMax, forceLancer);
            //fleche.transform.localScale = Vector3.one + Vector3.forward * forceLancer;
        }

        if(Input.GetKeyDown(toucheLancer))
        {
            Rigidbody rigidbodyBoule = boule.GetComponent<Rigidbody>();
            Vector3 directionLancer = fleche.transform.position - boule.transform.position;
            directionLancer.y = 0f;
            rigidbodyBoule.AddForce(directionLancer.normalized * Mathf.Lerp(forceMinimale, forceMaximale, forceLancer),
                ForceMode.Impulse);
        }
    }
}
