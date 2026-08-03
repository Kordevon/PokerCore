using System;
using System.Collections.Generic;
using System.Text;

namespace PokerCore
{
    internal class StartState : IState
    {
        public IState NextState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Enter(CoOpController gameController)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public IState Update()
        {
            throw new NotImplementedException();
        }
    }
}
