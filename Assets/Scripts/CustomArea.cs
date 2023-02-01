using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomArea : MonoBehaviour
{   
    [Header("Changes that should happen when player enters trigger zone")]
    [Tooltip("The list of all audio sources in the zone")]
    public List<AudioSource> AS = new List<AudioSource>();
    [Tooltip("The camera")]
    private GameObject Camera;
    [Tooltip("How the pitch should change when you enter zone")]
    public AnimationCurve pitchChange;
    [Tooltip("How the volume should change when you enter zone")]
    public AnimationCurve volumeChange;
    [Tooltip("How the pan stereo should change when you enter zone")]
    public AnimationCurve panStereoChange;
    [Tooltip("How the camera should rotate on the y axis when you enter zone")]
    public AnimationCurve CameraYAxisChange;
    [Tooltip("How the camera should rotate on the x axis when you enter zone")]
    public AnimationCurve CameraXAxisChange;
    [Tooltip("How the camera should rotate on the z axis when you enter zone")]
    public AnimationCurve CameraZAxisChange;
    [Tooltip("The floor attached to the level")]
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(AudioSource E in AS)
        {
            E.pitch = pitchChange.Evaluate(Time.time);
            E.volume = volumeChange.Evaluate(Time.time);
            E.panStereo = panStereoChange.Evaluate(Time.time);
        }
        if (Camera != null)
        {
            Camera.transform.rotation = Quaternion.Euler(CameraXAxisChange.Evaluate(Time.time), CameraYAxisChange.Evaluate(Time.time), CameraZAxisChange.Evaluate(Time.time));

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponents<AudioSource>().Length != 0)
        {
            AS.AddRange(other.GetComponents<AudioSource>());
        }
        if (other.CompareTag("Player"))
        {
            Camera = other.GetComponent<Movement>().Camera;
            floor.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<AudioSource>())
        {
            for(int i = 0; i < other.GetComponents<AudioSource>().Length; i++)
            {
                AS.Remove(other.GetComponents<AudioSource>()[i]);
                other.GetComponents<AudioSource>()[i].pitch = 1;
                other.GetComponents<AudioSource>()[i].volume = 1;
                other.GetComponents<AudioSource>()[i].panStereo = 0;
            }
        }
        if (!other.CompareTag("Particle"))
        {
            Camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            Camera = null;
            floor.SetActive(false);
        }
    }
}
