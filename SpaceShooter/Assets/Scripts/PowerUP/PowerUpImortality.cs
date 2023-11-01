using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerUpImortality : PowerUP
    {
        [SerializeField] private SpaceShip ship;
        [SerializeField] private float m_Timer;
        protected override void OnPikedUp(SpaceShip ship)
        {
            ship.Imortality(m_Timer);
        }
    }
}

