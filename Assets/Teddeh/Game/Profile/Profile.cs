using System;
using System.Collections.Generic;

namespace Teddeh.Game.Profile
{
    public interface Profile
    {
        bool RegisterForeignProfile<K, V>(V profile) where K : Type where V : ForeignProfile;

        V GetForeignProfile<K, V>(K type) where K : Type where V : ForeignProfile;
    }
}