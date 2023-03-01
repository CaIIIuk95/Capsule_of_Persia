using UnityEngine;

public class Bear : MonoBehaviour
{
    public GameObject RocketPrefab;
    public Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnRocket()
    {
        Instantiate(RocketPrefab,Spawn.position,Spawn.rotation);
    }
}
