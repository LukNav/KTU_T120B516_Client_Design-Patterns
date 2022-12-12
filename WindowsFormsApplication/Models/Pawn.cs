﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WindowsFormsApplication.Controllers.StatePattern;
using WindowsFormsApplication.Controllers.StrategyPattern;

namespace WindowsFormsApplication.Models
{
    public class Pawn
    {
        public Pawn(Position position, string imageName, int health, int cost, int speed, int damage, int armor, PawnClass tier, State state)
        {
            Position = position;
            ImageName = imageName;
            Health = health;
            Cost = cost;
            Speed = speed;
            Damage = damage;
            Armor = armor;
            SkippedTick = false;
            Tier = tier;
            PlayerState = state;
            switch (tier)
            {
                case PawnClass.Tier1:
                    moveAlgorithm = new ForwardMovement();
                    break;
                case PawnClass.Tier2:
                    moveAlgorithm = new DiagonalMovement();
                    break;
                case PawnClass.Tier3:
                    moveAlgorithm = new FurtherMovement();
                    break;
                default:
                    break;
            }
        }
        public State PlayerState { get; set; }
        public Position Position { get; set; }
        public string ImageName { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public bool SkippedTick { get; set; }
        public PawnClass Tier { get; set; }
        [JsonIgnore]
        public IMoveAlgorithm moveAlgorithm { get; set; }
    }
    public enum PawnClass
    {
        Tier1,
        Tier2,
        Tier3
    }
}
