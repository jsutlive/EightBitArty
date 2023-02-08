using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] AudioClip batteryPickupClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ArtyMover>().FindBattery();
            SFXManager.RequestClip(batteryPickupClip);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
