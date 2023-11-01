using UnityEngine;

namespace SpaceShooter
{
    public class MovementController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;

        [SerializeField] private VirtualJoystick m_MobileJoystick;
        [SerializeField] private ControlMode m_ControlMode;
        [SerializeField] private PointerClickHold m_MobildeFirePrimary;
        [SerializeField] private PointerClickHold m_MobildeFireSecondary;

        private void Start()
        {
            if (m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileJoystick.gameObject.SetActive(false);
                m_MobildeFirePrimary.gameObject.SetActive(false);
                m_MobildeFireSecondary.gameObject.SetActive(false);
            }
            else
            {
                m_MobileJoystick.gameObject.SetActive(true);
                m_MobildeFirePrimary.gameObject.SetActive(true);
                m_MobildeFireSecondary.gameObject.SetActive(true);
            }
                
        }

        private void Update()
        {
            if (m_TargetShip == null) return;

            if (m_ControlMode == ControlMode.Keyboard)
                ControlKeyboard();
            if (m_ControlMode == ControlMode.Mobile)
                ControlMobile();
        }

        private void ControlMobile()
        {
            var dir = m_MobileJoystick.Value;
            m_TargetShip.ThrustControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;

            if (m_MobildeFirePrimary.isHold == true)
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }
            if (m_MobildeFirePrimary.isHold == true)
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }
        }

        private void ControlKeyboard()
        {

            float thrust = 0;
            float torque = 0;

            if (Input.GetKey(KeyCode.UpArrow))
                thrust = 1.0f;
            if (Input.GetKey(KeyCode.DownArrow))
                thrust = -1.0f;
            if (Input.GetKey(KeyCode.LeftArrow))
                torque = 1.0f;
            if (Input.GetKey(KeyCode.RightArrow))
                torque = -1.0f;

            if (Input.GetKey(KeyCode.W))
                thrust = 1.0f;
            if (Input.GetKey(KeyCode.S))
                thrust = -1.0f;
            if (Input.GetKey(KeyCode.A))
                torque = 1.0f;
            if (Input.GetKey(KeyCode.D))
                torque = -1.0f;

            if(Input.GetKey(KeyCode.Space))
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }
            if (Input.GetKey(KeyCode.X))
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }

            m_TargetShip.ThrustControl = thrust;
            m_TargetShip.TorqueControl = torque;
        }
    }
}

