namespace PokeAPI.DB;

public record Pokemon
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class PokeDB
{
    private static List<Pokemon> _pokemons = new List<Pokemon>()
    {
        new Pokemon { Id = 1, Name = "Ash, seu amigao. " },
        new Pokemon { Id = 2, Name = "Pikachu, o seu amigo mais pika. " },
        new Pokemon { Id = 3, Name = "Bonossauro, sua vacina mais efetiva. " }
    };

    public static List<Pokemon> GetPokemon()
    {
        return _pokemons;
    }

    public static Pokemon? GetPokemon(int id)
    {
        return _pokemons.SingleOrDefault(pokemon => pokemon.Id == id);
    }

    public static Pokemon CreatePokemon(Pokemon pokemon)
    {
        _pokemons.Add(pokemon);
        return pokemon;
    }

    public static Pokemon UpdatePokemon(Pokemon update)
    {
        _pokemons = _pokemons.Select(pokemon =>
        {
            if (pokemon.Id == update.Id)
            {
                pokemon.Name = update.Name;
            }

            return pokemon;
        }).ToList();
        return update;
    }

    public static void RemovePokemon(int id)
    {
        _pokemons = _pokemons.FindAll(pokemon => pokemon.Id != id).ToList();
    }
}