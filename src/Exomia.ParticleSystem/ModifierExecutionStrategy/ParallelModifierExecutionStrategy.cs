﻿#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Threading.Tasks;

namespace Exomia.ParticleSystem.ModifierExecutionStrategy
{
    /// <summary>
    ///     A parallel modifier execution strategy. This class cannot be inherited.
    /// </summary>
    public sealed class ParallelModifierExecutionStrategy : IModifierExecutionStrategy
    {
        /// <summary>
        ///     The default.
        /// </summary>
        public static ParallelModifierExecutionStrategy Default = new ParallelModifierExecutionStrategy();

        /// <summary>
        ///     Executes the modifiers operation.
        /// </summary>
        /// <param name="modifiers">      The modifiers. </param>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
        public unsafe void ExecuteModifiers(IModifier[] modifiers, float elapsedSeconds, Particle* particle, int count)
        {
            Parallel.For(
                0, modifiers.Length, i =>
                {
                    modifiers[i].Update(elapsedSeconds, particle, count);
                });
        }
    }
}