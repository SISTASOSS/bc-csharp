﻿using System;
using System.Collections.Generic;

using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;

namespace Org.BouncyCastle.Crypto.Parameters
{
    public sealed class MLDsaParameterSet
    {
        public static readonly MLDsaParameterSet ML_DSA_44 = new MLDsaParameterSet("ML-DSA-44", 2);
        public static readonly MLDsaParameterSet ML_DSA_65 = new MLDsaParameterSet("ML-DSA-65", 3);
        public static readonly MLDsaParameterSet ML_DSA_87 = new MLDsaParameterSet("ML-DSA-87", 5);

        private static readonly Dictionary<string, MLDsaParameterSet> ByName =
            new Dictionary<string, MLDsaParameterSet>()
        {
            { ML_DSA_44.Name, ML_DSA_44 },
            { ML_DSA_65.Name, ML_DSA_65 },
            { ML_DSA_87.Name, ML_DSA_87 },
        };

        internal static MLDsaParameterSet FromName(string name) => CollectionUtilities.GetValueOrNull(ByName, name);

        private readonly string m_name;
        private readonly int m_mode;

        private MLDsaParameterSet(string name, int mode)
        {
            m_name = name ?? throw new ArgumentNullException(nameof(name));
            m_mode = mode;
        }

        public string Name => m_name;

        public override string ToString() => Name;

        internal DilithiumEngine GetEngine(SecureRandom random) => new DilithiumEngine(m_mode, random, usingAes: false);
    }
}
