using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] AudioSource batteryAudio;
    [SerializeField] GameObject mesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<ArtyPowerup>().HasBattery()) return;
            other.GetComponent<ArtyPowerup>().SetBattery(true);
            batteryAudio.Play();
            mesh.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
