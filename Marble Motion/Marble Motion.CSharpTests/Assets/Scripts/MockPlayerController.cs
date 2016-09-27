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
        public Vector3 Force;
        public float Score;
        public string ScoreText;

        public void MoveObject(Vector3 force)
        {
            Force = force;
        }

        public void SetObjectScore(float score)
        {
            ScoreText = score.ToString();
            Score = score;
        }
    }
}
