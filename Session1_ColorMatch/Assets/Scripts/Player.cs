using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum WeaponType
    { 
        Pistol = 1,
        Rifle  = 2,
        Burst = 3,
    }

    public WeaponType currWeapon = WeaponType.Pistol;


    [SerializeField] float rotSpeed = 5f;

    [SerializeField] GameObject bullet ;
    [SerializeField] Transform cannonT; 

    float horzInput; GameObject bul;

    [Header("Gun References")]    
    public Transform[] gunStreams = new Transform[3];
    Vector3 mousePos;
    private void Start()
    {
        //currWeapon = WeaponType.Rifle;
    }

    Bullet currBulSpawned;

    float rotAngle = 0;
    // Update is called once per frame
    void Update()
    {
        //horzInput = Input.GetAxis("Horizontal");
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = cannonT.transform.position - mousePos;

        rotAngle =  Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg+180.0f;
        //Debug.Log(rotAngle);
        transform.rotation = Quaternion.Euler(0.0f,0.0f,rotAngle);

        if (Input.GetMouseButtonDown(0))
        {
            switch (currWeapon)
            {
                case WeaponType.Pistol:
                    bul = Instantiate(bullet);
                    currBulSpawned = bul.GetComponent<Bullet>();
                    currBulSpawned.SetDirection(gunStreams[1].right, gunStreams[1].position);
                    break;
                case WeaponType.Rifle:
                    for (int i = 0; i <= gunStreams.Length-1; i++)
                    {
                        bul = Instantiate(bullet);
                        currBulSpawned = bul.GetComponent<Bullet>();
                        currBulSpawned.SetDirection(gunStreams[i].right, gunStreams[i].position);
                    }
                    break;
                case WeaponType.Burst:
                    for (int i = 0; i <= 4; i++)
                    {
                        bul = Instantiate(bullet);
                        currBulSpawned = bul.GetComponent<Bullet>();
                        currBulSpawned.SetDirection(gunStreams[1].right,
                             gunStreams[1].position 
                            + (gunStreams[1].right * i * 0.8f));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

