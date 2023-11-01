using UnityEngine;


namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class PowerUP : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if(ship !=null)
            {
                Destroy(gameObject);
                OnPikedUp(ship);
            }
        }

        protected abstract void OnPikedUp(SpaceShip ship);

    }
}

