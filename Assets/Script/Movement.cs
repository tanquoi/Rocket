using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem leftParticle;

    Rigidbody rb;
    AudioSource audioSource;

    //start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessThurst();
    }

    public void ProcessThurst()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    public void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            RotateStop();
        }
    }

    public void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!rightParticle.isPlaying)
        {
            rightParticle.Play();
        }
    }

    public void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!leftParticle.isPlaying)
        {
            leftParticle.Play();
        }
    }
    void RotateStop()
    {
        leftParticle.Stop();
        rightParticle.Stop();
    }

    public void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    public void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }


    public void ApplyRotation( float ratationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * ratationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
