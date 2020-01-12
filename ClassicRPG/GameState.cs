using ClassicRPG.Character;

namespace ClassicRPG
{
    class GameState
    {
        public GameState()
        {
            Reset();
        }

        public void Reset()
        {
            IsPlaying = true;
            Character = new CharacterState();
        }

        public bool IsPlaying { get; set; }

        public CharacterState Character { get; set; }
    }
}
