using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;

[System.Serializable]
public class Contact : IEquatable<Contact>
{
    public CubeBehaviour cube;
    public Vector3 face;
    public float penetration;

    public Contact(CubeBehaviour cube)
    {
        this.cube = cube;
        face = Vector3.zero;
        penetration = 0.0f;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Contact objAsContact = obj as Contact;
        if (objAsContact == null) return false;
        else return Equals(objAsContact);
    }

    public override int GetHashCode()
    {
        return this.cube.gameObject.GetInstanceID();
    }

    public bool Equals(Contact other)
    {
        if (other == null) return false;

        return (
            (this.cube.gameObject.name.Equals(other.cube.gameObject.name)) &&
            (this.face == other.face) &&
            (Mathf.Approximately(this.penetration, other.penetration))
            );
    }

    public override string ToString()
    {
        return "Cube Name: " + cube.gameObject.name + " face: " + face.ToString() + " penetration: " + penetration;
    }
}

[System.Serializable]
public class PlayerContact : IEquatable<PlayerContact>
{
    public PlayerBehaviour player;
    public Vector3 face;
    public float penetration;

    public PlayerContact(PlayerBehaviour player)
    {
        this.player = player;
        face = Vector3.zero;
        penetration = 0.0f;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        PlayerContact objAsContact = obj as PlayerContact;
        if (objAsContact == null) return false;
        else return Equals(objAsContact);
    }

    public override int GetHashCode()
    {
        return this.player.gameObject.GetInstanceID();
    }

    public bool Equals(PlayerContact other)
    {
        if (other == null) return false;

        return (
            (this.player.gameObject.name.Equals(other.player.gameObject.name)) &&
            (this.face == other.face) &&
            (Mathf.Approximately(this.penetration, other.penetration))
            );
    }

    public override string ToString()
    {
        return "Player Name: " + player.gameObject.name + " face: " + face.ToString() + " penetration: " + penetration;
    }
}

[System.Serializable]
public class BulletContact : IEquatable<BulletContact>
{
    public BulletBehaviour bullet;
    public Vector3 face;
    public float penetration;

    public BulletContact(BulletBehaviour bullet)
    {
        this.bullet = bullet;
        face = Vector3.zero;
        penetration = 0.0f;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        BulletContact objAsContact = obj as BulletContact;
        if (objAsContact == null) return false;
        else return Equals(objAsContact);
    }

    public override int GetHashCode()
    {
        return this.bullet.gameObject.GetInstanceID();
    }

    public bool Equals(BulletContact other)
    {
        if (other == null) return false;

        return (
            (this.bullet.gameObject.name.Equals(other.bullet.gameObject.name)) &&
            (this.face == other.face) &&
            (Mathf.Approximately(this.penetration, other.penetration))
            );
    }

    public override string ToString()
    {
        return "Bullet Name: " + bullet.gameObject.name + " face: " + face.ToString() + " penetration: " + penetration;
    }
}


[System.Serializable]
public class CubeBehaviour : MonoBehaviour
{
    [Header("Cube Attributes")]
    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;
    public bool debug;
    public bool isStatic;
    public List<Contact> contacts;
    public List<PlayerContact> playerContacts;
    public List<BulletContact> bulletContacts;

    private MeshFilter meshFilter;
    public Bounds bounds;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        debug = false;
        isStatic = false;
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;

    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawWireCube(transform.position, Vector3.Scale(new Vector3(1.0f, 1.0f, 1.0f), transform.localScale));
        }
    }

}
