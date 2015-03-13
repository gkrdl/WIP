﻿using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class karthus : Base
    {
        public karthus()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            CastSpell(Q, qData);
            CastSpell(W, wData);
            CastSpell(E, eData);


            if (Killable() && (TargetSelector.GetTarget(Orbwalking.GetRealAutoAttackRange(Player), TargetSelector.DamageType.Physical) == null))
                CastSpell(R, rData);
            else if (Player.IsDead)
                CastSpell(R, rData);
        }
    }
}
