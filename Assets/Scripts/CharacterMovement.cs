using UnityEngine;
using CnControls;
namespace UnityStandardAssests.Copy._2D
{

    public class CharacterMovementBackup : MonoBehaviour
    {

        [SerializeField]
        public float moventSpeed = 10f;
        private Rigidbody2D _characterController;



        private Transform _transform;

        private void Awake()
        {
            _characterController = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        private void FixedUpdate()
        {

            var inputVector = new Vector2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
            _characterController.MovePosition (_characterController.position + inputVector * Time.deltaTime * moventSpeed);

            var angle = Mathf.Atan2(inputVector.x, -inputVector.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        }
    }
}