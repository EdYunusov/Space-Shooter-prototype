using UnityEngine;

namespace SpaceShooter
{
    public class PowerUpSpeed : PowerUP
    {
        [SerializeField] private SpaceShip ship;
        [SerializeField] private float m_SpeedUP;
        [SerializeField] private float m_Timer;

        protected override void OnPikedUp(SpaceShip ship)
        {
            ship.SpeedUp(m_SpeedUP, m_Timer);
        }
    }
}

