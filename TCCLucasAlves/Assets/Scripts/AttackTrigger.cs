using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;
    public Transform hitPoint;
    public GameObject damageNumber;

    void OnTriggerEnter2D(Collider2D col){
        if(col.isTrigger != true && col.CompareTag("Enemy")){
            col.SendMessageUpwards("Damage", dmg);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = dmg;
        }
    }
}
