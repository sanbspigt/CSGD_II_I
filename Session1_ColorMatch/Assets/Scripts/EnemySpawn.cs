using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] Player player;
    [SerializeField] float radius = 1.5f;
    float xValue, yValue;
    float angle = 0;
    [SerializeField]float divisions = 15;
    float PI = Mathf.PI;//radians(3.1415) || Degrees (180)

    private void Start()
    {
        SpawnEnemies(); 
    }

    private void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        ///Debug.Log(pos);
    }

    EnemyMovement eMove;
    void SpawnEnemies()
    {
        GameObject currInstance;
        for (int i = 0; i < divisions; i++)
        {
            angle = (2 * PI / divisions)*i;
            xValue = radius* Mathf.Cos(angle);
            yValue = radius* Mathf.Sin(angle);

            currInstance = Instantiate(spawner);
            eMove = currInstance.GetComponent<EnemyMovement>();
            currInstance.transform.position = new Vector3(xValue, yValue, 0);
           
            //eMove.MoveTowardsPlayer(Vector3.Normalize(player.gunStreams[1].position));
            Vector3 playerDir = currInstance.transform.position
                - player.transform.position;

            float rotAngle = Mathf.Atan2(playerDir.y, playerDir.x) 
                * Mathf.Rad2Deg + 90.0f;

            eMove.RotateTowardsPlayer(rotAngle);
        }
    }

}
