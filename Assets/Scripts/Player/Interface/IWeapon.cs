using UnityEngine;

public interface IWeapon
{
    public GameObject BulletGO {  get; set; }
    public float Cadency { get; set; }

    public void ShootWeapon();
}
