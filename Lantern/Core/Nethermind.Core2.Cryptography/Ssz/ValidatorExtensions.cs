﻿//  Copyright (c) 2018 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using Nethermind.Core2.Containers;

namespace Lantern
{
    public static class ValidatorExtensions
    {
        public static SszContainer ToSszContainer(this Validator item)
        {
            return new SszContainer(GetValues(item));
        }

        private static IEnumerable<SszElement> GetValues(Validator item)
        {
            yield return item.PublicKey.ToSszBasicVector();
            // Commitment to pubkey for withdrawals and transfers
            yield return item.WithdrawalCredentials.ToSszBasicVector();
            // Balance at stake
            yield return item.EffectiveBalance.ToSszBasicElement();
            yield return item.IsSlashed.ToSszBasicElement();
            // Status epochs
            // When criteria for activation were met
            yield return item.ActivationEligibilityEpoch.ToSszBasicElement();
            yield return item.ActivationEpoch.ToSszBasicElement();
            yield return item.ExitEpoch.ToSszBasicElement();
            // When validator can withdraw or transfer funds
            yield return item.WithdrawableEpoch.ToSszBasicElement();
        }
    }
}