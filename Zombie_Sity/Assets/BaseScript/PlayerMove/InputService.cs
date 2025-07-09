using UnityEngine;

namespace BaseScript.PlayerMove
{
    public class InputService : IInputService
    {
        public Vector2 MovementInput => new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }
}
