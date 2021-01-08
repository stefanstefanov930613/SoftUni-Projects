using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var removedElements = new List<int>();

            while (true)
            {

                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < pokemons.Count) //Remove the element at the given index (if the index exist)
                {
                    var elementToRemove = pokemons.ElementAt(index);
                    pokemons.RemoveAt(index);
                    removedElements.Add(elementToRemove);

                    for (int number = 0; number < pokemons.Count; number++)
                    {

                        if (pokemons[number] <= elementToRemove)
                        {
                            pokemons[number] += elementToRemove;
                        }
                        else
                        {
                            pokemons[number] -= elementToRemove;
                        }

                    }

                }
                else if (index < 0) //If the index is less than zero, remove the first element of the sequence, and copy the last element to its place.
                {
                    var lastElement = pokemons.ElementAt(pokemons.Count - 1);
                    var firstElement = pokemons.ElementAt(0);
                    pokemons.Remove(firstElement);
                    pokemons.Insert(0, lastElement);
                    removedElements.Add(firstElement);

                    for (int number = 0; number < pokemons.Count; number++)
                    {

                        if (pokemons[number] <= firstElement)
                        {
                            pokemons[number] += firstElement;
                        }
                        else
                        {
                            pokemons[number] -= firstElement;
                        }

                    }

                }
                else if (index > pokemons.Count - 1) //If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
                {
                    var firstElement = pokemons.ElementAt(0);
                    var lastElement = pokemons.ElementAt(pokemons.Count - 1);
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(firstElement);
                    removedElements.Add(lastElement);

                    for (int number = 0; number < pokemons.Count; number++)
                    {

                        if (pokemons[number] <= lastElement)
                        {
                            pokemons[number] += lastElement;
                        }
                        else
                        {
                            pokemons[number] -= lastElement;
                        }

                    }

                }

                if (pokemons.Count == 0) //If the list of elements becomes empty at some point, the program ends it's execution.
                {
                    break;
                }
                 
            }
             
            Console.WriteLine(removedElements.Sum());
        }
    }
}
