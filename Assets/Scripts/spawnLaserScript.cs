using UnityEngine;
using UnityEngine.InputSystem;

public class spawnLaserScript : MonoBehaviour
{
    public GameObject laser;
    private void OnShoot()
    {
        Instantiate(laser, transform.position, transform.rotation);
    }
}
