using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTrigger : MonoBehaviour
{
    private ObjectInput _instance;
    private ObjectInput _objectInput { get { Init(); return _instance; } }

    private int _dediPlayerId;

    private void Init()
    {
        if (_instance == null)
        {
            _instance = transform.GetComponentInParent<ObjectInput>();
            _dediPlayerId = transform.GetComponentInParent<Player>().Info.PlayerId;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Managers.Time._isDay) //��
        {
            //�� Ʈ���� ó��
            if (other.CompareTag("Trap") && !other.transform.GetComponent<Trap>()._isAlreadyTrapped)
            {
                other.transform.GetComponent<Trap>()._isAlreadyTrapped = true;
                other.transform.GetComponent<SphereCollider>().enabled = false;
                string trapId = other.transform.GetComponent<Trap>()._trapId;
                other.transform.GetComponent<Trap>().OnHit();
                _objectInput.ProcessTrapped(_dediPlayerId, trapId);
            }
        }
        else //��
        {
            //�� Ʈ���� ó��
            if (other.CompareTag("Trap") && !other.transform.GetComponent<Trap>()._isAlreadyTrapped)
            {
                other.transform.GetComponent<Trap>()._isAlreadyTrapped = true;
                other.transform.GetComponent<SphereCollider>().enabled = false;
                string trapId = other.transform.GetComponent<Trap>()._trapId;
                other.transform.GetComponent<Trap>().OnHit();
                _objectInput.ProcessTrapped(_dediPlayerId, trapId);
            }
        }
    }
}