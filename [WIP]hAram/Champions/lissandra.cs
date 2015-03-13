using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class lissandra : Base
    {
        public lissandra()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            CastSpell(Q, qData);
            CastSpell(W, wData);
            
            target = GetTarget(R);
            if (Killable(true, true, false, true) || status == "Fight" && Player.HealthPercentage() <= 20)
            {
                R.CastOnUnit(target);
            }
        }

        public override void AntiGapcloser_OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsEnemy)
            {
                if (Player.Distance(gapcloser.End) <= 200)
                    AntiGapClose(E);

                E.Cast();
            }
        }
    }
}
