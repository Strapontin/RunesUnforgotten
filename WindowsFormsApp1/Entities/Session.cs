using System;
using System.Collections.Generic;
using WindowsFormsApp1.Entities;

public class Session
{
    public List<List<WindowsFormsApp1.Entities.Action>> actions { get; set; }
    public bool allowBattleBoost { get; set; }
    public bool allowDuplicatePicks { get; set; }
    public bool allowLockedEvents { get; set; }
    public bool allowRerolling { get; set; }
    public bool allowSkinSelection { get; set; }
    //public Bans bans { get; set; }
    //public BenchChampionIds benchChampionIds { get; set; }
    public bool benchEnabled { get; set; }
    public Int64 boostableSkinCount { get; set; }
    //public ChatDetails chatDetails { get; set; }
    public Int64 counter { get; set; }
    //public EntitledFeatureState entitledFeatureState { get; set; }
    public Int64 gameId { get; set; }
    public bool hasSimultaneousBans { get; set; }
    public bool hasSimultaneousPicks { get; set; }
    public bool isCustomGame { get; set; }
    public bool isSpectating { get; set; }
    public Int64 localPlayerCellId { get; set; }
    public Int64 lockedEventIndex { get; set; }
    //public MyTeam myTeam { get; set; }
    public Int64 rerollsRemaining { get; set; }
    public bool skipChampionSelect { get; set; }
    //public TheirTeam theirTeam { get; set; }
    //public Timer timer { get; set; }
    //public Trades trades { get; set; }
}
