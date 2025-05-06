using UnityEngine;

public interface IBullet
{
    public int Speed { get; set; }
    public float YRotation { get; set; }
    public int Damage { get; set; }

    public void Move();
}
