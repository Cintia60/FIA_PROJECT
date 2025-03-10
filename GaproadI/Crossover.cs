using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;
using System.Collections.Generic;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Randomizations;


namespace GeneticSharp.Runner.UnityApp.Commons
{
    public class Crossover : ICrossover
    {
        public int ParentsNumber { get; private set; }
        public int ChildrenNumber { get; private set; }
        public int MinChromosomeLength { get; private set; }
        public bool IsOrdered { get; private set; } 
        protected float crossoverProbability;

        public Crossover(float crossoverProbability) : this(2, 2, 2, true)
        {
            this.crossoverProbability = crossoverProbability;
        }

        public Crossover(int parentsNumber, int offspringNumber, int minChromosomeLength, bool isOrdered)
        {
            ParentsNumber = parentsNumber;
            ChildrenNumber = offspringNumber;
            MinChromosomeLength = minChromosomeLength;
            IsOrdered = isOrdered;
        }

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            IChromosome parent1 = parents[0];
            IChromosome parent2 = parents[1];
            IChromosome offspring1 = parent1.Clone();
            IChromosome offspring2 = parent2.Clone();

            // Definição da probabilidade de ocorrer crossover
            if (RandomizationProvider.Current.GetDouble() <= crossoverProbability)
            {
                // Escolha de um ponto de corte aleatório
                int crossoverPoint = RandomizationProvider.Current.GetInt(0, parent1.Length);

                // Trocar os genes entre os pais nos pontos de corte
                for (int i = crossoverPoint; i < parent1.Length; i++)
                {
                    var gene1 = parent1.GetGene(i);
                    var gene2 = parent2.GetGene(i);

                    offspring1.ReplaceGene(i, gene2);
                    offspring2.ReplaceGene(i, gene1);
                }
            }

            return new List<IChromosome> { offspring1, offspring2 };
        }
    }
}
