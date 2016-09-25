using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests
{
    class MockPlayerController : IMovementController, IScoreController
    {
        public Vector3 MovedForce;

        public void Move(Vector3 force)
        {
            MovedForce = force;
        }

        public void Set(float score)
        {
            throw new NotImplementedException();
        }
    }
}
