﻿using Scellecs.Morpeh.Addons.Systems;
using Scellecs.Morpeh.Collections;

namespace Scellecs.Morpeh.Addons.Feature.ClearSystems
{
    internal sealed class ClearFromStashLateSystem : LateUpdateSystem
    {
        private readonly FastList<Stash> _stashes;

        public ClearFromStashLateSystem(FastList<Stash> stashes)
        {
            _stashes = stashes;
        }

        public override void OnAwake()
        {   
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var stash in _stashes)
                stash.RemoveAll();
        }
    }
}
