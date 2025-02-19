using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TargetSpawner : MonoBehaviour
{
    public ButtonFollowVisual button;
    public GameObject targetPrefab;
    public GameObject movingTargetPrefab;
    public GameObject hardMovingTargetPrefab;
    [SerializeField] int targetsNumber = 3;
    [SerializeField] int movingNumber = 0;
    [SerializeField] int hardNumber = 0;
    [SerializeField] float xAmplitude = 20;
    [SerializeField] float yAmplitude = 0;
    [SerializeField] float zAmplitude = 0;

    void OnEnable(){
        button.buttonPressed+= SpawnTargets;
    }
    void OnDisable(){
        button.buttonPressed-= SpawnTargets;
    }
    public void SpawnTargets(){
        for(int i = 0; i < targetsNumber;i++){
            Vector3 position = gameObject.transform.position;
            position.x += Random.Range(-xAmplitude, xAmplitude);
            position.y += Random.Range(-yAmplitude,yAmplitude);
            position.z += Random.Range(-zAmplitude,zAmplitude);
            Instantiate(targetPrefab, position, Quaternion.identity, gameObject.transform);
        }
        for(int i = 0; i < movingNumber;i++){
            Vector3 position = gameObject.transform.position;
            position.x += Random.Range(-xAmplitude, xAmplitude);
            position.y += Random.Range(-yAmplitude,yAmplitude);
            position.z += Random.Range(-zAmplitude,zAmplitude);
            Instantiate(movingTargetPrefab, position, Quaternion.identity, gameObject.transform);
        }
        for(int i = 0; i < hardNumber;i++){
            Vector3 position = gameObject.transform.position;
            position.x += Random.Range(-xAmplitude, xAmplitude);
            position.y += Random.Range(-yAmplitude,yAmplitude);
            position.z += Random.Range(-zAmplitude,zAmplitude);
            Instantiate(hardMovingTargetPrefab, position, Quaternion.identity, gameObject.transform);
        }
    }

}
