﻿using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class ahri : Base
    {
        public ahri()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            CastSpell(E, eData);
            CastSpell(Q, qData);
            CastSpell(W, wData);

            if (Killable(true, true, true, true) || (status == "Fight" && Player.HealthPercentage() <= 30))
                CastSpell(R, rData);
        }
    }
}
