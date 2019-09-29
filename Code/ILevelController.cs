using System;
using DraconianMarshmallows.RpgFramework.Code;

namespace DraconianMarshmallows.RpgFramework
{
    public interface ILevelController
    {
        BasePlayerController PlayerController { get; }

        BasePlayerController GetPlayerController();
    }
}
