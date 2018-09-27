using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public string[] targetTags;
    public float dmgMultiplier;
    public bool isActive;
    public string broadcastMethod;

    private List<Hitbox> _hitboxes = new List<Hitbox>();
    private List<GameObject> _hitobjects = new List<GameObject>();
    private float _dmgBase;


    // Use this for initialization
    void Start () {
        Entity owner = transform.root.GetComponent<Entity>();
        targetTags = owner.targetTags;
        _dmgBase = owner.baseDamge;
        foreach(Hitbox hit in transform.parent.GetComponentsInChildren<Hitbox>())
        {
            if (hit != this)
                _hitboxes.Add(hit);
        }
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col)
    {
        if (!isActive)
            return;

        foreach(string tag in targetTags)
        {
            if(col.gameObject.CompareTag(tag))
            {
                if(!HasHit(col.gameObject))
                {
                    foreach(Hitbox hit in _hitboxes.ToArray())
                    {
                        RegisterHit(col.gameObject);
                    }
                    RegisterHit(col.gameObject);

                }
            }
        }
	}

    bool HasHit(GameObject obj)
    {
        foreach(GameObject hitobj in _hitobjects.ToArray())
        {
            if (hitobj == obj)
                return true;
        }

        return false;
    }

    public void RegisterHit(GameObject obj)
    {
        _hitobjects.Add(obj);
    }

    public void ClearHits()
    {
        _hitobjects.Clear();
    }
}
