using JetBrains.Annotations;
using System;
using Scellecs.Morpeh.Collections;

namespace Scellecs.Morpeh.Addons.Feature
{
    public abstract class BaseFeature : IDisposable
    {
        private protected World world;
        private protected SystemsGroup featureSystemsGroup;

        private protected bool enabled = true;

        [PublicAPI]
        public void AddInitializer(IInitializer initializer)
        {
            featureSystemsGroup.AddInitializer(initializer);
        }

        [PublicAPI]
        public abstract void Enable();

        [PublicAPI]
        public abstract void Disable();

        internal abstract void Register(World world, int order, bool enabled);

        public abstract void Dispose();

        protected static void MoveSystemsList(FastList<ISystem> fromSystems, FastList<ISystem> toSystems)
        {
            foreach (var system in fromSystems)
                toSystems.Add(system);
            fromSystems.Clear();
        }

        public FastList<ISystem> GetSystems()
        {
            return featureSystemsGroup.systems;
        }

        public FastList<IInitializer> GetInitializers()
        {
            return featureSystemsGroup.newInitializers;
        }
    }
}
