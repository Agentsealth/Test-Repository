using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public string[] targetTags;
    public float curHealth, maxHealth, moveSpeed, rotSpeed, baseDamge, inputBlend;
    public bool isDead;
    public GameObject BloodEffect;
    public float acceleration;

    private float maxSpeed = 1.1f;
    protected int _actIDx;
    protected Vector4 _rawVals, _curVals;
    protected AnimatorStateInfo _curAnim;

    protected CharacterController _char;
    protected Animator _anim;
    protected const float GRAVITY = -1f;




	// Use this for initialization
	protected void Start () {
        _anim = GetComponent<Animator>();
        _char = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	protected void Update () {
        _curAnim = _anim.GetCurrentAnimatorStateInfo(0);


        if (!_curAnim.IsTag("inAction"))
            if (_actIDx != 0)
                SetActIdx(0);

        _curVals = Vector4.Lerp(_curVals, _rawVals, inputBlend * Time.deltaTime);
        _anim.SetFloat("_x", _curVals.x);
        _anim.SetFloat("_y", _curVals.y);
        _anim.SetFloat("_z", _curVals.z);
        _anim.SetFloat("_r", _curVals.w);


    }

    public void SetActIdx(int idx)
    {
        _actIDx = idx;
        _anim.SetInteger("_actIDX", idx);
    }

    protected virtual void ApplyRotation()
    {
        float _rProj = _anim.GetFloat("_rProj");

        float _curRot = transform.eulerAngles.y;
        float _wantRot = _curRot + (((rotSpeed * Time.deltaTime) * _curVals.w) * _rProj);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
            _wantRot,
            transform.eulerAngles.z);

    }

    protected virtual void ApplyMovement()
    {
        float _zProj = _anim.GetFloat("_zProj");
        float _xProj = _anim.GetFloat("_xProj");
        moveSpeed += Time.deltaTime * acceleration;
        if (moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }
        Vector3 _moveDir = new Vector3((moveSpeed * Time.deltaTime * 2) * _xProj,
                                        GRAVITY,
                                        (moveSpeed * Time.deltaTime * 2) * _zProj);

        _moveDir = transform.TransformDirection(_moveDir);
        _char.Move(_moveDir);

    }

    Transform FindNode(string nodeName)
    {
        Transform[] allNodes = GetComponentsInChildren<Transform>();
        for(int i = 0; i < allNodes.Length; i++)
        {
            if(allNodes[i].name == nodeName)
            {
                return allNodes[i];
            }
        }

        return null;
    }

    public void ActivateHitboxes(string nodeName)
    {
        Transform node = FindNode(nodeName);
        foreach(Hitbox hit in node.GetComponentsInChildren<Hitbox>())
        {
            hit.isActive = true;

            Vector3 BloodSpawn = new Vector3(node.position.x, node.position.y, node.position.z);
            Quaternion rotation = Quaternion.Euler(node.rotation.eulerAngles.x, node.rotation.eulerAngles.y, node.rotation.eulerAngles.z);
            Instantiate(BloodEffect.transform, BloodSpawn, rotation);

        }
    }

    public void DeactivateHitboxes(string nodeName)
    {
        Transform node = FindNode(nodeName);
        foreach (Hitbox hit in node.GetComponentsInChildren<Hitbox>())
        {
            hit.isActive = false;
            hit.ClearHits();
        }
    }

    public void ResetHitboxes(string nodeName)
    {
        Transform node = FindNode(nodeName);
        foreach (Hitbox hit in node.GetComponentsInChildren<Hitbox>())
        {
            hit.ClearHits();
        }
    }
}
