using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    public abstract class State
    {
        private Pawn pawn;
        public bool IsSelectable { get; set; }

        public Pawn Pawn
        {
            get
            {
                return pawn;
            }
            set
            {
                pawn = value;
            }
        }

        public abstract void SwitchState();
    }
}