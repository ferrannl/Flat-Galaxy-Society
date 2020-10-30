using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Factories
{
    public class CollisionStrategyFactory
    {
        private static CollisionStrategyFactory instance;

        public static CollisionStrategyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CollisionStrategyFactory();
                }
                return instance;
            }
        }
        public CollisionStrategy CreateStrategy(string strategyType)
        {
            Type type = typeof(CollisionStrategy);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (Type t in types)
            {
                if (!t.IsAbstract)
                {
                    CollisionStrategy strategy = (CollisionStrategy)Activator.CreateInstance(t);
                    if (strategy.IsStrategy(strategyType))
                    {
                        return strategy;
                    }
                }
            }

            throw new Exception("De ingelezen \"oncollision\" wordt niet ondersteund. Galaxy-bestand niet geldig.");
        }

        public virtual CollisionStrategy GetNextStrategy(CollisionStrategy strategy)
        {
            switch (strategy.Type())
            {
                case "bounce":
                    return CreateStrategy("blink");
                case "grow":
                    return CreateStrategy("explode");
            }
            return strategy;
        }
    }
}
