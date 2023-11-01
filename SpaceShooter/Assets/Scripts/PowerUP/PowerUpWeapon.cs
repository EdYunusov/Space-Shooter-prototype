using UnityEngine;

namespace SpaceShooter
{
    public class PowerUpWeapon : PowerUP
    {
        [SerializeField] private TurretProp m_Properites;

        protected override void OnPikedUp(SpaceShip ship)
        {
            ship.AssignWeapon(m_Properites);
        }
    }
}
