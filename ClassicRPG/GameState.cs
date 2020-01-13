using ClassicRPG.Character;
using ClassicRPG.Enemies;
using System.Collections.Generic;

namespace ClassicRPG
{
    public enum Place
    {
        Menu,
        Tutorial,
        SafeZone,
        UnsafeZone
    }

    public class GameState
    {
        public GameState()
        {
            Reset();
        }

        public void Reset()
        {
            IsPlaying = true;
            Place = Place.Menu;
            Character = new CharacterState();
            Enemies = new List<Enemy>();
        }

        public bool IsPlaying { get; set; }

        public Place Place { get; set; }

        public ICollection<Enemy> Enemies { get; set; }

        public CharacterState Character { get; set; }
    }
}
