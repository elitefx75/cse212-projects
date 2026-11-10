
/// <summary>
/// This queue is circular. People are added to the back of the queue.
/// When GetNextPerson is called, the next person is returned and placed
/// back into the queue if they have turns remaining.
/// People with zero or negative turns stay in the queue forever.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person and return them to the back of the queue
    /// if they have turns remaining or infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Zero or negative turns mean unlimited turns.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            person.Turns--;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
