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
        new Pokemon { Id = 1, Name = "Bulbasaur, There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger. " },
        new Pokemon { Id = 2, Name = "Pikachu, When it is angered, it immediately discharges the energy stored in the pouches in its cheeks. " },
        new Pokemon { Id = 3, Name = "Charizar, It spits fire that is hot enough to melt boulders. It may cause forest fires by blowing flames. " }
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