using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal interface IState
    {
        IState NextState { get; set; }
        IState Update();
        void Enter(CoOpController gameController);
        void Exit();
    }
}
