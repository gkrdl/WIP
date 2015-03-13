using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class khazix : Base
    {
        public khazix()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            CastSpell(Q, qData);
            CastSpell(W, wData);

            if (Killable(true, true, true, false))
                CastSpell(E, eData);
            

            target = GetTarget(R);
            if (status == "Fight" && Player.HealthPercentage() <= 50)
                CastSpell(R, rData);
        }

        public override void AntiGapcloser_OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsEnemy)
            {
                if (Player.Distance(gapcloser.End) <= 200)
                    AntiGapClose(E);
            }
        }
    }
}
