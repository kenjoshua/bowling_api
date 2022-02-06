using domain_project.domain.Enums;
using domain_project.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
        public class Frame : BaseEntity
        {
            private readonly int _pins = 10;
            public int FrameLimit { get; private set; } = 10;

            public Frame(int order)
            {
                Order = order;
                ScoreState = ScoreStats.Draft;
                Stats = FrameStats.Default;
            }
            public Frame(int order, bool isLastFrame) : this(order)
            {

                IsLastFrame = isLastFrame;

            }

            public int? FirstTry { get; private set; }
            public int? SecondTry { get; private set; }
            public int? ThirdTry { get; private set; }

            public int Order { get; private set; }
            public bool IsLastFrame { get; private set; }

            public FrameStats Stats { get; private set; }
            public ScoreStats ScoreState { get; private set; }
            public int Score { get; private set; }


            public void SetAsLastFrame(bool isLastFrame) => IsLastFrame = isLastFrame;

            public int GetRawScore()
            {
                return Stats switch
                {
                    FrameStats.Default => 0,
                    FrameStats.Strike => FirstTry.Value, //always 10
                    FrameStats.Spare => FirstTry.Value + SecondTry.Value + (ThirdTry ?? 0),
                    _ => FirstTry.Value + SecondTry.Value + (ThirdTry ?? 0)
                };
            }
            public void FinalizeScore(int extraPoint = 0)
            {
                if (Stats == FrameStats.Strike)
                {
                    SecondTry = 0;
                }
                Score = FirstTry.Value + SecondTry.Value;

                if (IsLastFrame)
                {
                    Score += ThirdTry ?? 0;
                }

                Score += extraPoint;

                UpdateScoreStats(ScoreStats.Total);
            }

            public void RecordPinsKnockedDown(int pins)
            {
                if (pins > 10) throw new Exception("Invalid number of pins.");

                if (!FirstTry.HasValue)
                {
                    FirstTry = pins;

                    if (FirstTry == 10) Stats = FrameStats.Strike;
                    else Stats = FrameStats.Default;

                    if (IsLastFrame) { Stats = FrameStats.Default; }

                }
                else if (!SecondTry.HasValue)
                {
                    if (Stats == FrameStats.Strike) throw new Exception("Cannot add new score now.");
                    if (FirstTry + SecondTry > 10) throw new Exception("Invalid number of pins");

                    SecondTry = pins;

                    if (FirstTry + SecondTry == 10) Stats = FrameStats.Spare;
                    else Stats = FrameStats.Open;

                    if (IsLastFrame) { Stats = FrameStats.Default; }
                }
                else if (!ThirdTry.HasValue)
                {
                    if (IsLastFrame)
                    {
                        if (FirstTry.Value == 10 || FirstTry.Value + SecondTry.Value == 10)
                        {
                            //allow to record third 
                            //a. both strike -- meaning player is award 2 extra shots
                            //b. first and second results to a SPARE, meaning they can go at it for 1 more time
                            //c. 
                            ThirdTry = pins;

                        }
                        else
                        {
                            throw new Exception("Cannot add new score now.");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid score setup.");
                    }
                }
            }

            public void UpdateScoreStats(ScoreStats scoreStats) => ScoreState = scoreStats;

        }
    }
