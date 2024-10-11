using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            gameData.GuessedLetters.Add(letter);
            bool letterWasFound = false;
            for (int i = 0; i < gameData.Word.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    letterWasFound = true;
                    RevealLetterEvent newEvent = new RevealLetterEvent(gameData,letter,i);
                    if (Events != null)
                    {
                        Events.Add(newEvent);
                    }
                    else
                    {
                        Events = new List<GameEvent>();
                        Events.Add(newEvent);
                    }
                }                   
            }
            if (letterWasFound)
            {
                //Events.Add(new GuessedLetterEvent(gameData,letter));
            }
            else
            {
                WrongGuessEvent newEvent = new WrongGuessEvent(gameData);
                if (Events != null)
                {
                    Events.Add(newEvent);
                }
                else
                {
                    Events = new List<GameEvent>();
                    Events.Add(newEvent);
                }
            }
        }
    }
}
