using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform spawn;

    private void SpawnRocket()
    {
        Instantiate(rocketPrefab, spawn.position, spawn.rotation);
    }
}
