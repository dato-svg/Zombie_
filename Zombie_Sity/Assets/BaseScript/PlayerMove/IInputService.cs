using UnityEngine;

namespace BaseScript.PlayerMove
{
    public interface IInputService
    {
        Vector2 MovementInput { get; }
    }
}
