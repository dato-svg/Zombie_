using UnityEngine;

namespace BaseScript.PlayerMove
{
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int Run = UnityEngine.Animator.StringToHash("Run");
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Transform player;
        [SerializeField] private UnityEngine.Animator animatorPlayer;
        
        private Rigidbody2D _rb;
        private IInputService _input;
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = new InputService();
        }

        private void FixedUpdate()
        {
            Vector2 input = _input.MovementInput;

            if (input.x != 0 || input.y != 0)
                animatorPlayer.SetBool(Run, true);
            else
                animatorPlayer.SetBool(Run, false);

            Vector2 newPosition = _rb.position + input * moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(newPosition);
            
            if (input.x > 0)
            {
                player.localScale = new Vector3(1.145125f, player.localScale.y, player.localScale.z);
            }
            else if (input.x < 0)
            {
                player.localScale = new Vector3(-1.145125f, player.localScale.y, player.localScale.z);
            }
        }
    }
}